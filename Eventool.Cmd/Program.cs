using Eventool.Db;
using Eventool.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        var client = new UdpClient();
        IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000); // endpoint where server is listening
        client.Connect(ep);

        Console.WriteLine("Enter your message: ");
        var msg = Console.ReadLine();
        var data = Encoding.ASCII.GetBytes(msg);
        // send data
        client.Send(data, data.Length);

        // then receive data
        var receivedData = client.Receive(ref ep);
        string someString = Encoding.ASCII.GetString(receivedData);

        Console.Write("\nReceived data: " + someString);

        Console.Read();
        //ApplicationDbContextFactory _contextFactory = new ApplicationDbContextFactory();
        //var cxt = _contextFactory.CreateDbContext();
        //var pt = new PlatformType
        //{
        //    Name = Console.ReadLine()
        //};
        //cxt.PlatformTypes.Add(pt);
        //await cxt.SaveChangesAsync();
        //var list = await cxt.PlatformTypes.ToListAsync();
        //foreach (var item in list)
        //{
        //    Console.WriteLine(item.Name);
        //}
    }
}

