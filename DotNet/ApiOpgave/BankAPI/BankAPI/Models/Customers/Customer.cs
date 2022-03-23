using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{
    public abstract class Customer : ICustomer
    {
        public Customer(string name, string email, int phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public List<IAccount> Accounts { get;}

        public List<ICreditCard> creditCards { get; }
    }
}
