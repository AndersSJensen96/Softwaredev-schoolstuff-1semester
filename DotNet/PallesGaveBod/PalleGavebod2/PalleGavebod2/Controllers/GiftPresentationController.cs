using Microsoft.AspNetCore.Mvc;
using System;
using PalleGavebod2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalleGavebod2.Controllers
{
	public class GiftPresentationController : Controller
	{
		private DbContextGifts db;
		public GiftPresentationController(DbContextGifts _db)
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
