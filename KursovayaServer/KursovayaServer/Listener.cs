using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;


namespace KursovayaServer
{
    class Listener
    {
        // Master socket
        private TcpListener _TcpListener = null;

        //Address settings
        private IPAddress _IPAddress = null;
        private int _Port = 0;

        //Lists
        private static List<Session> _Sessions = new List<Session>();

        //Utilities
        private Stopwatch _Stopwatch = null;

        //Events
        public delegate void ClientDisconnected(Session session);
        public delegate void ClientConnected(TcpClient session);
        public event ClientDisconnected ClientDisconnectedEvent;
        public event ClientConnected ClientConnectedEvent;

        public Listener(string listenerIp, int port)
        {
            if (String.IsNullOrEmpty(listenerIp)) throw new ArgumentNullException(nameof(listenerIp));
            if (port < 0) throw new ArgumentException("Порт должен быть больше 0.");

            _IPAddress = IPAddress.Parse(listenerIp);
            _Port = port;

            _TcpListener = new TcpListener(_IPAddress, _Port);
            _Stopwatch = new Stopwatch();

            ClientDisconnectedEvent += OnClientDisconnected;
            ClientConnectedEvent += OnClientConnected;
        }

        public void StartServer()
        {
            _TcpListener.Start();
            _Stopwatch.Start();

            Task.Run(() => AcceptClients()).GetAwaiter();

            Task.Run(() => CheckSessions()).GetAwaiter();

            ShowServerConfig();
        }

        private async void AcceptClients()
        {
            while (true)
            {
                var client = await _TcpListener.AcceptTcpClientAsync();
                if (client != null)
                {
                    ClientConnectedEvent?.Invoke(client);
                }
                Thread.Sleep(1000);
            }
        }

        private void CheckSessions()
        {
            while (true)
            {
                var session = _Sessions.FirstOrDefault(s => s.Client.Connected == false);
                if (session != null)
                {
                    ClientDisconnectedEvent?.Invoke(session);
                }
                Thread.Sleep(1000);
            }
        }

        private void OnClientDisconnected(Session session)
        {
            Console.WriteLine("Клиент отключился.");
            session.Client.Client.Close();
            _Sessions.Remove(session);
        }

        private void OnClientConnected(TcpClient client)
        {
            _Sessions.Add(new Session(client));

            var SessionThread = new Thread(new ThreadStart(_Sessions[_Sessions.Count - 1].Main));
            SessionThread.Start();

            Console.WriteLine("Клиент подключился!");
        }

        private void ShowServerConfig()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"IP адрес: {_IPAddress.ToString()}");
                Console.WriteLine($"Порт: {_Port}");
                Console.WriteLine($"Тип протокола: {_TcpListener.Server.ProtocolType}");
                Console.WriteLine($"Тип сокета: {_TcpListener.Server.SocketType}");
                Console.WriteLine($"Подключено клиентов: {_Sessions.Count}");
                Console.WriteLine($"Время работы: {String.Format("{0:00}:{1:00}:{2:00}", _Stopwatch.Elapsed.Hours, _Stopwatch.Elapsed.Minutes, _Stopwatch.Elapsed.Seconds)}");
                Thread.Sleep(1000);
            }
        }
    }
}
