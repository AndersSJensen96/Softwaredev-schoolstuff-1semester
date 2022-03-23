using BankAPI.Models;
using BankAPI.Models.Accounts;
using BankAPI.Models.CreditCards;
using BankAPI.Models.Customers;
using BankAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace BankAPI
{
    public class MockupClass
    {

        public List<ICustomer> Customers { get; set; }
        public List<IAccount> Accounts { get; set; }
        public List<ICreditCard> Cards { get; set; }

        public MockupClass()
        {
            Seed();
        }

        private void Seed()
        {
             Customers = new List<ICustomer>
            {
                new CompanyCustomer("46352178", "TestCompany1", "Company1@mail.com", 14423121){ Id = 1},
                new CompanyCustomer("13516578", "TestCompany2", "Company2@mail.com", 15431829){ Id = 2},
                new PrivateCustomer("1212950142", "Torben Jespersen", "Torben@mail.com", 14423121){ Id = 3},
                new PrivateCustomer("0209950145", "Claus Clausen", "Claus@mail.com", 15431829){ Id = 4}
            };

           Accounts = new List<IAccount>
            {
                new Account("814841804189041","243", AccountType.Normal, 1){ Id = 1},
                new Account("251626345232134","123",AccountType.Normal, 2){ Id = 2},
                new Account("123154634562234","253", AccountType.Normal, 3){ Id = 3},
                new Account("123154634562234","475", AccountType.Savings, 3){ Id = 4},
                new Account("123154634562234","357", AccountType.Savings, 4){ Id = 5},
                new Account("123154634562234","975", AccountType.Normal, 4){ Id = 6}
            };

            Cards = new List<ICreditCard>
            {
                new VisaCreditCard("807412087142087", "321", Customers.Find(x=>x.Id == 1), Accounts.Find(x=>x.AccountNumber == "814841804189041"), DateTime.Now.AddDays(720)){ Id = 1},
                new MasterCard("15636223668134", "234", Customers.Find(x=>x.Id == 3), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720)){ Id = 2},
                new VisaCreditCard("5235668124", "452", Customers.Find(x=>x.Id == 2), Accounts.Find(x=>x.AccountNumber == "251626345232134"), DateTime.Now.AddDays(720)){ Id = 3},
                new MasterCard("124254736412", "145", Customers.Find(x=>x.Id == 4), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720)){ Id = 4}
            };
        }

       
    }
}
