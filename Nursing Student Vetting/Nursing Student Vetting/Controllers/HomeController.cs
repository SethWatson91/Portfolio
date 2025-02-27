using Microsoft.AspNetCore.Mvc;
using Nursing_Student_Vetting.Models;
using System.Diagnostics;

namespace Nursing_Student_Vetting.Controllers
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
            return RedirectToAction("Index", "Students");
        }
    }
}
