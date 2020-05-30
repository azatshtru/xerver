using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommunicationBasic
{
    class RecieveData
    {
        string RecieveString(TcpClient client)
        {

            NetworkStream stream;

            stream = client.GetStream();

            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);

            string recievedMsg = Encoding.ASCII.GetString(bytes, 0, bytesRead);
            Console.WriteLine($"Message from Client: " + recievedMsg);

            return recievedMsg;
        }

        public void KeepRecieve(TcpClient client)
        {
            while (true)
            {
                try
                {
                    string s = RecieveString(client);

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
