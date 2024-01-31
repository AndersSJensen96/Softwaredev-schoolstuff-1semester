using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PallesGavebodAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PallesGavebodAPI.Controllers
{
	[ApiController]
	public class GiftController : ControllerBase
	{
		private DbContextGifts db;
		public GiftController(DbContextGifts db)
		{
			this.db = db;
		}
		[Route("GetAllGifts")]
		[HttpGet]
		public IActionResult GetAllGifts()
		{
			var gifts = db.Gifts;
			return Ok(gifts);
		}
		[Route("GetGift/{giftnumber}")]
		[HttpGet]
		public IActionResult GetGift(int giftnumber)
		{
			var gift = db.Gifts.Where(x => x.GiftNumber == giftnumber);
			return Ok(gift);
		}
		[HttpPost]
		[Route("SaveGift")]
		public async Task<IActionResult>SaveGift(Gift gift)
		{
			gift.CreationDate = DateTime.Now;
			db.Gifts.Add(gift);
			await db.SaveChangesAsync();
			return Ok(gift);
		}
		[HttpPost]
		[Route("DeleteGift")]
		public async Task<IActionResult> DeleteGift(Gift gift)
		{
			db.Gifts.RemoveRange(gift);
			await db.SaveChangesAsync();
			return Ok();
		}
		[HttpPost]
		[Route("UpdateGift")]
		public async Task<IActionResult> UpdateGift(Gift gift)
		{
			//try
			//{
				db.Gifts.Update(gift);
				await db.SaveChangesAsync();
			//}
			//catch (DbUpdateConcurrencyException)
			//{
				
			//}
			
			return Ok();
		}
	}
}
