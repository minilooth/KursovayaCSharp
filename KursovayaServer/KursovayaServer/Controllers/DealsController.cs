using Autodealers.Models;
using ServerUtilities;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace KursovayaServer.Controllers
{
    class DealsController : IController
    {
        public Session Session { get; set; } = null;
        public AutodealersContext AutodealersContext { get; set; } = null;

        private NetworkStream _NetworkStream = null;
        private BinaryFormatter _BinaryFormatter = null;

        private string _SearchUsername = null;
        private bool _IsSearchModeEnabled = false;


        public DealsController(Session session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session), "Null session.");
            AutodealersContext = new AutodealersContext();

            _NetworkStream = Session.Client.GetStream();
            _BinaryFormatter = new BinaryFormatter();
        }


        public void RefreshContext()
        {
            AutodealersContext = new AutodealersContext();
        }

        public void SetDealSearchData()
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
                    Session.SendErrorMessage("Для этого действия требуются права адмнистратора!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void GetCurrentUserStatistics()
        {
            RefreshContext();

            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                int countOfCarsBought = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId && d.IsConfirmed == true).ToList().Count;
                decimal totalBoughts = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId && d.IsConfirmed == true).Sum(d => d.Amount);
                decimal averageCheck = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId && d.IsConfirmed == true).Average(d => d.Amount);
                decimal maxCheck = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId && d.IsConfirmed == true).Max(d => d.Amount);
                decimal minCheck = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId && d.IsConfirmed == true).Min(d => d.Amount);

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);

                _BinaryFormatter.Serialize(_NetworkStream, countOfCarsBought);
                _BinaryFormatter.Serialize(_NetworkStream, totalBoughts);
                _BinaryFormatter.Serialize(_NetworkStream, averageCheck);
                _BinaryFormatter.Serialize(_NetworkStream, maxCheck);
                _BinaryFormatter.Serialize(_NetworkStream, minCheck);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void GetDeals()
        {
            RefreshContext();

            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deals = AutodealersContext.Deal.ToList();
                    var cars = AutodealersContext.Car.ToList();
                    var users = AutodealersContext.User.ToList();

                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    _BinaryFormatter.Serialize(_NetworkStream, !_IsSearchModeEnabled ? deals : deals.Where(d => d.User.Username.StartsWith(_SearchUsername)).ToList());
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

        public void ConfirmDeal()
        {
            RefreshContext();

            var receivedDeal = (Deal)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (receivedDeal != null)
                    {
                        var cars = AutodealersContext.Car.ToList();
                        var users = AutodealersContext.User.ToList();
                        var autodealers = AutodealersContext.Autodealer.ToList();

                        var confirmDeal = AutodealersContext.Deal.FirstOrDefault(d => d.DealId == receivedDeal.DealId);

                        if (confirmDeal != null)
                        {
                            confirmDeal.IsConfirmed = !confirmDeal.IsConfirmed;
                            AutodealersContext.SaveChanges();

                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);

                            if (Session.StatisticsController.AddSaleToAutodealer(confirmDeal.Car, Session.AutodealerController.CurrentAutodealer) != true)
                            {
                                Session.SendErrorMessage("Ошибка добавления статистики!");
                            }
                            else
                            {
                                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                            }

                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                            _BinaryFormatter.Serialize(_NetworkStream, CreateCheck(confirmDeal));
                        }
                        else
                        {
                            Session.SendErrorMessage("Полученная сделка не найдена!");
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Полученная сделка пуста!");
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

        private string CreateCheck(Deal deal)
        {
            int length = (deal.Car.Autodealer.ToString()).PadLeft(20).PadRight(20).Length;

            length = length < 60 ? 60 : length; 

            string check = new string('-', length) + "\n" +
                           "ЧЕК ПРОДАЖИ\n".PadLeft((length + 11)/2) +
                           new string('-', length) + "\n" +
                           (deal.Car.Autodealer.ToString()).PadLeft((length + deal.Car.Autodealer.ToString().Length)/2) + "\n" +
                           new string('-', length) + "\n" +
                           "Марка: " + (deal.Car.Brand).PadLeft(length - 7) + "\n" +
                           "Модель: " + (deal.Car.Model).PadLeft(length - 8) + "\n" +
                           "Год выпуска: " + (deal.Car.YearOfIssue).ToString().PadLeft(length - 13) + "\n" +
                           "Тип кузова: " + Utilities.GetDescription(deal.Car.BodyType).PadLeft(length - 12) + "\n" +
                           "Объем двигателя: " + (deal.Car.EngineVolume.ToString() + " л").PadLeft(length - 17) + "\n" +
                           "Тип двигателя: " + Utilities.GetDescription(deal.Car.EngineType).PadLeft(length - 15) + "\n" +
                           "Тип КПП: " + Utilities.GetDescription(deal.Car.TransmissionType).PadLeft(length - 9) + "\n" +
                           "Тип привода: " + Utilities.GetDescription(deal.Car.WheelDriveType).PadLeft(length - 13) + "\n" +
                           "Пробег: " + (deal.Car.Mileage.ToString() + " км").PadLeft(length - 8) + "\n" +
                           "Цвет кузова: " + Utilities.GetDescription(deal.Car.BodyColor).PadLeft(length - 13) + "\n" +
                           "Материал салона: " + Utilities.GetDescription(deal.Car.InteriorMaterial).PadLeft(length - 17) + "\n" +
                           "Цвет салона: " + Utilities.GetDescription(deal.Car.InteriorColor).PadLeft(length - 13) + "\n" +
                           new string('-', length) + "\n" +
                           "Пользователь: " + deal.User.Username.PadRight(length - 14) + "\n" +
                           new string('-', length) + "\n" +
                           "Цена: " + (deal.Car.Price.ToString() + " $").PadRight(length - 6) + "\n" +
                           new string('-', length) + "\n" +
                           "Дата: " + DateTime.Now.ToString("D") + "\n" +
                           "Время: " + DateTime.Now.ToString("T") + "\n" +
                           new string('-', length) + "\n";
            return check;
        }

        public void Add()
        {
            RefreshContext();
             
            var receivedDeal = (Deal)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (Session.AutodealerController.CurrentAutodealer != null)
                    {
                        if (receivedDeal != null)
                        {
                            var user = AutodealersContext.User.FirstOrDefault(u => u.UserId == receivedDeal.UserId);

                            if (user != null)
                            {
                                var car = AutodealersContext.Car.FirstOrDefault(c => c.CarId == receivedDeal.CarId);

                                if (car != null)
                                {
                                    if (!car.IsSold)
                                    {
                                        car.IsSold = true;

                                        AutodealersContext.Deal.Add(new Deal 
                                        {
                                            UserId = receivedDeal.UserId,
                                            CarId = receivedDeal.CarId,
                                            Amount = car.Price
                                        });
                                        AutodealersContext.SaveChanges();

                                        _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                                    }
                                    else
                                    {
                                        Session.SendErrorMessage("Этот автомобиль уже продан!");
                                    }
                                }
                                else
                                {
                                    Session.SendErrorMessage("Такой автомобиль не найден!");
                                }
                            }
                            else
                            {
                                Session.SendErrorMessage("Такой пользователь не найден!");
                            }
                        }
                        else
                        {
                            Session.SendErrorMessage("Полученная сделка пуста!");
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Текущий автосалон не выбран!");
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
            
            var receivedDeal = (Deal)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (Session.AutodealerController.CurrentAutodealer != null)
                    {
                        if (receivedDeal != null)
                        {
                            var user = AutodealersContext.User.FirstOrDefault(u => u.UserId == receivedDeal.UserId);

                            if (user != null)
                            {
                                var car = AutodealersContext.Car.FirstOrDefault(c => c.CarId == receivedDeal.CarId);

                                if (car != null)
                                {
                                    var deal = AutodealersContext.Deal.FirstOrDefault(d => d.DealId == receivedDeal.DealId);

                                    if (deal != null)
                                    {
                                        if (receivedDeal.DealId == deal.DealId && receivedDeal.CarId == deal.CarId)
                                        {
                                            deal.UserId = user.UserId;
                                            deal.CarId = car.CarId;

                                            AutodealersContext.Deal.Update(deal);
                                            AutodealersContext.SaveChanges();

                                            _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                                        }
                                        else
                                        {
                                            if (!car.IsSold)
                                            {
                                                AutodealersContext.Car.FirstOrDefault(c => c.CarId == deal.CarId).IsSold = false;

                                                deal.UserId = user.UserId;
                                                deal.CarId = car.CarId;
                                                car.IsSold = true;

                                                AutodealersContext.Deal.Update(deal);
                                                AutodealersContext.SaveChanges();

                                                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                                            }
                                            else
                                            {
                                                Session.SendErrorMessage("Этот автомобиль уже продан!");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Session.SendErrorMessage("Сделка не найдена!");
                                    }
                                }
                                else
                                {
                                    Session.SendErrorMessage("Такой автомобиль не найден!");
                                }
                            }
                            else
                            {
                                Session.SendErrorMessage("Такой пользователь не найден!");
                            }
                        }
                        else
                        {
                            Session.SendErrorMessage("Полученная сделка пуста!");
                        }
                    }
                    else
                    {
                        Session.SendErrorMessage("Текущий автосалон не выбран!");
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

            var receivedDeal = (Deal)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deleteDeal = AutodealersContext.Deal.FirstOrDefault(d => d.DealId == receivedDeal.DealId);

                    if (deleteDeal != null)
                    {
                        var dealCar = AutodealersContext.Car.FirstOrDefault(c => c.CarId == deleteDeal.CarId);

                        dealCar.IsSold = false;
                        AutodealersContext.Remove(deleteDeal);
                        AutodealersContext.SaveChanges();

                        _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    }
                    else
                    {
                        Session.SendErrorMessage("Сделка не найдена!");
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
