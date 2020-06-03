using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace CommunicationBasic
{
    class Program
    {
        static int port = 26950;
        static int numPlayers = 2;

        static SendData dataSender = new SendData();

        static TcpListener tcpListener;
        static Dictionary<int, Client> tcpClients = new Dictionary<int, Client>();

        static void Main(string[] args)
        {
            Console.Title = "Server";

            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            Console.WriteLine("Started listening for communication.");

            GetClient();
        }

        static void GetClient()
        {
            int i = 0;
            while (i < numPlayers)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Client client = new Client(i, tcpClient);
                tcpClients.Add(i, client);

                Console.WriteLine("Incomming connection.");

                i++;
            }
            for(int x = 0; x < tcpClients.Count; x++)
            {
                dataSender.KeepSend(tcpClients[x].client, "serverstart");
            }
        }

        public static void Send(TcpClient sender, byte[] msg)
        {
            for (int i = 0; i < tcpClients.Count; i++)
            {
                if(tcpClients[i].client == sender)
                {
                    continue;
                }
                dataSender.KeepSend(tcpClients[i].client, msg);
            }
        }
    }
}
