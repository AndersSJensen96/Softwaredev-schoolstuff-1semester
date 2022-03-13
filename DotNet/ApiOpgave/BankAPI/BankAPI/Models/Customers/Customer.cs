using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{
    public abstract class Customer : ICustomer
    {
        public Customer(int id, string name, string email, int phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }

        private int _id;

        private string _name;

        private string _email;

        private int _phone;

        private List<IAccount> _accounts;

        private List<ICreditCard> _creditCards;

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get{ return _email; }
            set { _email = value; }
        }

        public int Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public List<IAccount> Accounts
        {
            get { return _accounts; }
        }

        public List<ICreditCard> creditCards { get { return _creditCards; } }
    }
}
