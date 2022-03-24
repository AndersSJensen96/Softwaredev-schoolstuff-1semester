using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.CreditCards;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models.Customers
{
    public class Customer : ICustomer
    {
		public Customer()
		{

		}
        public Customer(string name, string email, int phone, CustomerType customerType)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CustomerType = customerType;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }
		public CustomerType CustomerType { get; set; }

		public List<Account> Accounts { get;}

        public List<CreditCard> creditCards { get; }
    }
}
