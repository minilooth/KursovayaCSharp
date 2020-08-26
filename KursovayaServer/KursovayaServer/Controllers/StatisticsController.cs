using Autodealers.Enums;
using Autodealers.Models;
using ServerUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace KursovayaServer.Controllers
{
    class StatisticsController : IController
    {
        public Session Session { get; set; } = null;
        public AutodealersContext AutodealersContext { get; set; } = null;

        private NetworkStream _NetworkStream = null;
        private BinaryFormatter _BinaryFormatter = null;

        public StatisticsController(Session session)
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

        public List<Statistics> GetAutodealerStatisticsForSixMonth()
        {
            var statistics = AutodealersContext.Statistics.Where(s => s.AutodealerId == Session.AutodealerController.CurrentAutodealer.AutodealerId).ToList();
            Month currentMonth = (Month)DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            var sendStatistics = new List<Statistics>();

            while (sendStatistics.Count != 6 && sendStatistics.Count != statistics.Count - 1)
            {
                if (currentMonth != Month.January)
                {
                    currentMonth--;
                }
                else
                {
                    currentYear--;
                    currentMonth = Month.December;
                }

                var statisticsItem = statistics.FirstOrDefault(s => s.Month == currentMonth && s.Year == currentYear);

                if (statisticsItem != null)
                {
                    sendStatistics.Add(statisticsItem);
                }
            }
            return sendStatistics;
        }

        public void GetCurrentAutodealerStatistics()
        {
            RefreshContext();
            if (Session.UserController.IsAuthorized)
            {
                if (Session.AutodealerController.CurrentAutodealer != null)
                {
                    if (Session.UserController.CurrentUser.SuperUser)
                    {
                        _BinaryFormatter.Serialize(_NetworkStream, MessageType.Success);
                        _BinaryFormatter.Serialize(_NetworkStream, GetAutodealerStatisticsForSixMonth());
                    }
                    else
                    {
                        Session.SendErrorMessage("Для этого действия требуются права администратора!");
                    }
                }
                else
                {
                    Session.SendErrorMessage("Текущий автосалон не выбран!");
                }
            }
            else
            {
                Session.SendErrorMessage("Для этого действия требуется авторизация!");
            }
            RefreshContext();
        }

        public void AddVisitToAutodealer(Autodealer autodealer)
        {
            RefreshContext();

            var autodealerCurrentMonthStatistics = AutodealersContext.Statistics.ToList().FirstOrDefault(s => s.Month == (Month)DateTime.Now.Month && s.Year == DateTime.Now.Year && s.AutodealerId == autodealer.AutodealerId);

            if (autodealerCurrentMonthStatistics != null)
            {
                autodealerCurrentMonthStatistics.CountOfClients++;
                AutodealersContext.SaveChanges();
            }
            RefreshContext();
        }

        public bool AddSaleToAutodealer(Car car, Autodealer autodealer)
        {
            RefreshContext();

            var autodealerCurrentMonthStatistics = AutodealersContext.Statistics.ToList().FirstOrDefault(s => s.Month == (Month)DateTime.Now.Month && s.Year == DateTime.Now.Year && s.AutodealerId == autodealer.AutodealerId);

            if (autodealerCurrentMonthStatistics != null)
            {
                autodealerCurrentMonthStatistics.CountOfCarsSold++;
                autodealerCurrentMonthStatistics.TotalSales += car.Price;
                autodealerCurrentMonthStatistics.Profit += car.AllowanceOrDiscount; 

                AutodealersContext.SaveChanges();

                RefreshContext();

                return true;
            }
            RefreshContext();

            return false;
        }

        public void CheckAndCreateNewStatistic()
        {
            RefreshContext();

            var allAutodealers = AutodealersContext.Autodealer.ToList();
            var allStatistics = AutodealersContext.Statistics.ToList();

            foreach (var a in allAutodealers)
            {
                var statistics = allStatistics.FirstOrDefault(s => s.Month == (Month)DateTime.Now.Month && s.Year == DateTime.Now.Year && s.AutodealerId == a.AutodealerId);

                if (statistics == null)
                {
                    Month lastMonth;
                    int lastYear = 0;

                    if (DateTime.Now.Month < 2)
                    {
                        lastYear = DateTime.Now.Year - 1;
                        lastMonth = Month.December;
                    }
                    else
                    {
                        lastYear = DateTime.Now.Year;
                        lastMonth = (Month)(DateTime.Now.Month - 1);
                    }

                    var lastStatistics = allStatistics.FirstOrDefault(s => s.Month == lastMonth && s.Year == lastYear && s.AutodealerId == a.AutodealerId);

                    int lastCountOfCarsSold = 0;
                    decimal lastProfit = 0;

                    if (lastStatistics != null)
                    {
                        lastCountOfCarsSold = lastStatistics.CountOfCarsSold;
                        lastProfit = lastStatistics.Profit;
                    }

                    AutodealersContext.Statistics.Add(new Statistics
                    {
                        AutodealerId = a.AutodealerId,
                        Month = (Month)DateTime.Now.Month,
                        Year = DateTime.Now.Year,
                        ExpectedCountOfCarsSold = Convert.ToInt32(lastCountOfCarsSold * 1.2),
                        ExpectedProfit = lastProfit * 1.2M
                    });
                    AutodealersContext.SaveChanges();
                }
            }
            RefreshContext();
        }

        public void Add()
        {

        }

        public void Edit()
        {

        }

        public void Delete()
        {

        }
    }
}
