using Microsoft.AspNetCore.Mvc;
using RandomDataGenWebApp.Models;
using System.Diagnostics;
using System.Text.Json;

namespace RandomDataGenWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DataGenerator generator = new DataGenerator();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public string Generate(int seed, int page, string country, double errVal)
        {
            seed += 2;
            var arr = new TableRowModel[10];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = generator.GetRow(seed, page, i, country, errVal);
            }
            return JsonSerializer.Serialize(arr);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}