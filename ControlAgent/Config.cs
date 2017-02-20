using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ControlAgent
{
    public partial class Config : Form
    {
        private static readonly List<string> ApiKeys = new List<string>();

        public Config()
        {
            InitializeComponent();
            PopulateKeyList();
        }

        public static bool ApiKeyExists()
        {
            if (ApiKeys.Count == 0 || ApiKeys == null)
            {
                return false;
            }
            return true;
        }

        private void button_add_new_api_key_Click(object sender, EventArgs e)
        {
            ApiKeys.Add(new_api_key.Text);
            new_api_key.Text = "";
            PopulateKeyList();
        }

        private void button_remove_api_key_Click(object sender, EventArgs e)
        {
            foreach (var obj in api_key_list.SelectedItems)
            {
                ApiKeys.Remove(obj.ToString());
            }
            PopulateKeyList();
        }

        public static List<string> GetApiKeys()
        {
            return ApiKeys;
        }

        private void PopulateKeyList()
        {
            api_key_list.Items.Clear();
            foreach (string key in ApiKeys)
            {
                api_key_list.Items.Add(key);
            }
        }
    }
}
