using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAPIDTO.DTO.Cutomer
{
    public class CustomerDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Phone { get; set; }
        public int CustomerType { get; set; }
    }
}
