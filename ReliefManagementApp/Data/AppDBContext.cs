using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReliefManagementApp.Models;

namespace ReliefManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Custom User table DbSet
        public virtual DbSet<User> Users { get; set; }

        // Other DbSets for your other models
        public virtual DbSet<Volunteer> Volunteers { get; set; }
        public virtual DbSet<ReliefProject> ReliefProjects { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<IncidentReport> IncidentReports { get; set; }
    }
}
