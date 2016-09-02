using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    class Client
    {
        string message;
        IPAddress localAddress;
        Int32 port = 10000;
        TcpClient client;
        string responseData; 

        public Client()
        {
            localAddress = IPAddress.Parse("10.2.20.34");
            client = new TcpClient("10.2.20.34", port);
            responseData = string.Empty;
        }
        public void Connect()
        {

            while (true)
            {
                //send message to server
                Console.WriteLine("Enter Message:");
                message = Console.ReadLine();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message); //converts string message to ASCII zeros and ones code, stores ints into byte array called data
                NetworkStream stream = client.GetStream(); //create variable stream, type networkstream, assign return client stream
                stream.Write(data, 0, data.Length); //write data to stream 
                Console.WriteLine("Sent: {0}", message); //sends 

                //recieve message from server
                data = new Byte[256]; //buffer to store response bytes (response from server)
                Int32 bytes = stream.Read(data, 0, data.Length);  //read data from stream
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes); //convert server bytes (read) into string 
                Console.WriteLine("Recieved: {0}", responseData);
                Console.ReadLine();
            }
            //stream.Close(); //close streaming connection 
            //client.Close(); //close client 

        }
    }
}
