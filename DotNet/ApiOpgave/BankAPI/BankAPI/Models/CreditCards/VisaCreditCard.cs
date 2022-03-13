using BankAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.CreditCards
{
    public class VisaCreditCard : CreditCard
    {
        public VisaCreditCard(string cardNumber, string cvc, ICustomer holder, IAccount account, DateTime expire) : base (cardNumber, cvc, holder, account, expire)
        {}
    }
}
