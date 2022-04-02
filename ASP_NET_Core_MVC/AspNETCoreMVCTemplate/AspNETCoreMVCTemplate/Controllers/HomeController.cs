using AspNETCoreMVCTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNETCoreMVCTemplate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInfoRepository _repo;
       

        public HomeController(ILogger<HomeController> logger, IUserInfoRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            string userAgent = HttpContext.Request.Headers["User-Agent"][0];

            var newUserInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                UserAgent = userAgent
            };

            await _repo.Add(newUserInfo);

            return View();
        }

        public async Task<IActionResult> UsersInfo()
        {
            var usersInfo = await _repo.GetUsersInfo();

            //Console.WriteLine("See all users info:");
            //foreach (var user in usersInfo)
            //    Console.WriteLine($"User id: {user.Id}, DATE: {user.Date}, Info: {user.UserAgent} ");

            return View(usersInfo);
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