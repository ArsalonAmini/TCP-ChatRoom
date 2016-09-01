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
        IPAddress localAddress = IPAddress.Parse("10.2.20.34");
        Int32 port = 10000;
        TcpClient client;
        string responseData = string.Empty; //string to store ASCII response
   
        public Client()
        {
            client = new TcpClient("10.2.20.34", port); //constructor
        }
        public void Connect ()
        {
            while (true)
            {
                Console.WriteLine("Enter Message:");
                message = Console.ReadLine();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); //converts string message to ASCII zeros and ones code, stores ints into byte array called data
                NetworkStream stream = client.GetStream(); //create variable stream, type networkstream, assign return client stream
                stream.Write(data, 0, data.Length); //send message to connected TcpServer //don't know what this line does

                /*Console.WriteLine("Sent: {0}", message);*/ //sends 

                //receiving own data // how to recieve data from server 
                //data = new Byte[256]; //buffer to store response bytes (response from server)

                //Int32 bytes = stream.Read(data, 0, data.Length);  //read server data to stream client stream

                //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes); //convert server bytes to client string
                //Console.WriteLine("Recieved: {0}", responseData);
                //Console.ReadLine();
            }
            //stream.Close(); //close streaming connection 
            //client.Close(); //close client 
      
        }

    }
}
