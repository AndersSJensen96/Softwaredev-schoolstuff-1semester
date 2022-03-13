using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface ITransaction
    {
        public double TransferFee { get; set; }
        public double TransferAmount { get; set; }
    }
}
