using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
	public class CodeFirstContext : DbContext
	{
		public CodeFirstContext() : base()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=CodeFirst;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OrderItem>().HasNoKey();
		}

		public DbSet<Country> Countries { get; set; }
		public DbSet<Merchant> Merchants { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
	}
}
