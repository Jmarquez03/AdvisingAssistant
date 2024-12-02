using Microsoft.AspNetCore.Identity;

public class RoleInitializer
{
    public static async Task InitializeRoles(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure roles exist
        string[] roleNames = { "Advisor", "Student" };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        // Assign roles to users based on the Role column
        var users = userManager.Users.ToList();
        foreach (var user in users)
        {
            if (!await userManager.IsInRoleAsync(user, user.Role))
            {
                await userManager.AddToRoleAsync(user, user.Role);
            }
        }
    }
}
