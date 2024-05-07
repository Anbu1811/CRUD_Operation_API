using Microsoft.EntityFrameworkCore;
using world.API.Models;
using World.API.Models;

namespace world.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<State> states { get; set; }
    }
}
