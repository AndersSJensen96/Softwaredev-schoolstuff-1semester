using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Models.Accounts;
using BankAPI.Models.Interfaces;
using BankAPI.Models.Transactions;

namespace BankAPI.Models
{
    public class Account : IAccount
    {
        public Account()
        {

        }
        public Account(string accountNumber, string registerNumber, AccountType type, int owner, List<ITransaction> transactions)
        {
            AccountNumber = accountNumber;
            RegisterNumber = registerNumber;
            AccountType = type;
            Owner = owner;
            AccountTransactions = transactions;
        }
        public int Id { get; set; }

        public AccountType AccountType { get; set; }

        public string AccountNumber { get; private set; }

        public string RegisterNumber { get; private set; }

        public int Owner { get; private set; }

        public List<ITransaction> AccountTransactions { get; private set; }

        public void AddTransaction(Transaction transaction)
        {
            AccountTransactions.Add(transaction);
        }
    }
}
