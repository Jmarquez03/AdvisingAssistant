using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AdvisingAssistant.Data;
using AdvisingAssistant.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TranscriptsController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public TranscriptsController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        var schedules = _context.Schedules
            .Where(s => s.StudentEmail == user.Email)
            .Include(s => s.Course)
            .ToList();
        return View(schedules);
    }

    [HttpPost]
    [Authorize(Policy = "RequireAdvisorRole")]
    public async Task<IActionResult> AdvisorTranscript(string email)
    {
        var student = await _userManager.FindByEmailAsync(email);
        if (student == null)
        {
            return NotFound();
        }

        var schedules = _context.Schedules
            .Where(s => s.StudentEmail == student.Email)
            .Include(s => s.Course)
            .ToList();
        return View("Index", schedules);
    }
}
