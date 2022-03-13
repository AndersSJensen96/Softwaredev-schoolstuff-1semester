using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Accounts
{
    public class NormalAccount : Account
    {
        public NormalAccount(string accountNumber, string registerNumber) : base(accountNumber,registerNumber)
        {}

    }
}
