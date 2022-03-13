using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces.TransactionInterfaces
{
    public interface IExternalTransaction
    {
        public string ToRecipientAccountNumber { get; set; }

        public string ToRecipientRegisterNumber { get; set; }
    }
}
