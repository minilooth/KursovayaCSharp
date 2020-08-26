using Autodealers.Enums;
using Autodealers.Models;
using ServerUtilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace KursovayaServer.Controllers
{
    class CarController : IController
    {
        public Session Session { get; set; } = null;
        public AutodealersContext AutodealersContext { get; set; } = null;

        private NetworkStream _NetworkStream = null;
        private BinaryFormatter _BinaryFormatter = null;

        public bool IsFilteringEnabled { get; set; } = false;

        #region Filtering

        private string _BrandFilter = null;
        private string _ModelFilter = null;
        private int _YearOfIssueMinFilter = 1975;
        private int _YearOfIssueMaxFilter = 2020;
        private BodyType _BodyTypeFilter = 0;
        private float _EngineVolumeMinFilter = 0.8f;
        private float _EngineVolumeMaxFilter = 10.0f;
        private EngineType _EngineTypeFilter = 0;
        private TransmissionType _TransmissionTypeFilter = 0;
        private WheelDriveType _WheelDriveTypeFilter = 0;
        private decimal _MileageMinFilter = 0;
        private decimal _MileageMaxFilter = 1000000M;
        private BodyColor _BodyColorFilter = 0;
        private InteriorMaterial _InteriorMaterialFilter = 0;
        private InteriorColor _InteriorColorFilter = 0;
        private decimal _PriceMinFilter = 0;
        private decimal _PriceMaxFilter = 1000000M;

        #endregion

        public CarController(Session session)
        {
            Session = session ?? throw new ArgumentNullException(nameof(session), "Сессия не найдена.");
            AutodealersContext = new AutodealersContext();

            _NetworkStream = Session.Client.GetStream();
            _BinaryFormatter = new BinaryFormatter();
        }

        public void RefreshContext()
        {
            AutodealersContext = new AutodealersContext();
        }

        public void GetCars()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deals = AutodealersContext.Deal.ToList();

                    _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    _BinaryFormatter.Serialize(_NetworkStream, !IsFilteringEnabled ? AutodealersContext.Car.Where(c => c.AutodealerId == Session.AutodealerController.CurrentAutodealer.AutodealerId).ToList() :
                                                                                        FilterCars(AutodealersContext.Car.Where(c => c.AutodealerId == Session.AutodealerController.CurrentAutodealer.AutodealerId).ToList()));
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

        public void GetNotSoldCars()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                var deals = AutodealersContext.Deal.ToList();

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                _BinaryFormatter.Serialize(_NetworkStream, !IsFilteringEnabled ? AutodealersContext.Car.Where(c => c.AutodealerId == Session.AutodealerController.CurrentAutodealer.AutodealerId && c.IsSold == false).ToList() :
                                                                                    FilterCars(AutodealersContext.Car.Where(c => c.AutodealerId == Session.AutodealerController.CurrentAutodealer.AutodealerId && c.IsSold == false).ToList()));
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void GetCurrentUserCars()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized && Session.AutodealerController.CurrentAutodealer != null)
            {
                var deals = AutodealersContext.Deal.Where(d => d.UserId == Session.UserController.CurrentUser.UserId).ToList();
                var cars = AutodealersContext.Car.ToList();
                List<Car> userCars = new List<Car>();

                foreach(var d in deals)
                {
                    userCars.Add(d.Car);
                }

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                _BinaryFormatter.Serialize(_NetworkStream, userCars);
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        private List<Car> FilterCars(List<Car> cars)
        {
            if (!String.IsNullOrEmpty(_BrandFilter))
            {
                cars = cars.Where(c => c.Brand.StartsWith(_BrandFilter, StringComparison.CurrentCultureIgnoreCase) == true).ToList();
            }
            if (!String.IsNullOrEmpty(_ModelFilter))
            {
                cars = cars.Where(c => c.Model.StartsWith(_ModelFilter, StringComparison.CurrentCultureIgnoreCase) == true).ToList();
            }
            if (_YearOfIssueMinFilter != 1975)
            {
                cars = cars.Where(c => c.YearOfIssue >= _YearOfIssueMinFilter).ToList();
            }
            if (_YearOfIssueMaxFilter != 2020)
            {
                cars = cars.Where(c => c.YearOfIssue <= _YearOfIssueMaxFilter).ToList();
            }
            if (_BodyTypeFilter != 0)
            {
                cars = cars.Where(c => c.BodyType == _BodyTypeFilter).ToList();
            }
            if (_EngineVolumeMinFilter != 0.8f)
            {
                cars = cars.Where(c => c.EngineVolume >= _EngineVolumeMinFilter).ToList();
            }
            if (_EngineVolumeMaxFilter != 10.0f)
            {
                cars = cars.Where(c => c.EngineVolume <= _EngineVolumeMaxFilter).ToList();
            }
            if (_EngineTypeFilter != 0)
            {
                cars = cars.Where(c => c.EngineType == _EngineTypeFilter).ToList();
            }
            if (_TransmissionTypeFilter != 0)
            {
                cars = cars.Where(c => c.TransmissionType == _TransmissionTypeFilter).ToList();
            }
            if (_WheelDriveTypeFilter != 0)
            {
                cars = cars.Where(c => c.WheelDriveType == _WheelDriveTypeFilter).ToList();
            }
            if (_MileageMinFilter != 0)
            {
                cars = cars.Where(c => c.Mileage >= _MileageMinFilter).ToList();
            }
            if (_MileageMaxFilter != 1000000M)
            {
                cars = cars.Where(c => c.Mileage <= _MileageMaxFilter).ToList();
            }
            if (_BodyColorFilter != 0)
            {
                cars = cars.Where(c => c.BodyColor == _BodyColorFilter).ToList();
            }
            if (_InteriorMaterialFilter != 0)
            {
                cars = cars.Where(c => c.InteriorMaterial == _InteriorMaterialFilter).ToList();
            }
            if (_InteriorColorFilter != 0)
            {
                cars = cars.Where(c => c.InteriorColor == _InteriorColorFilter).ToList();
            }
            if (_PriceMinFilter != 0)
            {
                cars = cars.Where(c => c.Price >= _PriceMinFilter).ToList();
            }
            if (_PriceMaxFilter != 1000000M)
            {
                cars = cars.Where(c => c.Price <= _PriceMaxFilter).ToList();
            }
            return cars;
        }

        public void SetCarFilter()
        {
            RefreshContext();

            _BrandFilter = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            _ModelFilter = (string)_BinaryFormatter.Deserialize(_NetworkStream);
            _YearOfIssueMinFilter = (int)_BinaryFormatter.Deserialize(_NetworkStream);
            _YearOfIssueMaxFilter = (int)_BinaryFormatter.Deserialize(_NetworkStream);
            _BodyTypeFilter = (BodyType)_BinaryFormatter.Deserialize(_NetworkStream);
            _EngineVolumeMinFilter = (float)_BinaryFormatter.Deserialize(_NetworkStream);
            _EngineVolumeMaxFilter = (float)_BinaryFormatter.Deserialize(_NetworkStream);
            _EngineTypeFilter = (EngineType)_BinaryFormatter.Deserialize(_NetworkStream);
            _TransmissionTypeFilter = (TransmissionType)_BinaryFormatter.Deserialize(_NetworkStream);
            _WheelDriveTypeFilter = (WheelDriveType)_BinaryFormatter.Deserialize(_NetworkStream);
            _MileageMinFilter = (decimal)_BinaryFormatter.Deserialize(_NetworkStream);
            _MileageMaxFilter = (decimal)_BinaryFormatter.Deserialize(_NetworkStream);
            _BodyColorFilter = (BodyColor)_BinaryFormatter.Deserialize(_NetworkStream);
            _InteriorMaterialFilter = (InteriorMaterial)_BinaryFormatter.Deserialize(_NetworkStream);
            _InteriorColorFilter = (InteriorColor)_BinaryFormatter.Deserialize(_NetworkStream);
            _PriceMinFilter = (decimal)_BinaryFormatter.Deserialize(_NetworkStream);
            _PriceMaxFilter = (decimal)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                IsFilteringEnabled = true;
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }

            RefreshContext();
        }

        public void ResetCarFilter()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized)
            {
                _BrandFilter = null;
                _ModelFilter = null;
                _YearOfIssueMinFilter = 1975;
                _YearOfIssueMaxFilter = 2020;
                _BodyTypeFilter = 0;
                _EngineVolumeMinFilter = 0.8f;
                _EngineVolumeMaxFilter = 10.0f;
                _EngineTypeFilter = 0;
                _TransmissionTypeFilter = 0;
                _WheelDriveTypeFilter = 0;
                _MileageMinFilter = 0;
                _MileageMaxFilter = 1000000M;
                _BodyColorFilter = 0;
                _InteriorMaterialFilter = 0;
                _InteriorColorFilter = 0;
                _PriceMinFilter = 0;
                _PriceMaxFilter = 1000000M;

                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                IsFilteringEnabled = false;
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        private decimal CalcuateOdd()
        {
            decimal ratioSum = 0.0M;
            decimal powSum = 0.0M;

            var statistics = Session.StatisticsController.GetAutodealerStatisticsForSixMonth();

            if (statistics.Count == 0 || statistics == null)
            {
                return 0.0M;
            }

            foreach (var s in statistics)
            {
                ratioSum += s.ExpectedProfit / s.Profit;
            }

            decimal averageOdd = ratioSum / Convert.ToDecimal(statistics.Count);

            foreach (var s in statistics)
            {
                powSum += Convert.ToDecimal(Math.Pow(Convert.ToDouble(s.ExpectedProfit) / Convert.ToDouble(s.Profit) - Convert.ToDouble(averageOdd), 2.0));
            }

            return Convert.ToDecimal((1.0 / Convert.ToDouble((statistics.Count - 1)) * Convert.ToDouble(powSum)));
        }

        public void Add()
        {
            RefreshContext();
             
            var car = (Car)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    if (Session.AutodealerController.CurrentAutodealer != null)
                    {
                        if (car != null)
                        {
                            if (String.IsNullOrEmpty(car.Brand))
                            {
                                Session.SendErrorMessage("Марка не установлена!");
                                return;
                            }
                            if (!Regex.IsMatch(car.Brand, "^[A-Za-zА-Яа-я- ]+$"))
                            {
                                Session.SendErrorMessage("Марка введена некорректно!");
                                return;
                            }
                            if (car.Brand.Length > 30)
                            {
                                Session.SendErrorMessage("Марка должна состоять максимум из 30 символов!");
                                return;
                            }
                            if (String.IsNullOrEmpty(car.Model))
                            {
                                Session.SendErrorMessage("Модель не установлена!");
                                return;
                            }
                            if (!Regex.IsMatch(car.Model, "^[A-Za-zА-Яа-я0-9- ]+$"))
                            {
                                Session.SendErrorMessage("Модель введена некорректно!");
                                return;
                            }
                            if (car.Model.Length > 30)
                            {
                                Session.SendErrorMessage("Модель должна состоять максимум из 30 символов!");
                                return;
                            }
                            if (car.BodyType == 0)
                            {
                                Session.SendErrorMessage("Тип кузова не выбран!");
                                return;
                            }
                            if (car.EngineType == 0)
                            {
                                Session.SendErrorMessage("Тип двигателя не выбран!");
                                return;
                            }
                            if (car.TransmissionType == 0)
                            {
                                Session.SendErrorMessage("Тип КПП не выбран!");
                                return;
                            }
                            if (car.WheelDriveType == 0)
                            {
                                Session.SendErrorMessage("Тип привода не выбран!");
                                return;
                            }
                            if (car.BodyColor == 0)
                            {
                                Session.SendErrorMessage("Цвет кузова не выбран!");
                                return;
                            }
                            if (car.InteriorMaterial == 0)
                            {
                                Session.SendErrorMessage("Материал салона не выбран!");
                                return;
                            }
                            if (car.InteriorColor == 0)
                            {
                                Session.SendErrorMessage("Цвет салона не выбран!");
                                return;
                            }
                            if (car.Price < 1)
                            {
                                Session.SendErrorMessage("Цена должна быть больше нуля!");
                                return;
                            }

                            car.AutodealerId = Session.AutodealerController.CurrentAutodealer.AutodealerId;
                            car.Brand = Char.ToUpper(car.Brand[0]) + car.Brand.Substring(1);
                            car.Model = Char.ToUpper(car.Model[0]) + car.Model.Substring(1);
                            car.AllowanceOrDiscount = car.Price * CalcuateOdd();
                            car.Price += car.AllowanceOrDiscount;

                            AutodealersContext.Car.Add(car);
                            AutodealersContext.SaveChanges();

                            Session.SendSuccessfulMessage($"Надбавка к цене - {car.AllowanceOrDiscount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}\nОкончательная цена - {car.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
                        }
                        else
                        {
                            Session.SendErrorMessage("Автомобиль не найден!");
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
            
            var receivedCar = (Car)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var editCar = AutodealersContext.Car.FirstOrDefault(c => c.CarId == receivedCar.CarId);

                    if (editCar != null)
                    {
                        if (String.IsNullOrEmpty(receivedCar.Brand))
                        {
                            Session.SendErrorMessage("Марка не установлена!");
                            return;
                        }
                        if (!Regex.IsMatch(receivedCar.Brand, "^[A-Za-zА-Яа-я- ]+$"))
                        {
                            Session.SendErrorMessage("Марка введена некорректно!");
                            return;
                        }
                        if (receivedCar.Brand.Length > 30)
                        {
                            Session.SendErrorMessage("Марка должна состоять максимум из 30 символов!");
                            return;
                        }
                        if (String.IsNullOrEmpty(receivedCar.Model))
                        {
                            Session.SendErrorMessage("Модель не установлена!");
                            return;
                        }
                        if (!Regex.IsMatch(receivedCar.Model, "^[A-Za-zА-Яа-я0-9- ]+$"))
                        {
                            Session.SendErrorMessage("Модель введена некорректно!");
                            return;
                        }
                        if (receivedCar.Model.Length > 30)
                        {
                            Session.SendErrorMessage("Модель должна состоять максимум из 30 символов!");
                            return;
                        }
                        if (receivedCar.BodyType == 0)
                        {
                            Session.SendErrorMessage("Тип кузова не выбран!");
                            return;
                        }
                        if (receivedCar.EngineType == 0)
                        {
                            Session.SendErrorMessage("Тип двигателя не выбран!");
                            return;
                        }
                        if (receivedCar.TransmissionType == 0)
                        {
                            Session.SendErrorMessage("Тип КПП не выбран!");
                            return;
                        }
                        if (receivedCar.WheelDriveType == 0)
                        {
                            Session.SendErrorMessage("Тип привода не выбран!");
                            return;
                        }
                        if (receivedCar.BodyColor == 0)
                        {
                            Session.SendErrorMessage("Цвет кузова не выбран!");
                            return;
                        }
                        if (receivedCar.InteriorMaterial == 0)
                        {
                            Session.SendErrorMessage("Материал салона не выбран!");
                            return;
                        }
                        if (receivedCar.InteriorColor == 0)
                        {
                            Session.SendErrorMessage("Цвет салона не выбран!");
                            return;
                        }
                        if (receivedCar.Price < 1)
                        {
                            Session.SendErrorMessage("Цена должна быть больше нуля!");
                            return;
                        }

                        editCar.Model = receivedCar.Model;
                        editCar.YearOfIssue = receivedCar.YearOfIssue;
                        editCar.BodyType = receivedCar.BodyType;
                        editCar.EngineVolume = receivedCar.EngineVolume;
                        editCar.EngineType = receivedCar.EngineType;
                        editCar.TransmissionType = receivedCar.TransmissionType;
                        editCar.WheelDriveType = receivedCar.WheelDriveType;
                        editCar.Mileage = receivedCar.Mileage;
                        editCar.BodyColor = receivedCar.BodyColor;
                        editCar.InteriorMaterial = receivedCar.InteriorMaterial;
                        editCar.InteriorColor = receivedCar.InteriorColor;
                        editCar.Price = receivedCar.Price;

                        editCar.Brand = Char.ToUpper(receivedCar.Brand[0]) + receivedCar.Brand.Substring(1);
                        editCar.Model = Char.ToUpper(receivedCar.Model[0]) + receivedCar.Model.Substring(1);
                        editCar.AllowanceOrDiscount = editCar.Price * CalcuateOdd();
                        editCar.Price += editCar.AllowanceOrDiscount;

                        AutodealersContext.Car.Update(editCar);
                        AutodealersContext.SaveChanges();

                        Session.SendSuccessfulMessage($"Надбавка к цене - {editCar.AllowanceOrDiscount.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}\nОкончательная цена - {editCar.Price.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))}");
                    }
                    else
                    {
                        Session.SendErrorMessage("Автомобиль не найден!");
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

            var receivedCar = (Car)_BinaryFormatter.Deserialize(_NetworkStream);
                
            if (Session.UserController.IsAuthorized)
            {
                if (Session.UserController.CurrentUser.SuperUser)
                {
                    var deleteCar = AutodealersContext.Car.FirstOrDefault(c => c.CarId == receivedCar.CarId);

                    if (deleteCar != null)
                    {
                        AutodealersContext.Car.Remove(deleteCar);
                        AutodealersContext.SaveChanges();
                     
                        _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                    }
                    else
                    {
                        Session.SendErrorMessage("Автомобиль не найден!");
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
        public void BuyCar()
        {
            RefreshContext();

            var receivedCar = (Car)_BinaryFormatter.Deserialize(_NetworkStream);

            if (Session.UserController.IsAuthorized)
            {
                if (receivedCar != null)
                {
                    var boughtCar = AutodealersContext.Car.FirstOrDefault(c => c.CarId == receivedCar.CarId);

                    if (boughtCar != null)
                    {
                        var deal = new Deal();
                        deal.CarId = boughtCar.CarId;
                        deal.Amount = boughtCar.Price;
                        deal.UserId = Session.UserController.CurrentUser.UserId;

                        boughtCar.IsSold = true;

                        AutodealersContext.Deal.Add(deal);
                        AutodealersContext.SaveChanges();

                        Session.SendSuccessfulMessage("Вы успешно приобрели автомобиль!");
                    }
                    else
                    {
                        Session.SendErrorMessage("Автомобиль не найден!");
                    }
                }
                else
                {
                    Session.SendErrorMessage("Ошибка получения!");
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
