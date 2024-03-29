﻿using BankAPI.Models.Interfaces.CustomerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Customers
{
    public class PrivateCustomer : Customer, IPrivateCustomer
    {
        public PrivateCustomer(string cpr,string name, string email, int phone, CustomerType customerType) : base(name, email, phone, customerType)
        {
            CPR = cpr;
        }
        public string CPR { get; private set; }
    }
}
