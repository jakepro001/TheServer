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
            this.MsgTxtBx = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.InsrtBtn = new System.Windows.Forms.Button();
            this.rmvBtn = new System.Windows.Forms.Button();
            this.insrtLbl = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
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
            this.label1.Size = new System.Drawing.Size(183, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "The Device";
            // 
            // MsgTxtBx
            // 
            this.MsgTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MsgTxtBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MsgTxtBx.Location = new System.Drawing.Point(28, 113);
            this.MsgTxtBx.Name = "MsgTxtBx";
            this.MsgTxtBx.Size = new System.Drawing.Size(418, 31);
            this.MsgTxtBx.TabIndex = 3;
            this.MsgTxtBx.Text = "Message...";
            this.MsgTxtBx.Click += new System.EventHandler(this.MsgTxtBx_Click);
            this.MsgTxtBx.TextChanged += new System.EventHandler(this.MsgTxtBx_TextChanged);
            this.MsgTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MsgTxtBx_KeyDown);
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
            // InsrtBtn
            // 
            this.InsrtBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.InsrtBtn.FlatAppearance.BorderColor = System.Drawing.Color.Chartreuse;
            this.InsrtBtn.FlatAppearance.BorderSize = 0;
            this.InsrtBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.InsrtBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsrtBtn.Location = new System.Drawing.Point(521, 184);
            this.InsrtBtn.Name = "InsrtBtn";
            this.InsrtBtn.Size = new System.Drawing.Size(111, 114);
            this.InsrtBtn.TabIndex = 5;
            this.InsrtBtn.Text = "Insert";
            this.InsrtBtn.UseVisualStyleBackColor = false;
            this.InsrtBtn.Click += new System.EventHandler(this.InsrtBtn_Click);
            // 
            // rmvBtn
            // 
            this.rmvBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.rmvBtn.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.rmvBtn.FlatAppearance.BorderSize = 0;
            this.rmvBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.rmvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rmvBtn.Location = new System.Drawing.Point(638, 184);
            this.rmvBtn.Name = "rmvBtn";
            this.rmvBtn.Size = new System.Drawing.Size(111, 114);
            this.rmvBtn.TabIndex = 5;
            this.rmvBtn.Text = "Remove";
            this.rmvBtn.UseVisualStyleBackColor = false;
            this.rmvBtn.Click += new System.EventHandler(this.rmvBtn_Click);
            // 
            // insrtLbl
            // 
            this.insrtLbl.AutoSize = true;
            this.insrtLbl.BackColor = System.Drawing.Color.White;
            this.insrtLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insrtLbl.ForeColor = System.Drawing.Color.Chartreuse;
            this.insrtLbl.Location = new System.Drawing.Point(534, 320);
            this.insrtLbl.Name = "insrtLbl";
            this.insrtLbl.Size = new System.Drawing.Size(201, 76);
            this.insrtLbl.TabIndex = 6;
            this.insrtLbl.Text = "Insert";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(28, 166);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(431, 305);
            this.txtLog.TabIndex = 7;
            // 
            // ClientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheClient.Properties.Resources.w;
            this.ClientSize = new System.Drawing.Size(803, 483);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.insrtLbl);
            this.Controls.Add(this.rmvBtn);
            this.Controls.Add(this.InsrtBtn);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.MsgTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientPage";
            this.Text = "The Device";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientPage_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MsgTxtBx;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button InsrtBtn;
        private System.Windows.Forms.Button rmvBtn;
        private System.Windows.Forms.Label insrtLbl;
        private System.Windows.Forms.TextBox txtLog;
    }
}

