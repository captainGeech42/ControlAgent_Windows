using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ControlAgent
{
    class Server
    {
        private string ip;
        private Int32 port;

        private Logger logger;

        private List<string> apiKeys = new List<string>()
        {
            "oG364cMBvfMBayXAGPZLr4DQRVouIPnf"
        };

        public Server(string ip, Int32 port)
        {
            this.ip = ip;
            this.port = port;

            logger = new Logger();
        }

        public void runTcpServer()
        {
            TcpListener listener = new TcpListener(System.Net.IPAddress.Parse(ip), port);
            listener.Start();

            while (true)
            {
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
                    if (apiKeys.Contains(request[0]))
                    {
                        //Valid API key sent
                        Commands.Command command = (Commands.Command)Enum.Parse(typeof(Commands.Command), request[1]);
                        List<string> output = Commands.runCommand(command);
                        foreach(string line in output)
                        {
                            sw.WriteLine(line);
                        }

                        //If output is empty, command was invalid
                        //if (!output.Any())
                        //{
                        //    sw.WriteLine("Invalid command received");
                        //}

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
                    logger.LogError(e.ToString());
                    client.Close();
                    break;
                }
            }
        }
    }
}
