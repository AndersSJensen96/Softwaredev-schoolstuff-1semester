using BankAPI.Models.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Customers
{
    public class PrivateCustomer : Customer, IPrivateCustomer
    {
        public PrivateCustomer(string cpr, int id, string name, string email, int phone) : base(id, name, email, phone)
        {
            CPR = cpr;
        }
        public string CPR { get; private set; }
    }
}
