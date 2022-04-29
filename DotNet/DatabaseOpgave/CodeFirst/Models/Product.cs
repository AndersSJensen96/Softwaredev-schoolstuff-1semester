using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class Product
	{
		public int Id { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
		public Merchant Merchant { get; set; }
		public float Price { get; set; }
		[MaxLength(50)]
		public string Status { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
