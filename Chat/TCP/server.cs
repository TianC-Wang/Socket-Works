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
                Console.Out.Write("Server end program\n\n");
                Console.Out.Write("Open Port? ");
                string Server_Port = Console.In.ReadLine();
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Any, int.Parse(Server_Port));
                Socket Socket_Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket_Server.Bind(IPEP);
                Socket_Server.Listen(5);
                Socket Socket_Client = Socket_Server.Accept();
                Console.Out.Write("Connected " + ((IPEndPoint)Socket_Client.RemoteEndPoint).Address.ToString() + "!\n\n");
                while (true)
                {
                    byte[] Buffer = new byte[1024];
                    Socket_Client.Receive(Buffer);
                    Console.Out.WriteLine(Encoding.UTF8.GetString(Buffer).Trim((char)0));
                    string Input = Console.In.ReadLine();
                    Socket_Client.Send(Encoding.UTF8.GetBytes(Input));
                }
                Socket_Client.Close();
            }
            catch (Exception Socket_Exception)
            {
                Console.Error.Write(Socket_Exception.Message);
            }
        }
    }
}