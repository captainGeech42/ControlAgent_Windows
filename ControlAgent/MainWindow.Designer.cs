namespace ControlAgent
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.button_enable = new System.Windows.Forms.Button();
            this.label_ip = new System.Windows.Forms.Label();
            this.button_disable = new System.Windows.Forms.Button();
            this.label_statusdetails = new System.Windows.Forms.Label();
            this.ipDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.portSelector = new System.Windows.Forms.NumericUpDown();
            this.label_statuslabel = new System.Windows.Forms.Label();
            this.button_configure = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.portSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // button_enable
            // 
            this.button_enable.Location = new System.Drawing.Point(12, 40);
            this.button_enable.Name = "button_enable";
            this.button_enable.Size = new System.Drawing.Size(119, 23);
            this.button_enable.TabIndex = 0;
            this.button_enable.Text = "Enable Agent";
            this.button_enable.UseVisualStyleBackColor = true;
            this.button_enable.Click += new System.EventHandler(this.button_enable_Click);
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(176, 45);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(73, 13);
            this.label_ip.TabIndex = 1;
            this.label_ip.Text = "IPv4 Address:";
            // 
            // button_disable
            // 
            this.button_disable.Enabled = false;
            this.button_disable.Location = new System.Drawing.Point(12, 69);
            this.button_disable.Name = "button_disable";
            this.button_disable.Size = new System.Drawing.Size(119, 23);
            this.button_disable.TabIndex = 2;
            this.button_disable.Text = "Disable Agent";
            this.button_disable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_disable.UseVisualStyleBackColor = true;
            this.button_disable.Click += new System.EventHandler(this.button_disable_Click);
            // 
            // label_statusdetails
            // 
            this.label_statusdetails.AutoSize = true;
            this.label_statusdetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_statusdetails.Location = new System.Drawing.Point(112, 9);
            this.label_statusdetails.Name = "label_statusdetails";
            this.label_statusdetails.Size = new System.Drawing.Size(148, 17);
            this.label_statusdetails.TabIndex = 3;
            this.label_statusdetails.Text = "Status Info Goes Here";
            // 
            // ipDropdown
            // 
            this.ipDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ipDropdown.FormattingEnabled = true;
            this.ipDropdown.Location = new System.Drawing.Point(255, 42);
            this.ipDropdown.Name = "ipDropdown";
            this.ipDropdown.Size = new System.Drawing.Size(121, 21);
            this.ipDropdown.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // portSelector
            // 
            this.portSelector.Location = new System.Drawing.Point(211, 72);
            this.portSelector.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.portSelector.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.portSelector.Name = "portSelector";
            this.portSelector.Size = new System.Drawing.Size(59, 20);
            this.portSelector.TabIndex = 7;
            this.portSelector.Value = new decimal(new int[] {
            12345,
            0,
            0,
            0});
            // 
            // label_statuslabel
            // 
            this.label_statuslabel.AutoSize = true;
            this.label_statuslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_statuslabel.Location = new System.Drawing.Point(12, 9);
            this.label_statuslabel.Name = "label_statuslabel";
            this.label_statuslabel.Size = new System.Drawing.Size(103, 17);
            this.label_statuslabel.TabIndex = 8;
            this.label_statuslabel.Text = "Current Status:";
            // 
            // button_configure
            // 
            this.button_configure.Location = new System.Drawing.Point(276, 69);
            this.button_configure.Name = "button_configure";
            this.button_configure.Size = new System.Drawing.Size(100, 23);
            this.button_configure.TabIndex = 9;
            this.button_configure.Text = "Configure";
            this.button_configure.UseVisualStyleBackColor = true;
            this.button_configure.Click += new System.EventHandler(this.button_config_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 108);
            this.Controls.Add(this.button_configure);
            this.Controls.Add(this.label_statuslabel);
            this.Controls.Add(this.portSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipDropdown);
            this.Controls.Add(this.label_statusdetails);
            this.Controls.Add(this.button_disable);
            this.Controls.Add(this.label_ip);
            this.Controls.Add(this.button_enable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Control Settings";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.portSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_enable;
        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Button button_disable;
        private System.Windows.Forms.Label label_statusdetails;
        private System.Windows.Forms.ComboBox ipDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown portSelector;
        private System.Windows.Forms.Label label_statuslabel;
        private System.Windows.Forms.Button button_configure;
    }
}

