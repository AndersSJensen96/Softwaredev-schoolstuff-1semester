using BankAPI.Models.Interfaces.TransactionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Transactions
{
    public class ExternalTransaction : Transaction, IExternalTransaction
    {
        public string ToRecipientAccountNumber { get; set; }
        public string ToRecipientRegisterNumber { get; set; }
    }
}
