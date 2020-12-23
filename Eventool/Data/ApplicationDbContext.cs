using Eventool.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {            
            base.OnModelCreating(builder);  
        }
    }
}
