using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CommunicationBasic
{
    class FastRecieve
    {
        byte[] RecieveString(IPEndPoint iPEndPoint)
        {
            UdpClient uClient = new UdpClient(iPEndPoint);
            uClient.Connect(iPEndPoint);
            byte[] bytes = uClient.Receive(ref iPEndPoint);

            //string recievedMsg = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            //Console.WriteLine($"Message from Client: " + recievedMsg);

            return bytes;
        }

        public void KeepRecieve(IPEndPoint iPEndPoint)
        {

            while (true)
            {
                Thread.Sleep(10);
                try
                {
                    byte[] s = RecieveString(iPEndPoint);

                    Console.WriteLine(s);

                    Program.Send(iPEndPoint, s);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                }
            }
        }
    }
}
