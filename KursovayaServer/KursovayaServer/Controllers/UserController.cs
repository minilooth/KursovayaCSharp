using Autodealers.Models;
using ServerUtilities;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;

namespace KursovayaServer.Controllers
{
    class UserController : IController
    {
        public Session Session { get; set; } = null;
        public AutodealersContext AutodealersContext { get; set; } = null;
        public User CurrentUser { get; set; } = null;
        public bool IsAuthorized { get; set; } = false;

        private BinaryFormatter _BinaryFormatter = null;
        private NetworkStream _NetworkStream = null;

        private bool _IsSearchModeEnabled = false;
        private string _SearchUsername = null;

        public UserController(Session session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session), "Сессия не найдена.");
            AutodealersContext = new AutodealersContext();

            _BinaryFormatter = new BinaryFormatter();
            _NetworkStream = Session.Client.GetStream();
        }

        public void RefreshContext()
        {
            AutodealersContext = new AutodealersContext();
        }

        public void Authorize()
        {
            RefreshContext();
             
            string username = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            string password = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            var user = AutodealersContext.User.FirstOrDefault(u => u.Username == username);

            if (user == null || user.Password != password)
            {
                Session.SendErrorMessage("Неверный логин или пароль!");
                return;
            }

            if (user.BanStatus)
            {
                Session.SendErrorMessage("Ваш аккаунт заблокирован!");
                return;
            }

            CurrentUser = user;
            IsAuthorized = true;

            if (CurrentUser.SuperUser)
            {
                Session.StatisticsController.CheckAndCreateNewStatistic();
            }

            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
        
            RefreshContext();
        }

        //TODO Переделать регистрацию
        public void Register()
        {
            RefreshContext();
             
            string username = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            string password = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            string firstname = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            string surname = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            string telephone = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            var user = AutodealersContext.User.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                Session.SendErrorMessage("Пользователь с таким логином уже существует!");
                return;
            }

            if (username.Length < 5)
            {
                Session.SendErrorMessage("Логин должен состоять минимум из 5 символов!");
                return;
            }
            if (username.Length > 20)
            {
                Session.SendErrorMessage("Логин должен состоять максимум из 20 символов!");
                return;
            }

            if (!Regex.IsMatch(username, "^[a-zA-Z0-9]+$"))
            {
                Session.SendErrorMessage("Логин содержит недопустимые символы!");
                return;
            }

            if (password.Length < 8)
            {
                Session.SendErrorMessage("Пароль должен состоять минимум из 8 символов!");
                return;
            }
            if (password.Length > 20)
            {
                Session.SendErrorMessage("Пароль должен состоять максимум из 20 символов!");
                return;
            }

            if (!Regex.IsMatch(password, "^[a-zA-Z0-9]+$"))
            {
                Session.SendErrorMessage("Пароль содержит недопустимые символы!");
                return;
            }

            if (firstname != "Имя")
            {
                if (firstname.Length < 2)
                {
                    Session.SendErrorMessage("Имя должно состоять минимум из 2 символов!");
                    return;
                }
                if (firstname.Length > 20)
                {
                    Session.SendErrorMessage("Имя должно состоять максимум из 20 символов");
                    return;
                }
                if (!Regex.IsMatch(firstname, "^[a-zA-Zа-яА-Я]+$"))
                {
                    Session.SendErrorMessage("Имя содержит недопустимые символы!");
                    return;
                }
            }
            else
            {
                firstname = null;
            }

            if (surname != "Фамилия")
            {
                if (surname.Length < 2)
                {
                    Session.SendErrorMessage("Фамилия должна состоять минимум из 2 символов!");
                    return;
                }
                if (surname.Length > 20)
                {
                    Session.SendErrorMessage("Фамилия должна состоять максимум из 20 символов!");
                    return;
                }

                if (!Regex.IsMatch(surname, "^[a-zA-Zа-яА-Я]+$"))
                {
                    Session.SendErrorMessage("Фамилия содержит недопустимые символы!");
                    return;
                }
            }
            else
            {
                surname = null;
            }

            if (telephone != "Телефон")
            {
                if (telephone.Length != 13 || !Regex.IsMatch(telephone, "^\\+[0-9]*$"))
                {
                    Session.SendErrorMessage("Неверный формат номера!");
                    return;
                }
            }
            else
            {
                telephone = null;
            }

            user = new User
            {
                Username = username,
                Password = password,
                Firstname = firstname,
                Surname = surname,
                Telephone = telephone
            };

            AutodealersContext.User.Add(user);
            AutodealersContext.SaveChanges();

            Session.SendSuccessfulMessage("Вы успешно зарегистрировались!");
        
            RefreshContext();
        }

        public void GetCurrentUser()
        {
            RefreshContext();
            if (IsAuthorized)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                _BinaryFormatter.Serialize(_NetworkStream, CurrentUser);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void GetUsers()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    _BinaryFormatter.Serialize(_NetworkStream, !_IsSearchModeEnabled ? AutodealersContext.User.ToList() : 
                                                                                        AutodealersContext.User.Where(u => u.Username.StartsWith(_SearchUsername, StringComparison.CurrentCultureIgnoreCase)).ToList());
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void GetUsersNotSuperUsers()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    _BinaryFormatter.Serialize(_NetworkStream, !_IsSearchModeEnabled ? AutodealersContext.User.Where(u => u.SuperUser == false).ToList() :
                                                                                        AutodealersContext.User.Where(u => u.Username.StartsWith(_SearchUsername, StringComparison.CurrentCultureIgnoreCase) && u.SuperUser == false).ToList());
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void BanUnbanUser()
        {
            RefreshContext();

            var receivedUser = (User)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var banUnbanUser = AutodealersContext.User.FirstOrDefault(u => u.UserId == receivedUser.UserId);

                    if (banUnbanUser != null)
                    {
                        if (banUnbanUser.UserId == CurrentUser.UserId && banUnbanUser.SuperUser)
                        {
                            Session.SendErrorMessage("Невозможно заблокировать текущего администратора. Сделайте это через другого адмнистратора.");
                        }
                        else
                        {
                            banUnbanUser.BanStatus = !banUnbanUser.BanStatus;
                            AutodealersContext.SaveChanges();

                           _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Пользователь не найден!");
                    }
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void SetUserSearchData()
        {
            RefreshContext();

            var receivedUsername = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (receivedUsername != "Поиск по логину")
                    {
                        _SearchUsername = receivedUsername;
                        _IsSearchModeEnabled = true;
                    }
                    else
                    {
                        _IsSearchModeEnabled = false;
                    }

                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void Add()
        {
            RefreshContext();

            var user = (User)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var findResult = AutodealersContext.User.FirstOrDefault(u => u.Username == user.Username);

                    if (findResult != null)
                    {
                        Session.SendErrorMessage("Пользователь с таким логином уже существует!");
                        return;
                    }

                    if (user.Username.Length < 5)
                    {
                        Session.SendErrorMessage("Логин должен состоять минимум из 5 символов!");
                        return;
                    }
                    if (user.Username.Length > 20)
                    {
                        Session.SendErrorMessage("Логин должен состоять максимум из 20 символов!");
                        return;
                    }

                    if (!Regex.IsMatch(user.Username, "^[a-zA-Z0-9]+$"))
                    {
                        Session.SendErrorMessage("Логин содержит недопустимые символы!");
                        return;
                    }

                    if (user.Password.Length < 8)
                    {
                        Session.SendErrorMessage("Пароль должен состоять минимум из 8 символов!");
                        return;
                    }
                    if (user.Password.Length > 20)
                    {
                        Session.SendErrorMessage("Пароль должен состоять максимум из 20 символов!");
                        return;
                    }

                    if (!Regex.IsMatch(user.Password, "^[a-zA-Z0-9]+$"))
                    {
                        Session.SendErrorMessage("Пароль содержит недопустимые символы!");
                        return;
                    }

                    if (!String.IsNullOrEmpty(user.Firstname))
                    {
                        if (user.Firstname.Length < 2)
                        {
                            Session.SendErrorMessage("Имя должно состоять минимум из 2 символов!");
                            return;
                        }
                        if (user.Firstname.Length > 20)
                        {
                            Session.SendErrorMessage("Имя должно состоять максимум из 20 символов");
                            return;
                        }

                        if (!Regex.IsMatch(user.Firstname, "^[a-zA-Zа-яА-Я]+$"))
                        {
                            Session.SendErrorMessage("Имя содержит недопустимые символы!");
                            return;
                        }

                        user.Firstname = Char.ToUpper(user.Firstname[0]) + user.Firstname.Substring(1);
                    }
                    else
                    {
                        user.Firstname = null;
                    }

                    if (!String.IsNullOrEmpty(user.Surname))
                    {
                        if (user.Surname.Length < 2)
                        {
                            Session.SendErrorMessage("Фамилия должна иметь минимум 2 символа!");
                            return;
                        }
                        if (user.Surname.Length > 20)
                        {
                            Session.SendErrorMessage("Фамилия должна иметь максимум 20 символов!");
                            return;
                        }

                        if (!Regex.IsMatch(user.Surname, "^[a-zA-Zа-яА-Я]+$"))
                        {
                            Session.SendErrorMessage("Фамилия содержит недопустимые символы!");
                            return;
                        }

                        user.Surname = Char.ToUpper(user.Surname[0]) + user.Surname.Substring(1);
                    }
                    else
                    {
                        user.Surname = null;
                    }

                    if (!String.IsNullOrEmpty(user.Telephone))
                    {
                        if (user.Telephone.Length != 13 || !Regex.IsMatch(user.Telephone, "^\\+[0-9]*$"))
                        {
                            Session.SendErrorMessage("Неверный формат номера!");
                            return;
                        }
                    }
                    else
                    {
                        user.Telephone = null;
                    }

                    AutodealersContext.User.Add(user);
                    AutodealersContext.SaveChanges();

                   _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void EditCurrentUserUsername()
        {
            RefreshContext();

            var receivedUsername = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (CurrentUser.Username != receivedUsername)
                {
                    var user = AutodealersContext.User.FirstOrDefault(u => u.Username == receivedUsername);

                    if (user != null)
                    {
                        Session.SendErrorMessage("Пользователь с таким логином уже существует!");
                        return;
                    }

                    if (receivedUsername.Length < 5)
                    {
                        Session.SendErrorMessage("Логин должен состоять минимум из 5 символов!");
                        return;
                    }
                    if (receivedUsername.Length > 20)
                    {
                        Session.SendErrorMessage("Логин должен состоять максимум из 20 символов!");
                        return;
                    }

                    if (!Regex.IsMatch(receivedUsername, "^[a-zA-Z0-9]+$"))
                    {
                        Session.SendErrorMessage("Логин содержит недопустимые символы!");
                        return;
                    }

                    CurrentUser.Username = receivedUsername;

                    AutodealersContext.Update(CurrentUser);
                    AutodealersContext.SaveChanges();

                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                }
                else
                {
                    if (receivedUsername.Length < 5)
                    {
                        Session.SendErrorMessage("Логин должен состоять минимум из 5 символов!");
                        return;
                    }
                    if (receivedUsername.Length > 20)
                    {
                        Session.SendErrorMessage("Логин должен состоять максимум из 20 символов!");
                        return;
                    }

                    if (!Regex.IsMatch(receivedUsername, "^[a-zA-Z0-9]+$"))
                    {
                        Session.SendErrorMessage("Логин содержит недопустимые символы!");
                        return;
                    }

                    CurrentUser.Username = receivedUsername;

                    AutodealersContext.Update(CurrentUser);
                    AutodealersContext.SaveChanges();

                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void EditCurrentUserPassword()
        {
            RefreshContext();

            var receivedPassword = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (receivedPassword.Length < 8)
                {
                    Session.SendErrorMessage("Пароль должен состоять минимум из 8 символов!");
                    return;
                }
                if (receivedPassword.Length > 20)
                {
                    Session.SendErrorMessage("Пароль должен состоять максимум из 20 символов!");
                    return;
                }

                if (!Regex.IsMatch(receivedPassword, "^[a-zA-Z0-9]+$"))
                {
                    Session.SendErrorMessage("Пароль содержит недопустимые символы!");
                    return;
                }

                CurrentUser.Password = receivedPassword;

                AutodealersContext.Update(CurrentUser);
                AutodealersContext.SaveChanges();

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void EditCurrentUserFirstname()
        {
            RefreshContext();

            var receivedFirstname = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (!String.IsNullOrEmpty(receivedFirstname))
                {
                    if (receivedFirstname.Length < 2)
                    {
                        Session.SendErrorMessage("Имя должно состоять минимум из 2 символов!");
                        return;
                    }
                    if (receivedFirstname.Length > 20)
                    {
                        Session.SendErrorMessage("Имя должно состоять максимум из 20 символов");
                        return;
                    }

                    if (!Regex.IsMatch(receivedFirstname, "^[a-zA-Zа-яА-Я]+$"))
                    {
                        Session.SendErrorMessage("Имя содержит недопустимые символы!");
                        return;
                    }

                    receivedFirstname = Char.ToUpper(receivedFirstname[0]) + receivedFirstname.Substring(1);
                }
                else
                {
                    receivedFirstname = null;
                }

                CurrentUser.Firstname = receivedFirstname;

                AutodealersContext.Update(CurrentUser);
                AutodealersContext.SaveChanges();

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void EditCurrentUserSurname()
        {
            RefreshContext();

            var receivedSurname = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (!String.IsNullOrEmpty(receivedSurname))
                {
                    if (receivedSurname.Length < 2)
                    {
                        Session.SendErrorMessage("Фамилия должна иметь минимум 2 символа!");
                        return;
                    }
                    if (receivedSurname.Length > 20)
                    {
                        Session.SendErrorMessage("Фамилия должна иметь максимум 20 символов!");
                        return;
                    }

                    if (!Regex.IsMatch(receivedSurname, "^[a-zA-Zа-яА-Я]+$"))
                    {
                        Session.SendErrorMessage("Фамилия содержит недопустимые символы!");
                        return;
                    }

                    receivedSurname = Char.ToUpper(receivedSurname[0]) + receivedSurname.Substring(1);
                }
                else
                {
                    receivedSurname = null;
                }

                CurrentUser.Surname = receivedSurname;

                AutodealersContext.Update(CurrentUser);
                AutodealersContext.SaveChanges();

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void EditCurrentUserTelephone()
        {
            RefreshContext();

            var receivedTelephone = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (!String.IsNullOrEmpty(receivedTelephone))
                {
                    if (receivedTelephone.Length != 13 || !Regex.IsMatch(receivedTelephone, "^\\+[0-9]*$"))
                    {
                        Session.SendErrorMessage("Неверный формат номера!");
                        return;
                    }
                }
                else
                {
                    receivedTelephone = null;
                }

                CurrentUser.Telephone = receivedTelephone;

                AutodealersContext.Update(CurrentUser);
                AutodealersContext.SaveChanges();

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void Edit()
        {
            RefreshContext();

            var receivedUser = (User)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var editUser = AutodealersContext.User.FirstOrDefault(u => u.UserId == receivedUser.UserId);

                    if (editUser != null)
                    {
                        if (editUser.UserId == CurrentUser.UserId && editUser.SuperUser != receivedUser.SuperUser)
                        {
                            Session.SendErrorMessage("Не возможно изменить права самому себе. Сделайте это через другого администратора!");
                        }
                        else if (editUser.UserId == CurrentUser.UserId && editUser.BanStatus != receivedUser.BanStatus)
                        {
                            Session.SendErrorMessage("Не возможно заблокировать самого себя. Сделайте это через другого администратора!");
                        }
                        else
                        {
                            if (editUser.Username != receivedUser.Username)
                            {
                                var user = AutodealersContext.User.FirstOrDefault(u => u.Username == receivedUser.Username);

                                if (user != null)
                                {
                                    Session.SendErrorMessage("Пользователь с таким логином уже существует!");
                                    return;
                                }
                            }

                            if (receivedUser.Username.Length < 5)
                            {
                                Session.SendErrorMessage("Логин должен состоять минимум из 5 символов!");
                                return;
                            }
                            if (receivedUser.Username.Length > 20)
                            {
                                Session.SendErrorMessage("Логин должен состоять максимум из 20 символов!");
                                return;
                            }

                            if (!Regex.IsMatch(receivedUser.Username, "^[a-zA-Z0-9]+$"))
                            {
                                Session.SendErrorMessage("Логин содержит недопустимые символы!");
                                return;
                            }

                            if (receivedUser.Password.Length < 8)
                            {
                                Session.SendErrorMessage("Пароль должен состоять минимум из 8 символов!");
                                return;
                            }
                            if (receivedUser.Password.Length > 20)
                            {
                                Session.SendErrorMessage("Пароль должен состоять максимум из 20 символов!");
                                return;
                            }

                            if (!Regex.IsMatch(receivedUser.Password, "^[a-zA-Z0-9]+$"))
                            {
                                Session.SendErrorMessage("Пароль содержит недопустимые символы!");
                                return;
                            }

                            if (!String.IsNullOrEmpty(receivedUser.Firstname))
                            {
                                if (receivedUser.Firstname.Length < 2)
                                {
                                    Session.SendErrorMessage("Имя должно состоять минимум из 2 символов!");
                                    return;
                                }
                                if (receivedUser.Firstname.Length > 20)
                                {
                                    Session.SendErrorMessage("Имя должно состоять максимум из 20 символов!");
                                }

                                if (!Regex.IsMatch(receivedUser.Firstname, "^[a-zA-Zа-яА-Я]+$"))
                                {
                                    Session.SendErrorMessage("Имя содержит недопустимые символы!");
                                    return;
                                }
                            }
                            else
                            {
                                receivedUser.Firstname = null;
                            }

                            if (!String.IsNullOrEmpty(receivedUser.Surname))
                            {
                                if (receivedUser.Surname.Length < 2)
                                {
                                    Session.SendErrorMessage("Фамилия должна состоять минимум из 2 символов!");
                                    return;
                                }
                                if (receivedUser.Surname.Length > 20)
                                {
                                    Session.SendErrorMessage("Фамилия должна состоять максимум из 20 символов!");
                                }

                                if (!Regex.IsMatch(receivedUser.Surname, "^[a-zA-Zа-яА-Я]+$"))
                                {
                                    Session.SendErrorMessage("Фамилия содержит недопустимые символы!");
                                    return;
                                }
                            }
                            else
                            {
                                receivedUser.Surname = null;
                            }

                            if (!String.IsNullOrEmpty(receivedUser.Telephone))
                            {
                                if (receivedUser.Telephone.Length != 13 || !Regex.IsMatch(receivedUser.Telephone, "^\\+[0-9]*$"))
                                {
                                    Session.SendErrorMessage("Неверный формат номера!");
                                    return;
                                }
                            }
                            else
                            {
                                receivedUser.Telephone = null;
                            }

                            editUser.Username = receivedUser.Username;
                            editUser.Password = receivedUser.Password;
                            editUser.Firstname = receivedUser.Firstname;
                            editUser.Surname = receivedUser.Surname;
                            editUser.Telephone = receivedUser.Telephone;
                            editUser.SuperUser = receivedUser.SuperUser;
                            editUser.BanStatus = receivedUser.BanStatus;

                            AutodealersContext.Update(editUser);
                            AutodealersContext.SaveChanges();

                           _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Пользователь не найден!");
                    }
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void Delete()
        {
            RefreshContext();

            var receivedUser = (User)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deleteUser = AutodealersContext.User.FirstOrDefault(u => u.UserId == receivedUser.UserId);

                    if (deleteUser != null)
                    {
                        if (deleteUser.UserId == CurrentUser.UserId && deleteUser.SuperUser)
                        {
                            Session.SendErrorMessage("Невозможно удалить текущего администратора. Сделайте это через другого адмнинистратора.");
                        }
                        else
                        {
                            var deals = AutodealersContext.Deal.Where(d => d.UserId == deleteUser.UserId).ToList();

                            foreach (var d in deals)
                            {
                                var admin = AutodealersContext.User.ToList().FirstOrDefault(u => u.SuperUser);

                                if (admin != null)
                                {
                                    d.UserId = admin.UserId;
                                }
                            }

                            AutodealersContext.User.Remove(deleteUser);
                            AutodealersContext.SaveChanges();

                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Пользователь не найден!");
                    }
                }
                else
                {
                    Session.SendErrorMessage("Для этого действия требуются права администратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        
    }
}
