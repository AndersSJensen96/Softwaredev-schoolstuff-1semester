using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Models
{
	public class Country
	{
		[Key]
		public int Code { get; set; }
		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(100)]
		public string ContinentName { get; set; }
	}
}
