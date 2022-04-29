using System;
using System.Collections.Generic;

namespace DatabaseOpgave.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string MerchantName { get; set; } = null!;
        public int AdminId { get; set; }
        public int CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User Admin { get; set; } = null!;
        public virtual Country CountryCodeNavigation { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
