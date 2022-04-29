using System;
using System.Collections.Generic;

namespace DatabaseOpgave.Models
{
    public partial class User
    {
        public User()
        {
            Merchants = new HashSet<Merchant>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Country CountryCodeNavigation { get; set; } = null!;
        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
