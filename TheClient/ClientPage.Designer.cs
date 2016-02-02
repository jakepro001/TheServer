namespace TheClient
{
    partial class ClientPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientPage));
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogLstBx = new System.Windows.Forms.ListBox();
            this.MsgTxtBx = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.DeviceListBx = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ConnectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectBtn.Font = new System.Drawing.Font("Papyrus", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectBtn.Location = new System.Drawing.Point(234, 32);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(91, 44);
            this.ConnectBtn.TabIndex = 0;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Edwardian Script ITC", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "The Client";
            // 
            // LogLstBx
            // 
            this.LogLstBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogLstBx.FormattingEnabled = true;
            this.LogLstBx.HorizontalScrollbar = true;
            this.LogLstBx.Location = new System.Drawing.Point(22, 161);
            this.LogLstBx.Name = "LogLstBx";
            this.LogLstBx.Size = new System.Drawing.Size(437, 286);
            this.LogLstBx.TabIndex = 2;
            // 
            // MsgTxtBx
            // 
            this.MsgTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MsgTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgTxtBx.Location = new System.Drawing.Point(28, 113);
            this.MsgTxtBx.Name = "MsgTxtBx";
            this.MsgTxtBx.Size = new System.Drawing.Size(418, 16);
            this.MsgTxtBx.TabIndex = 3;
            this.MsgTxtBx.Text = "Message...";
            this.MsgTxtBx.Click += new System.EventHandler(this.MsgTxtBx_Click);
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(465, 113);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 4;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // DeviceListBx
            // 
            this.DeviceListBx.FormattingEnabled = true;
            this.DeviceListBx.Location = new System.Drawing.Point(638, 161);
            this.DeviceListBx.Name = "DeviceListBx";
            this.DeviceListBx.Size = new System.Drawing.Size(142, 303);
            this.DeviceListBx.TabIndex = 5;
            // 
            // ClientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheClient.Properties.Resources.Christmas_HD_Wallpapers_1920x1200__24_;
            this.ClientSize = new System.Drawing.Size(803, 483);
            this.Controls.Add(this.DeviceListBx);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.LogLstBx);
            this.Controls.Add(this.MsgTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientPage";
            this.Text = "The Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LogLstBx;
        private System.Windows.Forms.TextBox MsgTxtBx;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.ListBox DeviceListBx;
    }
}

