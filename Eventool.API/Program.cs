using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Eventool.Domain;

class Program
{
   
    static void Main(string[] args)
    {
        
        var iPEndPoint = new IPEndPoint(IPAddress.Any, 11000);

        UdpClient udpServer = new UdpClient(11000);

        while (true)
        {

            var data = udpServer.Receive(ref iPEndPoint); // listen on port 11000
                                                        // Console.Write("receive data from " + remoteEP.ToString());
            if (data != null)
            {
                udpServer.Send(data, data.Length, iPEndPoint); // reply back
            }
        }
    }
}