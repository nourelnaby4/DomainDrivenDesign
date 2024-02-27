using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationDbConetxt : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbConetxt).Assembly);
        }
    }
}
