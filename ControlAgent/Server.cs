using System;
using System.Collections.Generic;
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
            _logger = new Logger();
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
                _reader = new StreamReader(_client.GetStream());
                try
                {
                    //Client has requested an action
                    string requestRaw = _reader.ReadLine();
                    string[] delim = { @"\|/" };
                    string[] request = requestRaw.Split(delim, StringSplitOptions.None);

                    //Check if API key is valid
                    if (Config.GetApiKeys().Contains(request[0]))
                    {
                        //Valid API key sent
                        Commands.Command command = (Commands.Command)Enum.Parse(typeof(Commands.Command), request[1]);
                        List<string> output = Commands.RunCommand(command);
                        foreach (string line in output)
                        {
                            _writer.WriteLine(line);
                        }

                        //Send data back to client
                        _writer.Flush();
                    }
                    else
                    {
                        //API key was not found in the list
                        _writer.WriteLine("API Key Not Valid");

                        //Send data back to client
                        _writer.Flush();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError("Invalid command received");
                    _writer.Write("Invalid command received");
                    _writer.Flush();
                    _client.Close();
                    break;
                }
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
