using Employee_Directory_WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Directory_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveDetails> LeaveDetails { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
    }
}
