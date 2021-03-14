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
                SocketAsyncEventArgs recvE = new SocketAsyncEventArgs();
                SocketAsyncEventArgs sendE = new SocketAsyncEventArgs();
                sendE.SetBuffer(Encoding.UTF8.GetBytes("Hello World!"), 0, 12);
                sendE.Completed += sendE_Completed;
                recvE.Completed += recvE_Completed;
                Socket Sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint IPEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10101);
                Sock.Connect(IPEP);
                Sock.SendAsync(sendE);
                Sock.ReceiveAsync(recvE);
                while (true) ;
            }
            catch(Exception Socket_Exception)
            {
                Console.Error.Write(Socket_Exception.Message);
            }
        }

        private static void recvE_Completed(object sender, SocketAsyncEventArgs e)
        {
            Console.Out.Write("Received: " + Encoding.UTF8.GetString(e.Buffer));
        }

        private static void sendE_Completed(object sender, SocketAsyncEventArgs e)
        {
            Console.Out.WriteLine("Sended!");
        }
    }
}