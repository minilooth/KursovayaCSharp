using Autodealers.Enums;
using Autodealers.Models;
using ServerUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace KursovayaServer.Controllers
{
    class AutodealerController : IController
    {
        public Session Session { get; set; } = null;
        public AutodealersContext AutodealersContext { get; set; } = null;

        public Autodealer CurrentAutodealer { get; private set; } = null;

        private BinaryFormatter _BinaryFormatter = null;
        private NetworkStream _NetworkStream = null;

        private string _SearchTitle = null;
        private bool _IsSearchModeEnabled = false;

        public AutodealerController(Session session)
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

        public void GetAutodealers()
        {
            RefreshContext();

            if (Session.UserController.IsAuthorized)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);

                _BinaryFormatter.Serialize(_NetworkStream, _IsSearchModeEnabled ? AutodealersContext.Autodealer.Where(a => a.Title.StartsWith(_SearchTitle, StringComparison.CurrentCultureIgnoreCase)).ToList() :
                                                                                    AutodealersContext.Autodealer.ToList());
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void GetCurrentAutodealer()
        {
            RefreshContext();

            if (Session.UserController.IsAuthorized)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                _BinaryFormatter.Serialize(_NetworkStream, Session.AutodealerController.CurrentAutodealer);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void SetCurrentAutodealer()
        {
            RefreshContext();

            if (Session.UserController.IsAuthorized)
            {
                var autodealerId = (int)_BinaryFormatter.Deserialize(_NetworkStream);

                CurrentAutodealer = AutodealersContext.Autodealer.FirstOrDefault(a => a.AutodealerId == autodealerId);

                if (CurrentAutodealer == null)
                {
                    Session.SendErrorMessage("Автосалон не выбран!");
                }
                else
                {
                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    Session.CarController.IsFilteringEnabled = false;

                    if (!Session.UserController.CurrentUser.SuperUser)
                    {
                        Session.StatisticsController.AddVisitToAutodealer(Session.AutodealerController.CurrentAutodealer);
                    }
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация");
            }

            RefreshContext();
        }

        public void SetAutodealerSearchData()
        {
            RefreshContext();
             
            var receivedTitle = (string)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (receivedTitle != "Поиск по названию")
                    {
                        _SearchTitle = receivedTitle;
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

            var receivedAutodealer = (Autodealer)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (Session.AutodealerController.CurrentAutodealer != null)
                    {
                        if (receivedAutodealer != null)
                        {
                            if (!Regex.IsMatch(receivedAutodealer.Title, "^[A-Za-zА-Яа-я0-9 -]+$"))
                            {
                                Session.SendErrorMessage("Название введено некорректно!");
                                return;
                            }
                            if (receivedAutodealer.Title.Length > 100)
                            {
                                Session.SendErrorMessage("Название автосалона должно состоять максимум из 100 символов!");
                                return;
                            }

                            if (!Regex.IsMatch(receivedAutodealer.City, "^[A-Za-zА-Яа-я]+$"))
                            {
                                Session.SendErrorMessage("Город введен некорректно!");
                                return;
                            }
                            if (receivedAutodealer.City.Length > 50)
                            {
                                Session.SendErrorMessage("Название города должно состоять максимум из 50 символов!");
                                return;
                            }

                            if (receivedAutodealer.Address != "")
                            {
                                if (!Regex.IsMatch(receivedAutodealer.Address, "^[A-Za-zА-Яа-я0-9 .,-]+$"))
                                {
                                    Session.SendErrorMessage("Адрес введен некорректно!");
                                    return;
                                }
                                if (receivedAutodealer.Address.Length > 50)
                                {
                                    Session.SendErrorMessage("Адрес должен состоять максимум из 50 символов!");
                                    return;
                                }
                            }
                            else
                            {
                                receivedAutodealer.Address = null;
                            }

                            var autodealer = new Autodealer
                            {
                                Title = receivedAutodealer.Title,
                                WorkingHours = receivedAutodealer.WorkingHours,
                                City = receivedAutodealer.City,
                                Address = receivedAutodealer.Address
                            };

                            AutodealersContext.Autodealer.Add(autodealer);

                            AutodealersContext.SaveChanges();

                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);

                            AutodealersContext.Statistics.Add(new Statistics 
                            { 
                                AutodealerId = autodealer.AutodealerId,
                                Month = (Month)DateTime.Now.Month,
                                Year = DateTime.Now.Year
                            });
                            AutodealersContext.SaveChanges();
                        }
                        else
                        {
                            Session.SendErrorMessage("Сделка не найдена!");
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Автосалон не найден!");
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

        public void Edit()
        {
            RefreshContext();

            var receivedAutodealer = (Autodealer)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var editAutodealer = AutodealersContext.Autodealer.FirstOrDefault(a => a.AutodealerId == receivedAutodealer.AutodealerId);

                    if (editAutodealer != null)
                    {
                        if (!Regex.IsMatch(receivedAutodealer.Title, "^[A-Za-zА-Яа-я0-9 ]+$"))
                        {
                            Session.SendErrorMessage("Название введено некорректно!");
                            return;
                        }
                        if (receivedAutodealer.Title.Length > 100)
                        {
                            Session.SendErrorMessage("Название автосалона должно состоять максимум из 100 символов!");
                            return;
                        }

                        if (!Regex.IsMatch(receivedAutodealer.City, "^[A-Za-zА-Яа-я]+$"))
                        {
                            Session.SendErrorMessage("Город введен некорректно!");
                            return;
                        }
                        if (receivedAutodealer.City.Length > 50)
                        {
                            Session.SendErrorMessage("Название города должно состоять максимум из 50 символов!");
                            return;
                        }

                        if (receivedAutodealer.Address != "")
                        {
                            if (!Regex.IsMatch(receivedAutodealer.Address, "^[A-Za-zА-Яа-я0-9 .,]+$"))
                            {
                                Session.SendErrorMessage("Адрес введен некорректно!");
                                return;
                            }
                            if (receivedAutodealer.Address.Length > 50)
                            {
                                Session.SendErrorMessage("Адрес должен состоять максимум из 50 символов!");
                                return;
                            }
                        }
                        else
                        {
                            receivedAutodealer.Address = null;
                        }

                        editAutodealer.Title = receivedAutodealer.Title;
                        editAutodealer.WorkingHours = receivedAutodealer.WorkingHours;
                        editAutodealer.City = receivedAutodealer.City;
                        editAutodealer.Address = receivedAutodealer.Address;

                        AutodealersContext.Autodealer.Update(editAutodealer);
                        AutodealersContext.SaveChanges();

                       _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    }
                    else
                    {
                        Session.SendErrorMessage("Автосалон не найден!");
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
            var receivedAutodealer = (Autodealer)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deleteAutodealer = AutodealersContext.Autodealer.FirstOrDefault(a => a.AutodealerId == receivedAutodealer.AutodealerId);

                    if (deleteAutodealer != null)
                    {
                        if (deleteAutodealer.AutodealerId != CurrentAutodealer.AutodealerId)
                        {
                            AutodealersContext.Autodealer.Remove(deleteAutodealer);
                            AutodealersContext.SaveChanges();
                         
                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                        }
                        else
                        {
                            Session.SendErrorMessage("Невозможно удалить текущий автосалон!");
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
