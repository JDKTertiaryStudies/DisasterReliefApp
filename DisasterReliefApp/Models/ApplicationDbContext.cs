using Microsoft.EntityFrameworkCore;

namespace DisasterReliefApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<IncidentReport> IncidentReports { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
