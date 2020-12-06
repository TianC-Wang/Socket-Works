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
            Socket sockCli = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(_Args[0]), 10101);
            sockCli.Connect(ipep);
            sockCli.Send(Encoding.UTF8.GetBytes("Hello World!"));
            sockCli.Receive(buf);
            sockCli.Close();
            Console.Write(Encoding.UTF8.GetString(buf));
        }
    }
}