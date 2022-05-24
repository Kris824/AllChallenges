using CreateChesssBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CreateChesssBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var obstacles = new List<List<int>>();
            var lines = System.IO.File.ReadAllLines(@"D:\kishan\AllChallenges\AllChallenges\Input7.txt");
            obstacles.AddRange(lines.Select(line => line.Split(" "))
                .Select(elements => new List<int> {int.Parse(elements[0]), int.Parse(elements[1])}));


            return View(obstacles);
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
