using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationBasic
{
    class SendData
    {
        void SendString(byte[] msg, TcpClient client)
        {
            NetworkStream stream;

            stream = client.GetStream();

            stream.Write(msg, 0, msg.Length);
        }

        public void KeepSend (TcpClient client, string msg)
        {
            try
            {
                byte[] msgInBytes = Encoding.ASCII.GetBytes(msg);
                SendString(msgInBytes, client);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }

        public void KeepSend(TcpClient client, byte[] msg)
        {
            try
            {
                SendString(msg, client);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
    }
}
