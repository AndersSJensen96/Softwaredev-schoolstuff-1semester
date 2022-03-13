using BankAPI.Models.Interfaces;
using BankAPI.Models.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Customers
{
    public class CompanyCustomer : Customer, ICompanyCustomer
    {
        public CompanyCustomer(string cvr, int id, string name, string email, int phone) : base(id, name, email, phone)
        {
            CVR = cvr;
        }
        public string CVR { get; private set; }
    }
}
