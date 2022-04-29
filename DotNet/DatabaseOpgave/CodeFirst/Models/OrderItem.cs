using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class OrderItem
	{
		public Order Order { get; set; }
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}
}
