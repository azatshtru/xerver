using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace CommunicationBasic
{
    class Client
    {
        int id;
        public TcpClient client;
        public IPEndPoint clientEndPoint;

        public Client(int _id, TcpClient _client)
        {
            id = _id;
            client = _client;

            ThreadStart job = new ThreadStart(ThreadSend);
            Thread thread = new Thread(job);
            thread.Start();
        }

        void ThreadSend()
        {
            RecieveData dataReciever = new RecieveData();
            //FastRecieve fastReciever = new FastRecieve();

            IPAddress clientIPAddress = IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            IPEndPoint listenEndPoint = new IPEndPoint(clientIPAddress, Program.port);
            clientEndPoint = listenEndPoint;

            dataReciever.KeepRecieve(client);
            //fastReciever.KeepRecieve(listenEndPoint);
        }
    }
}