using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.ListenForRequests();
            server.AddClientsToList();
            server.ReceiveMessages();
            server.SendBroadCastMessages();
        }
    }
}
