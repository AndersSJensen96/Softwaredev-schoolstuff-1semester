using BankAPI.Models;
using BankAPI.Models.Accounts;
using BankAPI.Models.CreditCards;
using BankAPI.Models.Customers;
using BankAPI.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace BankAPI
{
    public static class MockupClass
    {
        public static List<ICustomer> Customers = new List<ICustomer>
        {
            new CompanyCustomer("46352178", 1,  "TestCompany1", "Company1@mail.com", 14423121),
            new CompanyCustomer("13516578", 2,  "TestCompany2", "Company2@mail.com", 15431829),
            new PrivateCustomer("1212950142", 3,  "Torben Jespersen", "Torben@mail.com", 14423121),
            new PrivateCustomer("0209950145", 4,  "Claus Clausen", "Claus@mail.com", 15431829)
        };

        public static List<IAccount> Accounts = new List<IAccount>
        {
            new Account("814841804189041","243", AccountEnum.Normal, 1),
            new Account("251626345232134","123",AccountEnum.Normal, 2),
            new Account("123154634562234","715", AccountEnum.Normal, 3),
            new Account("123154634562234","715", AccountEnum.Savings, 3),
            new Account("123154634562234","715", AccountEnum.Savings, 4),
            new Account("123154634562234","715", AccountEnum.Normal, 4)
        };

        public static List<ICreditCard> Cards = new List<ICreditCard>
        {
            new VisaCreditCard("807412087142087", "321", Customers.Find(x=>x.Id == 1), Accounts.Find(x=>x.AccountNumber == "814841804189041"), DateTime.Now.AddDays(720)),
            new MasterCard("15636223668134", "234", Customers.Find(x=>x.Id == 3), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720)),
            new VisaCreditCard("5235668124", "452", Customers.Find(x=>x.Id == 2), Accounts.Find(x=>x.AccountNumber == "251626345232134"), DateTime.Now.AddDays(720)),
            new MasterCard("124254736412", "145", Customers.Find(x=>x.Id == 4), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720))
        };
    }
}
