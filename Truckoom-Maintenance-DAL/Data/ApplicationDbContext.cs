using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Truckoom_Maintenance_DAL.Model;

namespace Truckoom_Maintenance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<MaintenanceActivity> MaintenanceActivities { get; set; }
    }
}
