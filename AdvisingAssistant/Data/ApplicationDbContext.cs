using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdvisingAssistant.Models;

namespace AdvisingAssistant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DegreePlan> DegreePlans { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed degree plans
            builder.Entity<DegreePlan>().HasData(
                new DegreePlan { Id = 1, Major = "English" },
                new DegreePlan { Id = 2, Major = "Computer Science" }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Course> Course{ get; set; } = default!;
        public DbSet<Schedule> Schedules { get; set; } = default!;
    }
}
