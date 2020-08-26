using System;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Autodealers.Models;
using ServerUtilities;
using KursovayaServer.Controllers;

namespace KursovayaServer
{
    class Session
    {
        public TcpClient Client;

        public UserController UserController { get; }
        public AutodealerController AutodealerController { get; }
        public CarController CarController { get; }
        public DealsController DealsController { get; }
        public StatisticsController StatisticsController { get; }


        private NetworkStream _NetworkStream = null;
        private BinaryFormatter _BinaryFormatter = null;

        public Session(TcpClient client)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client), "Null client.");

            _BinaryFormatter = new BinaryFormatter();
            _NetworkStream = client.GetStream();

            UserController = new UserController(this);
            AutodealerController = new AutodealerController(this);
            CarController = new CarController(this);
            DealsController = new DealsController(this);
            StatisticsController = new StatisticsController(this);
        }

        public void Main()
        {
            try
            {
                while (true)
                {
                    var messageType = (MessageType)_BinaryFormatter.Deserialize(_NetworkStream);

                    if (messageType == MessageType.Action)
                    {
                        var actionType = (ActionType)_BinaryFormatter.Deserialize(_NetworkStream);

                        switch (actionType)
                        {
                            case ActionType.Authorize:
                                UserController.Authorize();
                                break;
                            case ActionType.Register:
                                UserController.Register();
                                break;
                            case ActionType.GetAutodealers:
                                AutodealerController.GetAutodealers();
                                break;
                            case ActionType.SetCurrentAutodealer:
                                AutodealerController.SetCurrentAutodealer();
                                break;
                            case ActionType.GetCars:
                                CarController.GetCars();
                                break;
                            case ActionType.GetCurrentUser:
                                UserController.GetCurrentUser();
                                break;
                            case ActionType.GetCurrentAutodealer:
                                AutodealerController.GetCurrentAutodealer();
                                break;
                            case ActionType.AddCar:
                                CarController.Add();
                                break;
                            case ActionType.DeleteCar:
                                CarController.Delete();
                                break;
                            case ActionType.EditCar:
                                CarController.Edit();
                                break;
                            case ActionType.SetCarFilter:
                                CarController.SetCarFilter();
                                break;
                            case ActionType.ResetCarFilter:
                                CarController.ResetCarFilter();
                                break;
                            case ActionType.GetUsers:
                                UserController.GetUsers();
                                break;
                            case ActionType.AddUser:
                                UserController.Add();
                                break;
                            case ActionType.BanUnbanUser:
                                UserController.BanUnbanUser();
                                break;
                            case ActionType.DeleteUser:
                                UserController.Delete();
                                break;
                            case ActionType.SetUserSearchData:
                                UserController.SetUserSearchData();
                                break;
                            case ActionType.EditUser:
                                UserController.Edit();
                                break;
                            case ActionType.GetDeals:
                                DealsController.GetDeals();
                                break;
                            case ActionType.ConfirmDeal:
                                DealsController.ConfirmDeal();
                                break;
                            case ActionType.DeleteDeal:
                                DealsController.Delete();
                                break;
                            case ActionType.AddDeal:
                                DealsController.Add();
                                break;
                            case ActionType.EditDeal:
                                DealsController.Edit();
                                break;
                            case ActionType.SetDealSearchData:
                                DealsController.SetDealSearchData();
                                break;
                            case ActionType.DeleteAutodealer:
                                AutodealerController.Delete();
                                break;
                            case ActionType.AddAutodealer:
                                AutodealerController.Add();
                                break;
                            case ActionType.EditAutodealer:
                                AutodealerController.Edit();
                                break;
                            case ActionType.SetAutodealerSearchData:
                                AutodealerController.SetAutodealerSearchData();
                                break;
                            case ActionType.GetCurrentAutodealerStatistics:
                                StatisticsController.GetCurrentAutodealerStatistics();
                                break;
                            case ActionType.GetNotSoldCars:
                                CarController.GetNotSoldCars();
                                break;
                            case ActionType.EditCurrentUserUsername:
                                UserController.EditCurrentUserUsername();
                                break;
                            case ActionType.EditCurrentUserPassword:
                                UserController.EditCurrentUserPassword();
                                break;
                            case ActionType.EditCurrentUserFirstname:
                                UserController.EditCurrentUserFirstname();
                                break;
                            case ActionType.EditCurrentUserSurname:
                                UserController.EditCurrentUserSurname();
                                break;
                            case ActionType.EditCurrentUserTelephone:
                                UserController.EditCurrentUserTelephone();
                                break;
                            case ActionType.BuyCar:
                                CarController.BuyCar();
                                break;
                            case ActionType.GetCurrentUserStatistics:
                                DealsController.GetCurrentUserStatistics();
                                break;
                            case ActionType.GetCurrentUserCars:
                                CarController.GetCurrentUserCars();
                                break;
                            case ActionType.GetUsersNotSuperUsers:
                                UserController.GetUsersNotSuperUsers();
                                break;
                        }
                    }
                }

            }
            catch (Exception) {}
            finally
            {
                if (_NetworkStream != null)
                {
                    _NetworkStream.Close();
                }
                if (Client != null)
                {
                    Client.Close();
                }
            }
        }

        public void SendErrorMessage(string error)
        {
            if (_NetworkStream.CanWrite && Client.Connected)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Error);
                _BinaryFormatter.Serialize(_NetworkStream, error);
            }
        }

        public void SendSuccessfulMessage(string message)
        {
            if (_NetworkStream.CanWrite && Client.Connected)
            {
                _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                _BinaryFormatter.Serialize(_NetworkStream, message);
            }
        }
    }
}
