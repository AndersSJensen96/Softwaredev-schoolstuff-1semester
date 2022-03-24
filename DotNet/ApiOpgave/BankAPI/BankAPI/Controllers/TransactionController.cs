using BankAPIDTO.DTO.TransactionDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BankAPI.Models;
using BankAPI.Models.Transactions;
using BankAPI.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private MockupClass context;
        public TransactionController(MockupClass context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Transaction(TransactionDTO transaction)
        {
            Transaction newTransaction = new Transaction
            {
                ToAccountNumber = transaction.ToAccountNumber,
                ToRegisterNumber = transaction.ToRegisterNumber,
                FromAccountNumber = transaction.FromAccountNumber,
                FromRegisterNumber = transaction.FromRegisterNumber,
                TransactionTime = transaction.TransactionTime,
                TransferType = (TransferType) transaction.TransferType,
                TransactionType = (TransactionType) transaction.TransactionType,
                TransferAmount = transaction.Amount
            };

            IAccount account = null;

            if(newTransaction.TransactionType == TransactionType.Out)
            {
                account = context.Accounts.Find(x => x.AccountNumber == newTransaction.FromAccountNumber && x.RegisterNumber == newTransaction.FromRegisterNumber);
            }
            else
            {
                account = context.Accounts.Find(x => x.AccountNumber == newTransaction.ToAccountNumber && x.RegisterNumber == newTransaction.ToRegisterNumber);
            }

            if (account == null)
                return BadRequest("Account not found, please check the accountnumber and registernumber");

            account.AddTransaction(newTransaction);

            return Ok("Transaction Done");
        }
    }
}
