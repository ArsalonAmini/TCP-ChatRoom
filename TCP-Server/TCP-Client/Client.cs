using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows;

namespace TCP_Client
{
    class Client
    {
        NetworkStream serverStream;
        NetworkStream stream;
        TcpClient clientSocket;
        IPAddress localAddress;
        Thread clientThread;
        string readData;
        string responseData; //string to store ASCII response
        Int32 port;
        string returnData;
        byte[] outData;
        byte[] inStream;
        int bufferSize;

        public Client()
        {
            port = 10000;
            clientSocket = new TcpClient("10.2.20.34", port); //constructor
            readData = "Connected to Arsalon's Chat Server....";
            Console.WriteLine(readData);
            serverStream = default(NetworkStream);
            serverStream = clientSocket.GetStream();
            localAddress = IPAddress.Parse("10.2.20.34");
            readData = null;
            inStream = new byte[65536];
            responseData = string.Empty;
            outData = System.Text.Encoding.ASCII.GetBytes("asddf");
            returnData = System.Text.Encoding.ASCII.GetString(inStream);
            stream = clientSocket.GetStream();
            bufferSize = clientSocket.ReceiveBufferSize;
            clientThread = new Thread(GetMessage);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            serverStream.Write(outData, 0, outData.Length);
            serverStream.Flush();
        }
        public void SendMessage()
        {
            serverStream.Write(outData, 0, outData.Length);
            serverStream.Flush();
        }

        public void GetMessage ()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                serverStream.Read(inStream, 0, bufferSize);
                returnData = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returnData;
                
            }
        }
    }
}
