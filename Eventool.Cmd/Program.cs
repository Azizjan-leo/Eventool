using Eventool.Db;
using Eventool.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        ApplicationDbContextFactory _contextFactory = new ApplicationDbContextFactory();
        var cxt = _contextFactory.CreateDbContext();
        var pt = new PlatformType
        {
            Name = Console.ReadLine()
        };
        cxt.PlatformTypes.Add(pt);
        await cxt.SaveChangesAsync();
        var list = await cxt.PlatformTypes.ToListAsync();
        foreach (var item in list)
        {
            Console.WriteLine(item.Name);
        }
    }
}

