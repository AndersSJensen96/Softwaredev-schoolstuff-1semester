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
        public CompanyCustomer(string cvr, string name, string email, int phone, CustomerType customerType) : base(name, email, phone, customerType)
        {
            CVR = cvr;
        }
        public string CVR { get; private set; }
    }
}
