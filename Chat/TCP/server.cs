using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MainSpace
{
    class MainClass
    {
        private static void Main(string[] _Args)
        {
            try
            {
                byte[] Buffer = new byte[256];
                Socket Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Any, 10101);
                Sock.Bind(IPEP);
                Sock.Listen(1);
                Socket Conv = Sock.Accept();
                Sock.Close();
                Conv.Receive(Buffer);
                Console.Out.WriteLine("Received: " + Encoding.UTF8.GetString(Buffer));
                Conv.Send(Encoding.UTF8.GetBytes("Hello World!"));
            }
            catch (Exception Socket_Exception)
            {
                Console.Error.Write(Socket_Exception.Message);
            }
        }
    }
}