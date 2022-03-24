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

        public List<Customer> Customers { get; set; }
        public List<Account> Accounts { get; set; }
        public List<CreditCard> Cards { get; set; }

        public MockupClass()
        {
            Seed();
        }

        private void Seed()
        {
             Customers = new List<Customer>
            {
                new Customer("TestCompany1", "Company1@mail.com", 14423121, CustomerType.Company){ Id = 1},
                new Customer( "TestCompany2", "Company2@mail.com", 15431829, CustomerType.Company){ Id = 2},
                new Customer("Torben Jespersen", "Torben@mail.com", 14423121, CustomerType.Private){ Id = 3},
                new Customer("Claus Clausen", "Claus@mail.com", 15431829, CustomerType.Private){ Id = 4}
            };

           Accounts = new List<Account>
            {
                new Account("814841804189041","243", AccountType.Normal, 1, new List<ITransaction>()){ Id = 1},
                new Account("251626345232134","123",AccountType.Normal, 2, new List<ITransaction>()){ Id = 2},
                new Account("123154634562234","253", AccountType.Normal, 3, new List<ITransaction>()){ Id = 3},
                new Account("123154634562234","475", AccountType.Savings, 3, new List<ITransaction>()){ Id = 4},
                new Account("123154634562234","357", AccountType.Savings, 4, new List<ITransaction>()){ Id = 5},
                new Account("123154634562234","975", AccountType.Normal, 4, new List<ITransaction>()){ Id = 6}
            };

            Cards = new List<CreditCard>
            {
                new CreditCard("807412087142087", "321", Customers.Find(x=>x.Id == 1), Accounts.Find(x=>x.AccountNumber == "814841804189041"), DateTime.Now.AddDays(720), CreditCardType.Dankort){ Id = 1},
                new CreditCard("15636223668134", "234", Customers.Find(x=>x.Id == 3), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720), CreditCardType.Visa){ Id = 2},
                new CreditCard("5235668124", "452", Customers.Find(x=>x.Id == 2), Accounts.Find(x=>x.AccountNumber == "251626345232134"), DateTime.Now.AddDays(720), CreditCardType.VisaDankort){ Id = 3},
                new CreditCard("124254736412", "145", Customers.Find(x=>x.Id == 4), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720), CreditCardType.VisaDankort){ Id = 4}
            };
        }

       
    }
}
