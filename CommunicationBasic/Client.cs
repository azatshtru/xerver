using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace CommunicationBasic
{
    class Client
    {
        int id;
        public TcpClient client;

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
            dataReciever.KeepRecieve(client);
        }
    }
}