using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankAPI.Data;
using BankAPI.Models.CreditCards;
using Microsoft.AspNetCore.Authorization;

namespace BankAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly MockupClass _context;

        public CreditCardsController(MockupClass context)
        {
            _context = context;
        }

        // GET: api/CreditCards
        [HttpGet("{customerId}")]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCard(int customerId)
        {
            return _context.Cards.Where(x => x.Holder.Id == customerId).ToList();
        }

        // GET: api/CreditCards/5
        [HttpGet("{customerId}/{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int customerId, int id)
        {
            var creditCard = _context.Cards.FirstOrDefault(x => x.Id == id && x.Holder.Id == customerId);

            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }

        // POST: api/CreditCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{customerId}")]
        public async Task<ActionResult<CreditCard>> PostCreditCard(int customerId, CreditCard creditCard)
        {
			if (customerId != creditCard.Holder.Id)
			{
                return StatusCode(405);
			}
            _context.Cards.Add(creditCard);

            return CreatedAtAction("GetCreditCard", new {customerId = customerId, id = creditCard.Id }, creditCard);
        }

        // DELETE: api/CreditCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            var creditCard = _context.Cards.FirstOrDefault(x => x.Id == id);
            if (creditCard == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(creditCard);

            return NoContent();
        }
    }
}
