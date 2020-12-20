using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Eventool.Db
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args= null)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();

            options.UseSqlServer("server=.; database=Eventool; Integrated Security=True;");

            return new ApplicationDbContext(options.Options);
        }
    }
}
