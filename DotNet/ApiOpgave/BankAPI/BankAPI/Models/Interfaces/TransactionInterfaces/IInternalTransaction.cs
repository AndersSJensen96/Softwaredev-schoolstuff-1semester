using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces.TransactionInterfaces
{
    public interface IInternalTransaction
    {
        public IAccount ToAccount { get; set; }
    }
}
