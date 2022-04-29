using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class Order
	{
		public int Id { get; set; }
		public User User { get; set; }
		[MaxLength(50)]
		public string Status { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
