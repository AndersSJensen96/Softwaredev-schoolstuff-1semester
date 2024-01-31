using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PalleGavebod2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PalleGavebod2.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private DbContextGifts db;

		public HomeController(ILogger<HomeController> logger, DbContextGifts giftDB)
		{
			_logger = logger;
			db = giftDB;
		}

		public IActionResult Index()
		{
			var gifts = db.Gifts;
			return View(gifts);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
