using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using PalleGavebod2.Models;
using System.Threading.Tasks;

namespace PalleGavebod2.Components
{
	public class GiftCountViewComponent : ViewComponent
	{
		private DbContextGifts _db;
		public GiftCountViewComponent(DbContextGifts db)
		{
			_db = db;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			int count = _db.Gifts.Count();
			return await Task.FromResult((IViewComponentResult)View("GiftCount", count));
		}
	}
}
