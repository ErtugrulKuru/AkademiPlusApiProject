using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using AkademiPlusApiProject.RapidApi.Models;
using Newtonsoft.Json;

namespace AkademiPlusApiProject.RapidApi.Controllers
{
    public class RapidApiImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<RapidApiImdbViewModel> rapidApiImdbViewModels = new List<RapidApiImdbViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "28857f7f1emsh1d11596995eab80p14e7f6jsn87d35d448850" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                rapidApiImdbViewModels = JsonConvert.DeserializeObject<List<RapidApiImdbViewModel>>(body);
                return View(rapidApiImdbViewModels);
            }
        }
    }
}
