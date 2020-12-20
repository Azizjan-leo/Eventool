using Eventool.Db.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventool.Db
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PlatformType> PlatformTypes { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        
     
    }
}
