﻿using BankAPI.Models.Transactions;
using System;

namespace BankAPI.Models.Interfaces
{
    public interface ITransaction
    {
        public string ToAccountNumber { get; set; }
        public string ToRegisterNumber { get; set; }
        public string FromAccountNumber { get; set; }
        public string FromRegisterNumber { get; set; }
        public TransferType TransferType { get; set; }
        public TransactionType TransactionType { get; set; }
        public double TransferAmount { get; set; }
        public DateTime TransactionTime { get; set; }
    }
}
