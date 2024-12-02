using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AdvisingAssistant.Data;
using AdvisingAssistant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RoadmapController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public RoadmapController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var degreePlan = await _context.DegreePlans
            .Include(dp => dp.Courses)
            .FirstOrDefaultAsync(dp => dp.Major == user.Major);

        if (degreePlan == null)
        {
            return NotFound("Degree plan not found.");
        }

        var takenCourses = await _context.Schedules
            .Where(s => s.StudentEmail == user.Email)
            .Select(s => s.CourseId)
            .ToListAsync();

        var remainingCourses = degreePlan.Courses
            .Where(c => !takenCourses.Contains(c.Id))
            .ToList();

        var roadmap = GenerateRoadmap(remainingCourses);

        var roadmapViewModel = new RoadmapViewModel
        {
            StudentEmail = user.Email,
            Semesters = roadmap
        };

        return View(roadmapViewModel);
    }

    private List<Semester> GenerateRoadmap(List<Course> courses)
    {
        var semesters = new List<Semester>();
        var semesterNames = new[] { "Spring 2025", "Fall 2025", "Spring 2026", "Fall 2026" };
        int semesterIndex = 0;

        while (courses.Any())
        {
            var semesterCourses = new List<Course>();
            foreach (var course in courses.ToList())
            {
                if ((string.IsNullOrEmpty(course.Prerequisite1) || courses.All(c => c.CourseNumber != course.Prerequisite1)) &&
                    (string.IsNullOrEmpty(course.Prerequisite2) || courses.All(c => c.CourseNumber != course.Prerequisite2)))
                {
                    semesterCourses.Add(course);
                    courses.Remove(course);
                }

                if (semesterCourses.Count == 4)
                {
                    break;
                }
            }

            if (semesterCourses.Any())
            {
                semesters.Add(new Semester
                {
                    Name = semesterNames[semesterIndex % semesterNames.Length],
                    Courses = semesterCourses
                });
                semesterIndex++;
            }
            else
            {
                break;
            }
        }

        return semesters;
    }
    [Authorize(Roles = "Advisor")]
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

        var degreePlan = await _context.DegreePlans
            .Include(dp => dp.Courses)
            .FirstOrDefaultAsync(dp => dp.Major == user.Major);

        if (degreePlan == null)
        {
            ModelState.AddModelError(string.Empty, "Degree plan not found.");
            return View();
        }

        var takenCourses = await _context.Schedules
            .Where(s => s.StudentEmail == user.Email)
            .Select(s => s.CourseId)
            .ToListAsync();

        var remainingCourses = degreePlan.Courses
            .Where(c => !takenCourses.Contains(c.Id))
            .ToList();

        var roadmap = GenerateRoadmap(remainingCourses);

        var roadmapViewModel = new RoadmapViewModel
        {
            StudentEmail = user.Email,
            Semesters = roadmap
        };

        return View("AdvisorRoadmap", roadmapViewModel);
    }

}
