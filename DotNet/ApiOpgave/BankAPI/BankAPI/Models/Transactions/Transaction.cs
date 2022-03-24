using System;
using BankAPI.Models.Interfaces;
using BankAPI.Models.Transactions;

namespace BankAPI.Models
{

    public class Transaction : ITransaction
    {
        public double TransferAmount { get; set; }
        public DateTime TransactionTime { get; set; }
        public string ToAccountNumber { get; set; }
        public string ToRegisterNumber { get; set; }
        public string FromAccountNumber { get; set; }
        public string FromRegisterNumber { get; set; }
        public TransactionType TransactionType { get; set; }
        public TransferType TransferType { get; set; }
    }
}
