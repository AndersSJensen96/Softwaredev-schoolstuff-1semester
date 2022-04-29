using System;
using System.Collections.Generic;

namespace DatabaseOpgave.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
