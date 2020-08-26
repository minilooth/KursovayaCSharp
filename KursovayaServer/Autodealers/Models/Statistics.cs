using System;
using Autodealers.Enums;
using System.Collections.Generic;

namespace Autodealers.Models
{
    [Serializable]
    public partial class Statistics
    {
        public int StatisticsId { get; set; }
        public Month Month { get; set; }
        public int Year { get; set; }
        public int CountOfClients { get; set; }
        public int ExpectedCountOfCarsSold { get; set; }
        public int CountOfCarsSold { get; set; }
        public decimal TotalSales { get; set; }
        public decimal ExpectedProfit { get; set; }
        public decimal Profit { get; set; }
        public int AutodealerId { get; set; }

        public virtual Autodealer Autodealer { get; set; }
    }
}
