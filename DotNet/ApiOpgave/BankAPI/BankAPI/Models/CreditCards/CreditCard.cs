using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;

namespace BankAPI.Models
{
    public abstract class CreditCard : ICreditCard
    {
        public CreditCard(string cardNumber, string cvc, ICustomer holder, IAccount account, DateTime expire)
        {
            CardNumber = cardNumber;
            CVC = cvc;
            Holder = holder;
            BoundAccount = account;
            ExpirationDate = expire;
        }

        public string CardNumber { get; private set; }

        public string CVC { get; private set; }

        public ICustomer Holder { get; private set; }

        public IAccount BoundAccount { get; private set; }

        public DateTime ExpirationDate { get; private set; }
    }
}
