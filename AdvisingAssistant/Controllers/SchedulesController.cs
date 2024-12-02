using AdvisingAssistant.Data;
using AdvisingAssistant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class SchedulesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public SchedulesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var schedules = await _context.Schedules
            .Where(s => s.StudentEmail == user.Email)
            .Include(s => s.Course)
            .ToListAsync();
        return View(schedules);
    }

    [Authorize(Roles = "Advisor")]
    [HttpGet]
    public IActionResult AddCourse()
    {
        return View();
    }

    [Authorize(Roles = "Advisor")]
    [HttpPost]
    public async Task<IActionResult> AddCourse(AddCourseViewModel model)
    {
        if (ModelState.IsValid)
        {
            var schedule = new Schedule
            {
                StudentEmail = model.StudentEmail,
                CourseId = model.CourseId,
                Location = model.Location,
                Time = model.Time
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        return View(model);
    }
    public async Task<IActionResult> Schedule()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var currentCourses = await _context.Schedules
            .Include(s => s.Course)
            .Where(s => s.StudentEmail == user.Email && s.FinalGrade == null)
            .ToListAsync();

        return View(currentCourses);
    }
    [Authorize(Roles = "Advisor")]
    [HttpGet]
    public IActionResult AdvisorView()
    {
        return View();
    }

    [Authorize(Roles = "Advisor")]
    [HttpPost]
    public async Task<IActionResult> AdvisorView(string studentEmail)
    {
        if (string.IsNullOrEmpty(studentEmail))
        {
            ModelState.AddModelError(string.Empty, "Please enter a valid email.");
            return View();
        }

        var user = await _userManager.FindByEmailAsync(studentEmail);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Student not found.");
            return View();
        }

        var schedules = await _context.Schedules
            .Where(s => s.StudentEmail == user.Email)
            .Include(s => s.Course)
            .ToListAsync();

        if (!schedules.Any())
        {
            ModelState.AddModelError(string.Empty, "No schedules found for this student.");
            return View();
        }

        return View("AdvisorSchedule", schedules);
    }

}
