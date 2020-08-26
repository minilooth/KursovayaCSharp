using System;

namespace KursovayaServer
{
    class Program
    {
        const int port = 8080;
        const string ipAdress = "127.0.0.1";

        static void Main(string[] args)
        {
            Listener listener = new Listener(ipAdress, port);

            listener.StartServer();

        }
    }
}
