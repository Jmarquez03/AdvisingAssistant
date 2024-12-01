using AdvisingAssistant.Data;
using AdvisingAssistant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdvisingAssistant.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ILogger<SchedulesController> _logger;
        private readonly ApplicationDbContext _context;

        public SchedulesController(ILogger<SchedulesController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userEmail = User.Identity.Name;
            var schedules = await _context.Schedules
                .Include(s => s.Course)
                .Where(s => s.StudentEmail == userEmail)
                .ToListAsync();

            return View(schedules);
        }

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

        public IActionResult AdvisorIndex() 
        {
            if (HttpMethods.IsPost(Request.Method))
            {
                // Do something if it's a POST request
                string email = Request.Form["email"];

                if (email == "marco@student.edu")
                {
                    return View("marcoSchedule");
                }
				if (email == "nathan@student.edu")
				{
					return View("nathanSchedule");
				}
				if (email == "jorge@student.edu")
				{
					return View("jorgeSchedule");
				}
				if (email == "aneyda@student.edu")
				{
					return View("aneydaSchedule");
				}
				if (email == "steph@student.edu")
				{
					return View("stephSchedule");
				}
				else
                {
                    return View("ScheduleErrorMsg");
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult AdvisorMajor()
        {
            if (HttpMethods.IsPost(Request.Method))
            {
                // Do something if it's a POST request
                string email = Request.Form["email"];

                if (email == "marco@student.edu")
                {
                    return View("marcoMajor");
                }
                if (email == "nathan@student.edu")
                {
                    return View("nathanMajor");
                }
                if (email == "jorge@student.edu")
                {
                    return View("jorgeMajor");
                }
                if (email == "aneyda@student.edu")
                {
                    return View("aneydaMajor");
                }
                if (email == "steph@student.edu")
                {
                    return View("stephMajor");
                }
                else
                {
                    return View("MajorErrorMsg");
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult AdvisorTranscript()
        {
            if (HttpMethods.IsPost(Request.Method))
            {
                string email = Request.Form["email"];

                if (email == "marco@student.edu")
                {
                    return View("marcoTranscript");
                }
                if (email == "nathan@student.edu")  
                {
                    return View("nathanTranscript");
                }
                if (email == "jorge@student.edu")
                {
                    return View("jorgeTranscript");
                }
                if (email == "aneyda@student.edu")
                {
                    return View("aneydaTranscript");
                }
                if (email == "steph@student.edu")
                {
                    return View("stephTranscript");
                }
                else
                {
                    return View("TranscriptErrorMSG");
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult AdvisorRoadmap()
        {
            if (HttpMethods.IsPost(Request.Method))
            {
                string email = Request.Form["email"];

                if (email == "marco@student.edu")
                {
                    return View("marcoRoadmap");
                }
                if (email == "nathan@student.edu")
                {
                    return View("nathanRoadmap");
                }
                if (email == "jorge@student.edu")
                {
                    return View("jorgeRoadmap");
                }
                if (email == "aneyda@student.edu")
                {
                    return View("aneydaRoadmap");
                }
                if (email == "steph@student.edu")
                {
                    return View("stephRoadmap");
                }
                else
                {
                    return View("RoadmapErrorMsg");
                }
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
