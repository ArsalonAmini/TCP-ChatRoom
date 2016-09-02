using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows;


namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        Int32 port;
        byte[] outData;
        byte[] inStream;
        string message;
        public Client()
        {
            port = 10000;
            
        }
        public void ConnectToServer()
        {
            clientSocket = new TcpClient("10.2.20.34", port);
            stream = clientSocket.GetStream();
        }

        public void SendMessage()
        {
            Console.WriteLine("Enter Message:");
            message = Console.ReadLine();
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);

        }
        public void GetMessage()
        {
            inStream = new Byte[256];
            Int32 bytes = stream.Read(inStream, 0, inStream.Length);

        }

    }
}
