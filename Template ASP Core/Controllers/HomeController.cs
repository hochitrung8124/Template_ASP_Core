
using Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using Template_ASP_Core.Models;

namespace Template_ASP_Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var data = await client.GetAsync("https://localhost:7155/weatherforecast");
            var res = await data.Content.ReadAsStringAsync();
            var dataJson = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(res);
            return View(dataJson);
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
