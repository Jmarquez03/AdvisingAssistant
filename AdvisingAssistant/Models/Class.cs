using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string? Major { get; set; } // e.g., "Political Science", "Computer Science"
    public string? Role { get; set; } // "Student" or "Advisor"
}
