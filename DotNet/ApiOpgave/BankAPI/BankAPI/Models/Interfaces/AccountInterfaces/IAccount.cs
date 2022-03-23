using BankAPI.Models.Accounts;

namespace BankAPI.Models.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public string AccountNumber { get;}
        public string RegisterNumber { get;}
        public double Balance { get; }
        public int Owner { get; }

        void Deposit(double amount);
        void Withdraw(double amount);
    }
}
