using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Accounts
{
    public class SalaryAccount : Account
    {
        public SalaryAccount(string accountNumber, string registerNumber) : base(accountNumber, registerNumber)
        { }
    }
}
