using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Accounts;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{
    public class Account : IAccount
    {
        public Account(string accountNumber, string registerNumber, AccountEnum type, int owner)
        {
            _balance = 0.0;
            AccountNumber = accountNumber;
            RegisterNumber = registerNumber;
            AccountType = type;
            Owner = owner;
        }

        private double _balance;

        public double Balance { get { return _balance; }}

        public AccountEnum AccountType { get; set; }

        public string AccountNumber { get; private set; }

        public string RegisterNumber { get; private set; }

        public int Owner { get; set; }
    }
}
