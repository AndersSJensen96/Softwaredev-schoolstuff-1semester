using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PalleGavebod2.Models
{
	public class DbContextGifts : DbContext
	{
		public DbContextGifts(DbContextOptions<DbContextGifts> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<Gift> Gifts { get; set; }
	}
}
