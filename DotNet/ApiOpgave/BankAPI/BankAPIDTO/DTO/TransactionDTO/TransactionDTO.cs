
using System;

namespace BankAPIDTO.DTO.TransactionDTO
{
    public class TransactionDTO
    {
        public string ToAccountNumber { get; set; }
        public string ToRegisterNumber { get; set; }
        public string FromAccountNumber { get; set; }
        public string FromRegisterNumber { get; set; }
        public double Amount { get; set; }
        public int TransferType { get; set; }
        public DateTime TransactionTime { get; set; }
        public int TransactionType { get; set; }
    }
}
