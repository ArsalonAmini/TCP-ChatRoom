using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Net;

//This is a TCP chatroom created during devCodeCamp during week #5 by A.Amini-Hajibashi

namespace Server
{
    class Server
    {
        public static Hashtable clientsList;
        IPAddress localAddress;
        TcpListener server;
        TcpClient clientSocket;
        NetworkStream networkStream;
        Int32 port = 10000;
        string dataFromClient;
        public byte[] buffer;
        public byte[] bytesFrom;
        public const int BufferSize = 1024; 
        int i;

        public Server()
        {
            localAddress = IPAddress.Parse("10.2.20.34");
            server = new TcpListener(localAddress, port);
            clientSocket = new TcpClient();
            clientsList = new Hashtable();
            buffer = new byte[BufferSize];
            bytesFrom = new byte[1024];
            dataFromClient = null;
            counter = 0;
        }

        public void AcceptClient()
        {
            byte[] bytes = new Byte[1024]; //buffer for reading data                          
            server.Start(); //method of the TcP listener class

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");

               
                TcpClient client = server.AcceptTcpClient(); 
                Console.WriteLine("Connected!");
                
                NetworkStream stream = client.GetStream(); 
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) 
                {
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytes, 0, i); 
                    Console.WriteLine("Received: {0}", dataFromClient);
                    byte[] message = System.Text.Encoding.ASCII.GetBytes(dataFromClient);

                    //send message back
                    //stream.Write(message, 0, message.Length);
                    //Console.WriteLine("Recieved: {0}", data);
                    //Console.ReadLine();

                }

                server.Stop(); //stop listening for new clients
                client.Close(); //shutdown and end connection
            }


        }

    }
}
