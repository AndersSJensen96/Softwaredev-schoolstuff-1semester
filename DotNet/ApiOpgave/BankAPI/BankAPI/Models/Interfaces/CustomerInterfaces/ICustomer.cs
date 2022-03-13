using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAPI.Models.Interfaces
{
    public interface ICustomer
    {
        public string Id { get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }

        public List<IAccount> Accounts { get;}

        public List<ICreditCard> creditCards { get; }
    }
}
