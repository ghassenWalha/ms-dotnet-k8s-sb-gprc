using Microsoft.EntityFrameworkCore;
using MS.PlatformService.Models;

namespace MS.PlatformService.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {

        }
        public DbSet<Platform> Platforms { get; set; }
    }
}
