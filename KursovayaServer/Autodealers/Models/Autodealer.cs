using System;
using System.Collections.Generic;

namespace Autodealers.Models
{
    [Serializable]
    public partial class Autodealer
    {
        public Autodealer()
        {
            Car = new HashSet<Car>();
            Statistics = new HashSet<Statistics>();
            Userautodealer = new HashSet<Userautodealer>();
        }

        public int AutodealerId { get; set; }
        public string Title { get; set; }
        public string WorkingHours { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Statistics> Statistics { get; set; }
        public virtual ICollection<Userautodealer> Userautodealer { get; set; }

        public override string ToString()
        {
            if (Address == null && WorkingHours == null)
            {
                return Title + " - " + City;
            }
            else if (WorkingHours == null)
            {
                return Title + " - " + City + ", " + Address;
            }
            else if (Address == null)
            {
                return Title + " - " + City + " - " + WorkingHours;
            }
            else
            {
                return Title + " - " + City + ", " + Address + " - " + WorkingHours;
            }
        }
    }
}
