using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Autodealers.Enums;
using ServerUtilities;

namespace Autodealers.Models
{
    [Serializable]
    public partial class Car
    {
        public Car()
        {
            Deal = new HashSet<Deal>();
        }

        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfIssue { get; set; }
        public BodyType BodyType { get; set; } 
        public float EngineVolume { get; set; }
        public EngineType EngineType { get; set; } 
        public TransmissionType TransmissionType { get; set; }
        public WheelDriveType WheelDriveType { get; set; } 
        public decimal Mileage { get; set; }
        public BodyColor BodyColor { get; set; } 
        public InteriorMaterial InteriorMaterial { get; set; }
        public InteriorColor InteriorColor { get; set; } 
        public decimal Price { get; set; }
        public decimal AllowanceOrDiscount { get; set; }
        public DateTime ReceiptDate { get; set; }
        public bool IsSold { get; set; }
        public int AutodealerId { get; set; }

        public virtual Autodealer Autodealer { get; set; }
        public virtual ICollection<Deal> Deal { get; set; }

        public override string ToString()
        {
            return CarId.ToString() + " - " + Brand + ", " + Model + " - " + Price + "$";
        }
    }
}
