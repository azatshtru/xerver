using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace CommunicationBasic
{
    class RecieveData
    {
        byte[] RecieveString(TcpClient client)
        {

            NetworkStream stream;

            stream = client.GetStream();

            byte[] bytes = new byte[2048];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);
            byte[] bytesToSend = new byte[bytesRead];
            Array.Copy(bytes, bytesToSend, bytesRead);

            //string recievedMsg = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            //Console.WriteLine($"Message from Client: " + recievedMsg);

            return bytesToSend;
        }

        public void KeepRecieve(TcpClient client)
        {
            while (true)
            {

                Thread.Sleep(15);

                try
                {
                    byte[] s = RecieveString(client);

                    Console.WriteLine(s);

                    Program.Send(client, s);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e}");
                }
            }          
        }
    }
}
