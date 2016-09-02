using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Net;

//This is a TCP chatroom created during devCodeCamp during week #5 by A.Amini-Hajibashi

namespace Server
{
    class Server
    {
        public static Hashtable clientsList;
        IPAddress localAddress;
        TcpListener server;
        TcpClient clientSocket;
        public NetworkStream networkStream;
        Chat chat;
        Int32 port = 10000;
        string nameOfClient;
        public byte[] buffer;
        public byte[] bytesFrom;
        public const int BufferSize = 1024; 
        int i;

        public Server()
        {
            localAddress = IPAddress.Parse("10.2.20.34");
            server = new TcpListener(localAddress, port);
            clientSocket = new TcpClient();
            clientsList = new Hashtable();
            //networkStream = clientSocket.GetStream();
            buffer = new byte[BufferSize];
            bytesFrom = new byte[1024];
            nameOfClient = null;
            //counter = 0;
        }

        public void AcceptClient()
        {
            server.Start(); //method of the TcP listener class
            Console.WriteLine("Waiting for a connection...");

            while (true)
            {
                clientSocket = server.AcceptTcpClient();
                Console.WriteLine("Connected!");
                networkStream = clientSocket.GetStream();
            }
        }

        public void lookForClient

        pubic void GetClientMessage
                networkStream.Read(bytesFrom, 0, bytesFrom.Length);
                nameOfClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                Console.WriteLine("Welcome: {0}", nameOfClient);
                clientsList.Add(nameOfClient, clientSocket); //nameOfClient = key, clientSocket = value
                chat = new Chat(clientSocket, networkStream, clientsList);
                chat.runChat(networkStream);

                //send message back
                byte[] message = System.Text.Encoding.ASCII.GetBytes(nameOfClient);
                networkStream.Write(message, 0, message.Length);
                Console.WriteLine("Recieved: {0}", nameOfClient);
                Console.ReadLine();

                }

                //server.Stop(); //stop listening for new clients
                //client.Close(); //shutdown and end connection
            }

        public void BroadCastClientMessage()
        {

        }

        }
        

        }
    


