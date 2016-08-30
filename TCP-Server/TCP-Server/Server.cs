using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace TCP_Server
{
    class Server
    {
        public const int BufferSize = 1024;
        public byte[] buffer = new byte[BufferSize];
        int i;
        string data = null;
        string IPAddress;
        TcpListener listener; 

        public Server()
        {
            TcpListener listener = new TcpListener("10.2.20.253"); //constructor
            NetworkStream stream = new NetworkStream(listener);
        }

        public void AcceptTcpClient()
        {
            listener.AcceptTcpClient();
        }

        public void AcceptSocket()
        {
            listener.AcceptSocket();
        }

        public void Start()
        {
            byte[] bytes = new Byte[1024];
            listener.Start();
            
            try
            {
                listener.AcceptTcpClient(IPAddress);
                
                while(true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAcceptSocket()
                }
            }








        }

        public void RecieveMessages()
        {
            //listening loop
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Connected!");


                //stream object for reading and writing
                NetworkStream stream = client.GetStream();

                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    //translate data bytes to ASCII string
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Recieved: (0)", data);

                    //Process data sent by client
                    data = data.ToUpper();
                }

            }
        }
        public void Stop()
        {
            //closes the listener
            listener.Stop();
        }

        //public void DisplayMessage()
        //{
        //    if (content.IndexOf("<EOF>") > -1) //all data has been read, display message
        //    {
        //        //Console.WriteLine("Read {0} bytes from socket. \n Data: {1}", content.Length, content);
        //        //Send(handler, content); //echo data back to client
        //    }
        //    else
        //    {
        //        socket.BeginRecieve()

        //    }
        //}

       


    }
}
