using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Interfaces;
using BankAPI.Models.Customers;

namespace BankAPI.Models.CreditCards
{
    public class CreditCard : ICreditCard
    {
		public CreditCard()
		{

		}
        public CreditCard(string cardNumber, string cvc, Customer holder, Account account, DateTime expire, CreditCardType creditCardType)
        {
            CardNumber = cardNumber;
            CVC = cvc;
            Holder = holder;
            BoundAccount = account;
            ExpirationDate = expire;
            CardType = creditCardType;
        }
        public int Id { get; set; }

        public string CardNumber { get; private set; }

        public string CVC { get; private set; }
		public CreditCardType CardType { get; set; }

		public Customer Holder { get; private set; }

        public Account BoundAccount { get; private set; }
         
        public DateTime ExpirationDate { get; private set; }
    }
}
