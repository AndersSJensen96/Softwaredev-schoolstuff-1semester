using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{
    public abstract class Account : IAccount
    {
        public Account(string accountNumber, string registerNumber)
        {
            _balance = 0.0;
            AccountNumber = accountNumber;
            RegisterNumber = registerNumber;
        }

        private double _balance;

        public double Balance { get { return _balance; }}

        public string AccountNumber { get; private set; }

        public string RegisterNumber { get; private set; }
    }
}
