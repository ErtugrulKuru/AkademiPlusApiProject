﻿using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AkademiPlusApiProject.RapidApi.Models;
using System.Linq;

namespace AkademiPlusApiProject.RapidApi.Controllers
{
    public class RapidApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/metadata/exchange-rates?currency=TRY&locale=en-gb"),
                Headers =
    {
        { "X-RapidAPI-Key", "28857f7f1emsh1d11596995eab80p14e7f6jsn87d35d448850" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<RapidApiExchangeViewModel>(body);
                return View(values.exchange_rates.ToList());
            }
        }
    }
}
