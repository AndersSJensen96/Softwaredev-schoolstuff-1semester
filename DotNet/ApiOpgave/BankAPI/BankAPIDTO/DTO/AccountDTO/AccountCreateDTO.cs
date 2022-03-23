using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPIDTO.DTO.AccountDTO
{
    public class AccountCreateDTO
    {
        public int AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string RegisterNumber { get; set; }
        public int Owner { get; set; }
    }
}
