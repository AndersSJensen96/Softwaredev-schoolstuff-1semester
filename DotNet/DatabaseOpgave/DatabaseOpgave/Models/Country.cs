using System;
using System.Collections.Generic;

namespace DatabaseOpgave.Models
{
    public partial class Country
    {
        public Country()
        {
            Merchants = new HashSet<Merchant>();
            Users = new HashSet<User>();
        }

        public int Code { get; set; }
        public string Name { get; set; } = null!;
        public string ContinentName { get; set; } = null!;

        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
