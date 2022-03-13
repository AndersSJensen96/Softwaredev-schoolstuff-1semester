using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{

    public abstract class Transaction : ITransaction
    {
        public Transaction()
        {

        }

        public double TransferFee { get; set; }

        public double TransferAmount { get; set; }
    }
}
