using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationBasic
{
    class FastSend
    {
        void SendString(byte[] msg, IPEndPoint ep)
        {
            UdpClient client = new UdpClient(ep);
            client.Connect(ep);

            client.Send(msg, msg.Length);
        }

        public void KeepSend(IPEndPoint ep, byte[] msg)
        {
            try
            {
                SendString(msg, ep);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
    }
}
