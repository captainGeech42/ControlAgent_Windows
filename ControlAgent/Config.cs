using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAgent
{
    public partial class Config : Form
    {
        private List<string> _apiKeys;

        public Config()
        {
            InitializeComponent();
            _apiKeys = new List<string>()
            {
                "testAPIkey1234"
            };
            PopulateKeyList();
        }

        private void button_add_new_api_key_Click(object sender, EventArgs e)
        {
            _apiKeys.Add(new_api_key.Text);
        }

        private void button_remove_api_key_Click(object sender, EventArgs e)
        {

        }

        private void PopulateKeyList()
        {
            foreach (string key in _apiKeys)
            {
                api_key_list.Items.Add(key);
            }
        }
    }
}
