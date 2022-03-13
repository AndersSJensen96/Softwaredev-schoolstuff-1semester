using BankAPI.Models.Interfaces;
using BankAPI.Models.Interfaces.TransactionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Transactions
{
    public class InternalTransaction : Transaction, IInternalTransaction
    {
        public IAccount ToAccount { get; set; }
    }
}
