using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ControlAgent
{
    public partial class MainWindow : Form
    {
        private Logger logger;
        //private Thread serverThread;

        public MainWindow()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.Load += MainWindow_Load;

            logger = new Logger();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ipDropdown.DataSource = new BindingSource(GetIPv4Address(), null);
            label_statusdetails.Text = "Not Running";
        }

        private List<string> GetIPv4Address()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            List<String> ipAddresses = new List<String>();
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddresses.Add(ip.ToString());
                }
            }
            if (ipAddresses.Any())
            {
                return ipAddresses;
            }
            else
            {
                throw new Exception("Local IP Address Not Found!");
            }
        }

        private void button_enable_Click(object sender, EventArgs e)
        {
            string ipadr = ipDropdown.SelectedItem.ToString();
            Int32 port = Int32.Parse(portSelector.Value.ToString());
            Server server = new ControlAgent.Server(ipadr, port);
            //serverThread = new Thread(server.runTcpServer);
            //serverThread.IsBackground = true;
            //serverThread.Start();
            logger.LogState(Logger.State.ENABLED, ipadr, port);

            button_disable.Enabled = true;
            ipDropdown.Enabled = false;
            portSelector.Enabled = false;
            button_enable.Enabled = false;

            label_statusdetails.Text = "Running on " + ipadr + ":" + port;
            //await Task.Run(() => server.runAsyncTcpServer());
        }

        private void button_disable_Click(object sender, EventArgs e)
        {
            //serverThread.Join();
            //serverThread.Abort();
            logger.LogState(Logger.State.DISABLED);

            button_enable.Enabled = true;
            ipDropdown.Enabled = true;
            portSelector.Enabled = true;
            button_disable.Enabled = false;

            label_statusdetails.Text = "Not Running";
        }

        private void button_about_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
    }
}