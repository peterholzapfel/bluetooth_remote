namespace bluetooth_remote_1._0
{
    partial class Form1
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
            this.b_connect = new System.Windows.Forms.Button();
            this.l_status = new System.Windows.Forms.Label();
            this.b_disconnect = new System.Windows.Forms.Button();
            this.l_disconnect = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_connect
            // 
            this.b_connect.Location = new System.Drawing.Point(41, 115);
            this.b_connect.Name = "b_connect";
            this.b_connect.Size = new System.Drawing.Size(75, 23);
            this.b_connect.TabIndex = 0;
            this.b_connect.Text = "Connect";
            this.b_connect.UseVisualStyleBackColor = true;
            this.b_connect.Click += new System.EventHandler(this.b_connect_Click);
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Location = new System.Drawing.Point(73, 60);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(76, 13);
            this.l_status.TabIndex = 1;
            this.l_status.Text = "not connected";
            this.l_status.Click += new System.EventHandler(this.l_status_Click);
            // 
            // b_disconnect
            // 
            this.b_disconnect.Location = new System.Drawing.Point(136, 115);
            this.b_disconnect.Name = "b_disconnect";
            this.b_disconnect.Size = new System.Drawing.Size(75, 23);
            this.b_disconnect.TabIndex = 2;
            this.b_disconnect.Text = "Disconnect";
            this.b_disconnect.UseVisualStyleBackColor = true;
            this.b_disconnect.Click += new System.EventHandler(this.b_disconnect_Click);
            // 
            // l_disconnect
            // 
            this.l_disconnect.AutoSize = true;
            this.l_disconnect.Location = new System.Drawing.Point(135, 90);
            this.l_disconnect.Name = "l_disconnect";
            this.l_disconnect.Size = new System.Drawing.Size(10, 13);
            this.l_disconnect.TabIndex = 3;
            this.l_disconnect.Text = ".";
            this.l_disconnect.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 172);
            this.Controls.Add(this.l_disconnect);
            this.Controls.Add(this.b_disconnect);
            this.Controls.Add(this.l_status);
            this.Controls.Add(this.b_connect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_connect;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.Button b_disconnect;
        private System.Windows.Forms.Label l_disconnect;
    }
}

