using BankAPI.Models.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface ICustomer
    {
        public int Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public List<Account> Accounts { get;}

        public List<CreditCard> creditCards { get; }
    }
}
