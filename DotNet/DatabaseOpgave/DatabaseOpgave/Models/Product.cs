using System;
using System.Collections.Generic;

namespace DatabaseOpgave.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int MerchantId { get; set; }
        public float Price { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual Merchant Merchant { get; set; } = null!;
    }
}
