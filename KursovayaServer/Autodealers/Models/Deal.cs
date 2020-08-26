using System;
using System.Collections.Generic;

namespace Autodealers.Models
{
    [Serializable]
    public partial class Deal
    {
        public int DealId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
    }
}
