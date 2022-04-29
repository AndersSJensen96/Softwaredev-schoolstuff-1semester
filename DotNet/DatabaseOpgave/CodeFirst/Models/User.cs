using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class User
	{
		public int Id { get; set; }
		[MaxLength(200)]
		public string FullName { get; set; }
		[MaxLength(200)]
		public string Email { get; set; }
		[MaxLength(50)]
		public string Gender { get; set; }
		public DateTime DOB { get; set; }
		public Country Country { get; set; }
		public DateTime CreatedAt { get; set; }
		public List<Order> Orders { get; set; }
	}
}
