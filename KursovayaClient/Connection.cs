using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaCSharp
{
    public static class Connection
    {
        const int port = 8080;
        const string address = "127.0.0.1";

        public static TcpClient Client { get; set; } = null;

        public static NetworkStream NetworkStream { get; set; } = null;

        public static BinaryFormatter BinaryFormatter { get; } = new BinaryFormatter();

        public static void Connect()
        {
            Client = new TcpClient(address, port);
            NetworkStream = Client.GetStream();
        }
    }
}
