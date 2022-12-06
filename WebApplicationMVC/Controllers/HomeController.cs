using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationMVC.Models;
using WebApplicationMVC.Services;
using WebApplicationMVC.Transaction;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IDatabaseService _dbService;

        public HomeController(ILogger<HomeController> logger, IDatabaseService dbService)
        {
            _logger = logger;
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            var list = _dbService.GetLogAll();

            return View();
        }

        public IActionResult Privacy()
        {
            var ret = _dbService.InsLog();

            //var retError = _dbService.InsLogError();

            return View();
        }

        [TransactionAttribute]
        public IActionResult Tran()
        {
            var ret = _dbService.InsLogTran();

            return new JsonResult(new { result = ret });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}