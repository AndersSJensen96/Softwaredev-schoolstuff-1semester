using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;
using BankAPI.Models.Interfaces;
using BankAPIDTO.DTO;
using BankAPIDTO.DTO.AccountDTO;
using BankAPI.Models.Accounts;
using Microsoft.AspNetCore.Authorization;

namespace BankAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private MockupClass _context;

        public AccountsController(MockupClass context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountResponseDTO>>> GetAccounts(int userid)
        {

            List<AccountResponseDTO> accounts = _context.Accounts
                .Where(x => x.Owner == userid)
                .Select(x => new AccountResponseDTO {
                    AccountNumber = x.AccountNumber,
                    AccountType = (int)x.AccountType,
                    RegisterNumber = x.RegisterNumber
                })
                .ToList();

            return accounts;
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountResponseDTO>> GetAccount(int id)
        {
            AccountResponseDTO account = _context.Accounts
                .Where(x => x.Id == id)
                .Select(x => new AccountResponseDTO
                {
                    AccountNumber = x.AccountNumber,
                    AccountType = (int)x.AccountType,
                    RegisterNumber = x.RegisterNumber
                })
                .FirstOrDefault();

            return account;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAccount(int id, ChangeAccountDTO account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            IAccount acc = _context.Accounts.Where(x => x.Id == id).FirstOrDefault();

            try
            {
                acc.AccountType = (AccountType) account.AccountType;
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, ChangeAccountDTO account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            IAccount acc = _context.Accounts.Where(x => x.Id == id).FirstOrDefault();

            try
            {
                acc.AccountType = (AccountType) account.AccountType;
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Accounts
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(AccountCreateDTO account)
        {

            Account newAccount = new Account(account.AccountNumber, account.RegisterNumber, (AccountType)account.AccountType, account.Owner, new List<ITransaction>());

            //Please kill me
            newAccount.Id = _context.Accounts.Max(x => x.Id) + 1;

            _context.Accounts.Add(newAccount);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = newAccount.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = _context.Accounts.Find(x => x.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            //await _context.SaveChangesAsync();

            return Ok();
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
