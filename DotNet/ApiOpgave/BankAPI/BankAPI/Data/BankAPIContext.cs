using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using BankAPI.Models.Customers;
using BankAPI.Models.CreditCards;

namespace BankAPI.Data
{
    public class BankAPIContext : DbContext
    {
        public BankAPIContext (DbContextOptions<BankAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BankAPI.Models.Account> Account { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        

        public DbSet<BankAPI.Models.Customers.Customer> Customer { get; set; }
        

        public DbSet<BankAPI.Models.CreditCards.CreditCard> CreditCard { get; set; }
    }
}
