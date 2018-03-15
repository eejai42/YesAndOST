namespace WindowsYesAndApp
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this._emailAddressTextBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this._dmTextBox = new System.Windows.Forms.TextBox();
            this._sendDMButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect To YesAnd";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // _emailAddressTextBox1
            // 
            this._emailAddressTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsYesAndApp.Properties.Settings.Default, "EmailAddress", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this._emailAddressTextBox1.Location = new System.Drawing.Point(219, 22);
            this._emailAddressTextBox1.Name = "_emailAddressTextBox1";
            this._emailAddressTextBox1.Size = new System.Drawing.Size(344, 20);
            this._emailAddressTextBox1.TabIndex = 1;
            this._emailAddressTextBox1.Text = global::WindowsYesAndApp.Properties.Settings.Default.EmailAddress;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(38, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(321, 368);
            this.listBox1.TabIndex = 2;
            // 
            // _dmTextBox
            // 
            this._dmTextBox.Location = new System.Drawing.Point(382, 107);
            this._dmTextBox.Name = "_dmTextBox";
            this._dmTextBox.Size = new System.Drawing.Size(344, 20);
            this._dmTextBox.TabIndex = 3;
            // 
            // _sendDMButton
            // 
            this._sendDMButton.Location = new System.Drawing.Point(388, 142);
            this._sendDMButton.Name = "_sendDMButton";
            this._sendDMButton.Size = new System.Drawing.Size(75, 23);
            this._sendDMButton.TabIndex = 4;
            this._sendDMButton.Text = "Send DM";
            this._sendDMButton.UseVisualStyleBackColor = true;
            this._sendDMButton.Click += new System.EventHandler(this._sendDMButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 489);
            this.Controls.Add(this._sendDMButton);
            this.Controls.Add(this._dmTextBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this._emailAddressTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Yes, and...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox _emailAddressTextBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox _dmTextBox;
        private System.Windows.Forms.Button _sendDMButton;
    }
}

