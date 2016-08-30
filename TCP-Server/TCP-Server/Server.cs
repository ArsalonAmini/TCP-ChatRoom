using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCP_Server
{
    class Server
    {
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        int i;
        string data;
        Int32 port = 1300;
        IPAddress localAddress = IPAddress.Parse("10.2.20.253");
        TcpListener server;
        NetworkStream stream;

        public Server()
        {
            TcpListener server = new TcpListener(localAddress, 1000); //constructor //transmission control server
            data = null;
        }

        public void AcceptTcpClient()
        {
            server.AcceptTcpClient();
        }

        public void AcceptSocket()
        {
            server.AcceptSocket();
        }

        public void Start()
        {
            byte[] bytes = new Byte[1024]; //buffer for reading data
            server.Start(); //start listening for client requests

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                NetworkStream stream = client.GetStream(); //instantiating/assigning stream object for reading and writing

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) //reiceve client data loop
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i); //translate data bytes to ASCII string
                    Console.WriteLine("Sent: {0}", data);

                    data = data.ToUpper(); //processing data sent by client

                    byte[] message = System.Text.Encoding.ASCII.GetBytes(data);

                    //send message back
                    stream.Write(message, 0, message.Length);
                    Console.WriteLine("Sent: {0}", data);

                    client.Close(); //shutdown and end connection
                }
                server.Stop(); //stop listening for new clients
            }

        }
    }
}
