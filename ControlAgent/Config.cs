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
        private List<string> apiKeys;

        public Config()
        {
            InitializeComponent();
            apiKeys = new List<string>()
            {
                "testAPIkey1234"
            };
            populateKeyList();
        }

        private void button_add_new_api_key_Click(object sender, EventArgs e)
        {
            apiKeys.Add(new_api_key.Text);
        }

        private void button_remove_api_key_Click(object sender, EventArgs e)
        {

        }

        private void populateKeyList()
        {
            foreach (string key in apiKeys)
            {
                api_key_list.Items.Add(key);
            }
        }
    }
}
