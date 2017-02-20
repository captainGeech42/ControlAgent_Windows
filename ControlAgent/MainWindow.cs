using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;

namespace ControlAgent
{
    public partial class MainWindow : Form
    {
        private readonly Logger _logger;
        private Server _server;
        private NotifyIcon _notifyIcon;
        private Assembly _assembly;

        public MainWindow()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();

            this.Load += MainWindow_Load;
            this.Resize += MainWindow_Resize;

            _logger = new Logger();

            _assembly = Assembly.GetExecutingAssembly();

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new Icon(_assembly.GetManifestResourceStream(@"ControlAgent.control_icon_base.ico"));
            _notifyIcon.Text = @"ControlAgent";
            _notifyIcon.Visible = false;
            _notifyIcon.Click += NotifyIcon_Click;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ipDropdown.DataSource = new BindingSource(GetIPv4Address(), null);
            label_statusdetails.Text = @"Not Running";
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                _notifyIcon.Visible = true;
                this.Hide();
            }
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            _notifyIcon.Visible = false;
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
            if (Config.ApiKeyExists())
            {
                string ipadr = ipDropdown.SelectedItem.ToString();
                Int32 port = Int32.Parse(portSelector.Value.ToString());
                _server = new Server(ipadr, port);
                _server.Start();
                _logger.LogState(Logger.State.Enabled, ipadr, port);

                ToggleUiState(State.Disable);

                label_statusdetails.Text = @"Running on " + ipadr + @":" + port;
            }
            else
            {
                label_statusdetails.Text = @"Error: No API Keys Found!";
            }
        }

        private void button_disable_Click(object sender, EventArgs e)
        {
            _server.Stop();
            _logger.LogState(Logger.State.Disabled);

            ToggleUiState(State.Enable);

            label_statusdetails.Text = @"Not Running";
        }

        private void button_config_Click(object sender, EventArgs e)
        {
            Config config = new Config();
            config.ShowDialog();
            config.Dispose();
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
                    button_configure.Enabled = true;
                    break;
                case State.Disable:
                    button_disable.Enabled = true;
                    ipDropdown.Enabled = false;
                    portSelector.Enabled = false;
                    button_enable.Enabled = false;
                    button_configure.Enabled = false;
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