using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Net;


namespace Chatroom
{
    class Server
    {
        //create a TCP listener
        //accept a TCP client
        //create a network stream
        //read from network stream 
        IPAddress localAddress;
        TcpListener chatServer;
        TcpClient clientSocket;
        NetworkStream networkStream;
        string dataFromClient;
        public byte[] bytesFrom;
        Hashtable clientsList;
        Int32 port = 10000;

        public Server()
        {
            localAddress = IPAddress.Parse("10.2.20.34");
            chatServer = new TcpListener (localAddress, port);
            clientsList = new Hashtable();
        }
        public void ListenForRequests()
        {
            chatServer.Start(); //start listening for clients 
            Console.WriteLine("Waiting for a connection...");
        }

        public void AcceptIncomingRequests()
        {
            clientSocket = chatServer.AcceptTcpClient(); //creating a member variable, type TcPclient to store accepted client                     
            Console.WriteLine("Connected!");
        }

        public void ReceiveMessages()
        {
            networkStream = clientSocket.GetStream();
            networkStream.Read(bytesFrom, 0, bytesFrom.Length); //read client stream
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);  //encode message
            Console.WriteLine("Received: {0}", dataFromClient);
        }

        public void SendBroadCastMessages()
        {
            foreach(DictionaryEntry Item in clientsList)
            {
                //
            }
        }

        public void AddClientsToList()
        {
            clientsList.Add(dataFromClient, clientSocket);
        }
    }
}
