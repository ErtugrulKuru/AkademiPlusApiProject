﻿using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using AkademiPlusApiProject.RapidApi.Models;
using System.Linq;

namespace AkademiPlusApiProject.RapidApi.Controllers
{
    public class RapidApiBookingHotelsController : Controller
    {
        public async Task<IActionResult> Index()
        {          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkin_date=2023-09-27&dest_type=city&units=metric&checkout_date=2023-09-28&adults_number=2&order_by=popularity&dest_id=-553173&filter_by_currency=AED&locale=en-gb&room_number=1&children_number=2&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&page_number=0&include_adjacency=true"),
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
                var values = JsonConvert.DeserializeObject<RapidApiBookingHotelsViewModel>(body);
                return View(values.result.ToList());
            }
        }
    }
}
