using Microsoft.EntityFrameworkCore;

namespace WaterProject2.Data
{
    public class WaterDbContext : DbContext
    {
        public WaterDbContext(DbContextOptions<WaterDbContext> options) : base(options)
        {
        }
        
        public DbSet<Project> Projects { get; set; }
    }
}

