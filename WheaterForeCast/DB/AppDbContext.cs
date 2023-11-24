using Microsoft.EntityFrameworkCore;
using WheaterForeCast.Entities;

namespace WheaterForeCast.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
