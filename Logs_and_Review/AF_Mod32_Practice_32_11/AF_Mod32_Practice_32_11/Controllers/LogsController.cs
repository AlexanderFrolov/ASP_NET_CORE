using AF_Mod32_Practice_32_11.Models.Db;
using Microsoft.AspNetCore.Mvc;

namespace AF_Mod32_Practice_32_11.Controllers
{   
    public class LogsController : Controller
    {

        private IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequests();
       
            return View(logs);
        }
    }
}
