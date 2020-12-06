using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MainSpace
{
    class MainClass
    {
        private static void Main(string[] _Args)
        {
            try
            {
                Console.Out.Write("Client end program\n\n");
                Console.Out.Write("Server IP? ");
                string Server_IP = Console.In.ReadLine();
                Console.Out.Write("Server Port? ");
                string Server_Port = Console.In.ReadLine();
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse(Server_IP), int.Parse(Server_Port));
                Socket Socket_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket_Client.Connect(IPEP);
                Console.Out.Write("Connected!\n\n");
                while (true)
                {
                    string Input = Console.In.ReadLine();
                    Socket_Client.Send(Encoding.UTF8.GetBytes(Input));
                    byte[] Buffer = new byte[1024];
                    Socket_Client.Receive(Buffer);
                    Console.Out.WriteLine(Encoding.UTF8.GetString(Buffer).Trim((char)0));
                }
                Socket_Client.Close();
            }
            catch(Exception Socket_Exception)
            {
                Console.Error.Write(Socket_Exception.Message);
            }
        }
    }
}