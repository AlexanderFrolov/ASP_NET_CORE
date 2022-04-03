using AF_Mod32_Practice_32_11.Models.Db;
using AF_Mod32_Practice_32_11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AF_Mod32_Practice_32_11.Controllers
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
            //var newUser = new User()
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "Alex",
            //    LastName = "Last",
            //    JoinDate = DateTime.Now
            //};

            //await _repo.Add(newUser);

            return View();
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