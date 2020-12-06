using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace MainSpace
{
    class MainClass
    {
        private static void Main(string[] _Args)
        {
            byte[] buf = new byte[256];
            Socket sockSer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket sockCli = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 10101);
            sockSer.Bind(ipep);
            sockSer.Listen(1);
            sockCli = sockSer.Accept();
            sockCli.Receive(buf);
            sockCli.Send(Encoding.UTF8.GetBytes("Message Received!"));
            sockCli.Close();
            Console.Write(Encoding.UTF8.GetString(buf));
        }
    }
}