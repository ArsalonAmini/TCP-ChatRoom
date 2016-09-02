using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

//This is a TCP chatroom created during devCodeCamp during week #5 by A.Amini-Hajibashi

namespace TCP_Server
{
    class Server
    {
        
        public static Hashtable clientsList;
        IPAddress localAddress;
        TcpListener chatServer;
        TcpClient clientSocket;
        NetworkStream networkStream;
        int i;
        int counter;
        public byte[] buffer;
        public byte[] bytesFrom;
        string dataFromClient;
        public const int BufferSize = 1024;
        Int32 port = 10000;

        public Server()
        {
            localAddress = IPAddress.Parse("10.2.20.34");
            chatServer = new TcpListener(localAddress, port); //constructor //transmission control server
            clientSocket = new TcpClient();
            clientsList = new Hashtable();
            buffer = new byte[BufferSize];
            bytesFrom = new byte[1024];
            dataFromClient = null;
            counter = 0;
        }

        public void Start()
        {
            chatServer.Start(); //start listening for client requests
            Console.WriteLine("Waiting for a connection...");
            while (true)
            {
                counter += 1;
                clientSocket = chatServer.AcceptTcpClient(); //creating a member variable, type TcPclient to store accepted client                     
                Console.WriteLine("Connected!");
                networkStream = clientSocket.GetStream();

                networkStream.Read(bytesFrom, 0, bytesFrom.Length); //read client stream
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);  //encode message
                Console.WriteLine("Received: {0}", dataFromClient);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));


                clientsList.Add(dataFromClient, clientSocket); //add message and TcPClient to hashlist 
                
                BroadCastClientMessage(dataFromClient + "Joined", dataFromClient, false); //broadcast function to send message to all 

                Console.WriteLine(dataFromClient + "Joined Chat Room");
            }
        }
        
        public static void BroadCastClientMessage (string message, string userName, bool flag)
        {
            foreach(DictionaryEntry Item in clientsList)
            {
                TcpClient broadcastSocket;
                broadcastSocket = (TcpClient)Item.Value;
                NetworkStream broadcastStream = broadcastSocket.GetStream();
                Byte[] broadcastBytes = null;

                if (flag == true)
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(userName + "says:" + message);
                }
                else
                {
                    broadcastBytes = Encoding.ASCII.GetBytes(userName);
                }
                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
                broadcastStream.Flush();
            }
        }
    }
}
    
    
       
