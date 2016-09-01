using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Collections;

namespace TCP_Server
{
    class Connection
    {
        TcpClient clientSocket;
        Hashtable clientsList;
        Thread customerThread;
        NetworkStream networkStream;
        string clientNumber;
        string dataFromClient;
        string serverResponse;
        string returnCount;
        int requestCount;
        byte[] bytesFrom;
        byte[] sendBytes;

        public Connection(TcpClient clientSocket, string clientNumber, Hashtable clientsList)
        {
            this.clientSocket = clientSocket;
            this.clientNumber = clientNumber;
            this.clientsList = clientsList;
            customerThread = new Thread(runChat);
            networkStream = clientSocket.GetStream();
            customerThread.Start();
            bytesFrom = new byte[1024];
            dataFromClient = null;
            serverResponse = null;
            returnCount = null;
            requestCount = 0;
        }

        public void runChat()
        {
            while ((true)) //Observer pattern (Design pattern) A. Amini-Hajibashi
            {
                try
                {
                    requestCount = requestCount + 1;
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    //dataFromClient = dataFromClient.Substring(0, dataFromClient.Indexof("$"));
                    Console.WriteLine("From Client - " + clientNumber + ":" + dataFromClient);
                    returnCount = Convert.ToString(requestCount);

                    Server.BroadCastClientMessage(dataFromClient, clientNumber, true);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }
    }
}
