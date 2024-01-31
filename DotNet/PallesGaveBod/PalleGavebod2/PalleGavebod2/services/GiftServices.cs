using PalleGavebod2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PalleGavebod2.services
{
	public class GiftServices
	{
		private HttpClient httpClient;
		private Uri baseAddress = new Uri("https://localhost:44327/");
		public GiftServices(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			this.httpClient.BaseAddress = baseAddress;
		}
		public async Task<List<Gift>> GetGifts()
		{

			return null;
		}
		public async Task<Gift> GetGift(int giftnumber)
		{
			return null;
		}
		public async void SaveGift(Gift gift)
		{
		}
		public async void DeleteGift(Gift gift)
		{
		}
		public async void UpdateGift(Gift gift)
		{
		}
	}
}
