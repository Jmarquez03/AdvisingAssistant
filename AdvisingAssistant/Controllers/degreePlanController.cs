using AdvisingAssistant.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
public class DegreePlanController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public DegreePlanController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

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
            return NotFound("Degree plan not found for the user's major.");
        }

        return View(degreePlan);
    }
}

