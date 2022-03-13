using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface ICreditCard
    {
        public string CardNumber { get; }
        public string CVC { get; }
        public ICustomer Holder { get;}
        public IAccount BoundAccount { get;}
        public DateTime ExpirationDate { get;}

    }
}
