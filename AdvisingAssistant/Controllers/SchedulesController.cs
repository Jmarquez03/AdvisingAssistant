using AdvisingAssistant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdvisingAssistant.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ILogger<SchedulesController> _logger;

        public SchedulesController(ILogger<SchedulesController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View("Index");
        }

        /*
        [HttpPost]
        public IActionResult Submit(string email)
        {
            if (email == "marco@student.edu") 
            {
                return View("marcoStudent");
            }
            if (email == "nathan@student.edu")
            {
                return View("nathanStudent");
            }
            if (email == "aneyda@student.edu")
            {
                return View("aneydaStudent");
            }
            if (email == "jorge@student.edu")
            {
                return View("jorgeStudent");
            }
            if (email == "steph@student.edu")
            {
                return View("stephStudent");
            }
            else
            {
                return View();
            }
        }*/

        [Authorize]
        public IActionResult Major()
        {
            return View("Major");
        }

        [Authorize]
        public IActionResult Roadmap()
        {
            return View("Roadmap");
        }

        [Authorize]
        public IActionResult Transcript()
        {
            return View("Transcript");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
