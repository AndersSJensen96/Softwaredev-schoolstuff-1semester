using BankAPI.Models.Accounts;
using BankAPI.Models.CreditCards;
using BankAPI.Models.Customers;
using BankAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI
{
    public static class MockupClass
    {
        public static List<ICustomer> Customers = new List<ICustomer>
        {
            new CompanyCustomer("12345", 1,  "TestCompany1", "Company1@mail.com", 14423121),
            new CompanyCustomer("123456", 2,  "TestCompany2", "Company2@mail.com", 15431829),
            new CompanyCustomer("1212950142", 3,  "Torben Jespersen", "Torben@mail.com", 14423121),
            new CompanyCustomer("0209950145", 4,  "Claus Clausen", "Claus@mail.com", 15431829)
        };

        public static List<IAccount> Accounts = new List<IAccount>
        {
            new NormalAccount("814841804189041","243"),
            new SavingsAccount("251626345232134","123"),
            new SalaryAccount("123154634562234","715"),
        };

        public static List<ICreditCard> Cards = new List<ICreditCard>
        {
            new VisaCreditCard("807412087142087", "32½", Customers.Find(x=>x.Id == 1), Accounts.Find(x=>x.AccountNumber == "814841804189041"), DateTime.Now.AddDays(720)),
            new MasterCard("15636223668134", "234", Customers.Find(x=>x.Id == 3), Accounts.Find(x=>x.AccountNumber == "123154634562234"), DateTime.Now.AddDays(720))
        };
    }
}
