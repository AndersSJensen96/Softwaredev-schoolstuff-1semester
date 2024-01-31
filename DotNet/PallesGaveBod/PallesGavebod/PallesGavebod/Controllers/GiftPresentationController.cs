using Microsoft.AspNetCore.Mvc;
using System;
using PallesGavebod.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PallesGavebod.Controllers
{
	public class GiftPresentationController : Controller
	{
		private DbContextIdentity db;
		public GiftPresentationController(DbContextIdentity _db)
		{
			db = _db;
		}
		[Route("/Gifts/{StartDate}/{EndDate}")]
		public IActionResult Index(DateTime StartDate, DateTime EndDate)
		{

			
			var gifts = db.Gifts.Where(x => x.CreationDate >= StartDate && x.CreationDate <= EndDate);
			return View(gifts);
		}
		public IActionResult GirlsGifts()
		{
			var gifts = db.Gifts.Where(x => x.GirlGift == true);
			return View(gifts);
		}
	}
}
