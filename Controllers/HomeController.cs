using System.Diagnostics;
using Calculator_2ndAct_ITElective.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_2ndAct_ITElective.Controllers
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
            return View(new Calculator());
        }

        [HttpPost]
        public IActionResult CalculateSemGrade(Calculator model)
        {
            if (model.prelim.HasValue && model.midterm.HasValue && model.finals.HasValue)
            {
                model.semGrade = (model.prelim.Value * 0.3) + (model.midterm.Value * 0.3) + (model.finals.Value * 0.4);
            }
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}