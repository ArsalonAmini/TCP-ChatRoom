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
        Int32 port = 10000;
        IPAddress localAddress = IPAddress.Parse("10.2.20.26");
        TcpListener server;
        Dictionary<Client, string> dictionary;

        public Server()
        {
            server = new TcpListener(localAddress, port); //constructor //transmission control server
            data = null;
            List<Client> clientList = new List<Client>(); //create a list clientlist to store client in dictionary
        }


        public void Start()
        {
            byte[] bytes = new Byte[1024]; //buffer for reading data                          
            server.Start(); //start listening for client requests

            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = server.AcceptTcpClient(); //creating a member variable, type TcPclient to store accepted client 
                Dictionary.
                Console.WriteLine("Connected!");
                NetworkStream stream = client.GetStream(); //creating a member variable, type Networkstream to store client stream

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) //reiceve client data loop
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i); //translate data bytes to ASCII string
                    Console.WriteLine("Received: {0}", data);

                    byte[] message = System.Text.Encoding.ASCII.GetBytes(data);

                    //send message back
                    stream.Write(message, 0, message.Length);
                    Console.WriteLine("Recieved: {0}", data);
                    Console.ReadLine();
                }
            }
        }
    }
}
    
    
        

    //}


        //server.Stop(); //stop listening for new clients
        //client.Close(); //shutdown and end connection
//    }
//}
