using BankAPI.Models.Accounts;
using System.Collections.Generic;

namespace BankAPI.Models.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNumber { get;}
        public string RegisterNumber { get;}
        public int Owner { get; }
        public List<ITransaction> AccountTransactions { get;}

        public void AddTransaction(Transaction transaction);
    }
}
