using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ControlAgent
{
    class Server
    {
        private Logger _logger;

        private Thread _thread;
        private Boolean _running = false;
        private readonly ManualResetEvent _clientConnected = new ManualResetEvent(false);

        private TcpListener _listener;
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;

        public Server(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void Start()
        {
            _thread = new Thread(RunTcpServer);
            _thread.Name = "TCP Listener Thread";
            _running = true;
            _thread.Start();
        }

        public void Stop()
        {
            _listener.Stop();
            _running = false;
        }

        public void RunTcpServer()
        {
            while (_running)
            {
                _listener.Start();
                DoBeginAcceptTcpClient(_listener);
                _writer = new StreamWriter(_client.GetStream());
                _writer.Write("received message");
                _writer.Flush();
                _client.Close();
                _listener.Stop();
            }
        }

        private void DoBeginAcceptTcpClient(TcpListener listener)
        {
            _clientConnected.Reset();
            listener.BeginAcceptTcpClient(DoAcceptTcpClientCallback, listener);
            _clientConnected.WaitOne();
        }

        private void DoAcceptTcpClientCallback(IAsyncResult ar)
        {
            try
            {
                _listener = (TcpListener)ar.AsyncState;
                _client = _listener.EndAcceptTcpClient(ar);
                _clientConnected.Set();
            }
            catch (ObjectDisposedException e)
            {
                //intentionally empty catch
            }
        }
    }
}
