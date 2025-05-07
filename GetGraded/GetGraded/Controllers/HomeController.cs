using GetGraded.BL.Services.Interface;
using GetGraded.Models;
using GetGraded.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetGraded.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult FirstPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveData(TestSave test)
        {
            await _testService.SaveChanges(test);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
