using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface IAccount
    {
        public string AccountNumber { get;}
        public string RegisterNumber { get;}
        public double Balance { get; }

    }
}
