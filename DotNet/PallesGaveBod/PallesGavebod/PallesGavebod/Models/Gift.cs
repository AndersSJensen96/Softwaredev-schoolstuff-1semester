using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PallesGavebod.Models
{
	public class Gift
	{
		[Key]
		public int GiftNumber { get; set; }
		[Required]
		[MinLength(5)]
		[MaxLength(100)]
		public string Title { get; set; }
		
		[MaxLength(300)]
		public string Description { get; set; }
		public DateTime CreationDate { get; set; }
		public bool BoyGift { get; set; }
		public bool GirlGift { get; set; }
	}
}
