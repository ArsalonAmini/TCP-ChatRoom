using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCP_Client
{
    class Client
    {
        String server;
        String message;
        Int32 port = 10000;
        TcpClient client;
        string responseData = string.Empty; //string to store ASCII response
        public Client()
        {
            
            TcpClient client = new TcpClient(server, port); //constructor
        }
        public void Connect ()
        {

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); //translate passed message into ASCII and store as a byte array

            NetworkStream stream = client.GetStream(); //client stream ready for reading/writing

            stream.Write(data, 0, data.Length); //send message to connected TcpServer
    
            Console.WriteLine("Sent: {0}", message);

            data = new Byte[256]; //buffer to store response bytes

            Int32 bytes = stream.Read(data, 0, data.Length);

            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Recieved: {0}", responseData);

            stream.Close(); //close everything
            client.Close(); 
      
        }

    }
}
