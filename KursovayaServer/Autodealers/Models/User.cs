using System;
using System.Collections.Generic;

namespace Autodealers.Models
{
    [Serializable]
    public partial class User
    {
        public User()
        {
            Deal = new HashSet<Deal>();
            Userautodealer = new HashSet<Userautodealer>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Telephone { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public bool SuperUser { get; set; }
        public bool BanStatus { get; set; }

        public virtual ICollection<Deal> Deal { get; set; }
        public virtual ICollection<Userautodealer> Userautodealer { get; set; }
    }
}
