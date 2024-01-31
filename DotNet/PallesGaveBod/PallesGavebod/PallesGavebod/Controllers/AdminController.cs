using Microsoft.AspNetCore.Mvc;
using System;
using PallesGavebod.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PallesGavebod.Controllers
{
	public class AdminController : Controller
	{
		private DbContextIdentity db;
		public AdminController(DbContextIdentity _db)
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
