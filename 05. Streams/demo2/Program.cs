using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] buffer = new byte[4096];
            TcpListener listener = new TcpListener(IPAddress.Loopback, 5000);
            Console.WriteLine("Listening on port {0}...", 5000);
            listener.Start();

            while (true)
            {
                using (var stream = listener.AcceptTcpClient().GetStream())
                {
                    stream.Read(buffer, 0, buffer.Length);
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }
            }
        }
    }
}
