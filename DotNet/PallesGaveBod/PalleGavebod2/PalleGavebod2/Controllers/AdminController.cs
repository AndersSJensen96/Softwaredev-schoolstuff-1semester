using Microsoft.AspNetCore.Mvc;
using System;
using PalleGavebod2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PalleGavebod2.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private DbContextGifts db;
		public AdminController(DbContextGifts _db)
		{
			db = _db;
		}
		[Route("CreateGift")]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateGift(Gift gift)
		{
			if (ModelState.IsValid)
			{
				gift.CreationDate = DateTime.Now;
				db.Add(gift);
				db.SaveChanges();
			}

			return RedirectToAction("Index", "HomeController");
		}
	}
}
