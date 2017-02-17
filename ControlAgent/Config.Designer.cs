namespace ControlAgent
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.api_key_list = new System.Windows.Forms.ListBox();
            this.label_current_api_keys = new System.Windows.Forms.Label();
            this.label_add_new_api_key = new System.Windows.Forms.Label();
            this.button_add_new_api_key = new System.Windows.Forms.Button();
            this.new_api_key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_about1 = new System.Windows.Forms.Label();
            this.button_remove_api_key = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // api_key_list
            // 
            this.api_key_list.FormattingEnabled = true;
            this.api_key_list.Location = new System.Drawing.Point(12, 25);
            this.api_key_list.Name = "api_key_list";
            this.api_key_list.Size = new System.Drawing.Size(260, 95);
            this.api_key_list.TabIndex = 0;
            // 
            // label_current_api_keys
            // 
            this.label_current_api_keys.AutoSize = true;
            this.label_current_api_keys.Location = new System.Drawing.Point(12, 9);
            this.label_current_api_keys.Name = "label_current_api_keys";
            this.label_current_api_keys.Size = new System.Drawing.Size(90, 13);
            this.label_current_api_keys.TabIndex = 1;
            this.label_current_api_keys.Text = "Current API Keys:";
            // 
            // label_add_new_api_key
            // 
            this.label_add_new_api_key.AutoSize = true;
            this.label_add_new_api_key.Location = new System.Drawing.Point(12, 167);
            this.label_add_new_api_key.Name = "label_add_new_api_key";
            this.label_add_new_api_key.Size = new System.Drawing.Size(95, 13);
            this.label_add_new_api_key.TabIndex = 2;
            this.label_add_new_api_key.Text = "Add New API Key:";
            // 
            // button_add_new_api_key
            // 
            this.button_add_new_api_key.Location = new System.Drawing.Point(212, 184);
            this.button_add_new_api_key.Name = "button_add_new_api_key";
            this.button_add_new_api_key.Size = new System.Drawing.Size(60, 23);
            this.button_add_new_api_key.TabIndex = 3;
            this.button_add_new_api_key.Text = "Add Key";
            this.button_add_new_api_key.UseVisualStyleBackColor = true;
            this.button_add_new_api_key.Click += new System.EventHandler(this.button_add_new_api_key_Click);
            // 
            // new_api_key
            // 
            this.new_api_key.Location = new System.Drawing.Point(12, 184);
            this.new_api_key.Name = "new_api_key";
            this.new_api_key.Size = new System.Drawing.Size(194, 20);
            this.new_api_key.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "© 2017 Zander Work";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "v1.0";
            // 
            // label_about1
            // 
            this.label_about1.AutoSize = true;
            this.label_about1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_about1.Location = new System.Drawing.Point(37, 217);
            this.label_about1.Name = "label_about1";
            this.label_about1.Size = new System.Drawing.Size(205, 37);
            this.label_about1.TabIndex = 5;
            this.label_about1.Text = "ControlAgent";
            // 
            // button_remove_api_key
            // 
            this.button_remove_api_key.Location = new System.Drawing.Point(12, 126);
            this.button_remove_api_key.Name = "button_remove_api_key";
            this.button_remove_api_key.Size = new System.Drawing.Size(260, 23);
            this.button_remove_api_key.TabIndex = 8;
            this.button_remove_api_key.Text = "Remove Selected API Key";
            this.button_remove_api_key.UseVisualStyleBackColor = true;
            this.button_remove_api_key.Click += new System.EventHandler(this.button_remove_api_key_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 333);
            this.Controls.Add(this.button_remove_api_key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_about1);
            this.Controls.Add(this.new_api_key);
            this.Controls.Add(this.button_add_new_api_key);
            this.Controls.Add(this.label_add_new_api_key);
            this.Controls.Add(this.label_current_api_keys);
            this.Controls.Add(this.api_key_list);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox api_key_list;
        private System.Windows.Forms.Label label_current_api_keys;
        private System.Windows.Forms.Label label_add_new_api_key;
        private System.Windows.Forms.Button button_add_new_api_key;
        private System.Windows.Forms.TextBox new_api_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_about1;
        private System.Windows.Forms.Button button_remove_api_key;
    }
}