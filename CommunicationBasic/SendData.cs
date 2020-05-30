using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationBasic
{
    class SendData
    {
        void SendString(string msg, TcpClient client)
        {
            NetworkStream stream;

            byte[] msgInBytes = Encoding.ASCII.GetBytes(msg);

            stream = client.GetStream();

            stream.Write(msgInBytes, 0, msgInBytes.Length);
        }

        public void KeepSend (TcpClient client, string msg)
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
