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
        private readonly Logger _logger;
        private Server _server;

        public MainWindow()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.Load += MainWindow_Load;

            _logger = new Logger();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ipDropdown.DataSource = new BindingSource(GetIPv4Address(), null);
            label_statusdetails.Text = @"Not Running";
        }

        private List<string> GetIPv4Address()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            List<string> ipAddresses = new List<string>();
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
            _server = new Server(ipadr, port);
            _server.Start();
            _logger.LogState(Logger.State.Enabled, ipadr, port);

            ToggleUiState(State.Disable);

            label_statusdetails.Text = @"Running on " + ipadr + @":" + port;
        }

        private void button_disable_Click(object sender, EventArgs e)
        {
            //serverThread.Abort();
            _server.Stop();
            _logger.LogState(Logger.State.Disabled);

            ToggleUiState(State.Enable);

            label_statusdetails.Text = @"Not Running";
        }

        private void button_config_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();
        }

        private void ToggleUiState(State state)
        {
            switch (state)
            {
                case State.Enable:
                    button_enable.Enabled = true;
                    ipDropdown.Enabled = true;
                    portSelector.Enabled = true;
                    button_disable.Enabled = false;
                    break;
                case State.Disable:
                    button_disable.Enabled = true;
                    ipDropdown.Enabled = false;
                    portSelector.Enabled = false;
                    button_enable.Enabled = false;
                    break;
            }
        }

        private enum State
        {
            Enable,
            Disable
        }
    }
}