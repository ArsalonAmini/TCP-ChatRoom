using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace Server
{
    class Chat
    {
        TcpClient clientSocket;
        Hashtable clientsList;
        Thread customerThread;
       // NetworkStream networkStream;
        TcpListener server;
        
        string dataFromClient;
        //string clientName;
        byte[] bytesFrom;
        //byte[] bytesTo;

        public Chat(TcpClient clientSocket, NetworkStream networkStream, Hashtable clientList)
        {
            this.clientsList = clientList;
            this.clientSocket = clientSocket;
            networkStream = clientSocket.GetStream();
            //customerThread = new Thread(runChat(networkStream));
            //customerThread.Start();
            bytesFrom = new byte[65536];
            dataFromClient = null;
        }
        public void runChat(NetworkStream networkStream)
        {
            networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom); //converting network stream data to bytes ->string
            Console.WriteLine("From Client - " + /*clientName*/  ":" + dataFromClient);
            //server.BroadCastClientMessage(dataFromClient, clientSocket)

        }
    }

}
