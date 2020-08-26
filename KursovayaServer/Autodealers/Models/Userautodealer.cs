using System;
using System.Collections.Generic;

namespace Autodealers.Models
{
    [Serializable]
    public partial class Userautodealer
    {
        public int UserId { get; set; }
        public int AutodealerId { get; set; }

        public virtual Autodealer Autodealer { get; set; }
        public virtual User User { get; set; }
    }
}
