using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PallesGavebod.Models
{
	public class DbContextIdentity : IdentityDbContext<IdentityUser>
	{
		public DbContextIdentity(DbContextOptions<DbContextIdentity> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<Gift> Gifts { get; set; }
	}
}
