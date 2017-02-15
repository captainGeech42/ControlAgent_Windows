using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ControlAgent
{
    class Server_old
    {
        private string _ip;
        private Int32 _port;

        private readonly Logger _logger;

        private bool _running = false;
        private Thread _myThread;

        private readonly List<string> _apiKeys = new List<string>()
        {
            //TODO this feels really sketchy, most definitely can and should be done better
            "testAPIkey1234"
        };

        public Server_old(string ip, Int32 port)
        {
            this._ip = ip;
            this._port = port;

            _logger = new Logger();
        }

        public void Start()
        {
            _running = true;
            _myThread = new Thread(this.RunTcpServer);
            _myThread.IsBackground = true;
            _myThread.Start();
        }

        public void Stop()
        {
            _running = false;
            _myThread.Join();
        }

        public void RunTcpServer()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse(_ip), _port);
            listener.Start();

            while (_running)
            {
                if (listener.Pending()) continue;
                TcpClient client = listener.AcceptTcpClient();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());
                try
                {
                    //Client has requested an action
                    string requestRaw = sr.ReadLine();
                    string[] delim = new string[] { "\\|/" };
                    string[] request = requestRaw.Split(delim, StringSplitOptions.None);

                    //Check if API key is valid
                    if (_apiKeys.Contains(request[0]))
                    {
                        //Valid API key sent
                        Commands.Command command = (Commands.Command)Enum.Parse(typeof(Commands.Command), request[1]);
                        List<string> output = Commands.RunCommand(command);
                        foreach(string line in output)
                        {
                            sw.WriteLine(line);
                        }

                        //Send data back to client
                        sw.Flush();
                    }
                    else
                    {
                        //API key was not found in the list
                        sw.WriteLine("API Key Not Valid");

                        //Send data back to client
                        sw.Flush();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.ToString());
                    client.Close();
                    break;
                }
                Thread.Sleep(100);
            }
            listener.Stop();
        }
    }
}
