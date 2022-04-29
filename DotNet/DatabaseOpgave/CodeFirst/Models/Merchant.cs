using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class Merchant
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string MerchantName { get; set; }
		public User AdminID { get; set; }
		public Country Country { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<Product> Products { get; set; }
	}
}
