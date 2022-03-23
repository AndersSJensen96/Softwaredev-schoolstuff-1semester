﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Data
{
    public class BankAPIContext : DbContext
    {
        public BankAPIContext (DbContextOptions<BankAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BankAPI.Models.Account> Account { get; set; }
    }
}
