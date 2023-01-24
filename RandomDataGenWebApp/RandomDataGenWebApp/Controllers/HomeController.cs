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
        public string Generate(int seed, int page, string country, int errVal)
        {

           // JsonSelector.Select();
            var arr = new TableRowModel[10];
            for(int i = 0; i< arr.Length; i++)
            {

                arr[i] = /*new TableRowModel()
                {
                    Address = new Random(seed * (page +1)* (i+1)).Next().ToString(),
                    Name = new Random(seed * (page + 1) * (i + 1)).Next().ToString(),
                    Number = page*10 + i,
                    PhoneNumber = "+36" + new Random(seed * (page + 1) * (i + 1)).Next().ToString(),
                    RandomId = new Random(seed * (page + 1) * (i + 1)).Next()
                };*/

                 generator.GetRow(seed, page, i, country, errVal);

                //string S_ = JsonSerializer.Serialize(arr[i]);
            }
            
            string S = JsonSerializer.Serialize(arr);
            return JsonSerializer.Serialize(arr);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}