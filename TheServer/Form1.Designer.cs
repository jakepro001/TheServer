namespace TheServer
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CreateTableBtn = new System.Windows.Forms.Button();
            this.InsertionBtn = new System.Windows.Forms.Button();
            this.DisplayBtn = new System.Windows.Forms.Button();
            this.ConnectSqlBtn = new System.Windows.Forms.Button();
            this.CloseSqlBtn = new System.Windows.Forms.Button();
            this.CreateDbBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(636, 385);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(290, 105);
            this.txtLog.TabIndex = 1;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(636, 509);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(209, 27);
            this.txtText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(633, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Broadcast Text";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(851, 509);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 27);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(638, 539);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Server Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(714, 539);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 13);
            this.lblStatus.TabIndex = 24;
            this.lblStatus.Text = "Server is Down";
            // 
            // lblConnected
            // 
            this.lblConnected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConnected.AutoSize = true;
            this.lblConnected.BackColor = System.Drawing.SystemColors.Control;
            this.lblConnected.Location = new System.Drawing.Point(900, 539);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(13, 13);
            this.lblConnected.TabIndex = 32;
            this.lblConnected.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(799, 539);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Connected clients:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheServer.Properties.Resources.B;
            this.pictureBox1.Location = new System.Drawing.Point(622, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 540);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "The Database Controllers ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheServer.Properties.Resources.B;
            this.pictureBox2.Location = new System.Drawing.Point(622, 365);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(304, 2);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // CreateTableBtn
            // 
            this.CreateTableBtn.Location = new System.Drawing.Point(637, 96);
            this.CreateTableBtn.Name = "CreateTableBtn";
            this.CreateTableBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateTableBtn.TabIndex = 35;
            this.CreateTableBtn.Text = "Create";
            this.CreateTableBtn.UseVisualStyleBackColor = true;
            this.CreateTableBtn.Click += new System.EventHandler(this.CreateTableBtn_Click);
            // 
            // InsertionBtn
            // 
            this.InsertionBtn.Location = new System.Drawing.Point(718, 96);
            this.InsertionBtn.Name = "InsertionBtn";
            this.InsertionBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertionBtn.TabIndex = 35;
            this.InsertionBtn.Text = "Insert";
            this.InsertionBtn.UseVisualStyleBackColor = true;
            this.InsertionBtn.Click += new System.EventHandler(this.InsertionBtn_Click);
            // 
            // DisplayBtn
            // 
            this.DisplayBtn.Location = new System.Drawing.Point(799, 96);
            this.DisplayBtn.Name = "DisplayBtn";
            this.DisplayBtn.Size = new System.Drawing.Size(75, 23);
            this.DisplayBtn.TabIndex = 35;
            this.DisplayBtn.Text = "Display";
            this.DisplayBtn.UseVisualStyleBackColor = true;
            this.DisplayBtn.Click += new System.EventHandler(this.DisplayBtn_Click);
            // 
            // ConnectSqlBtn
            // 
            this.ConnectSqlBtn.Location = new System.Drawing.Point(718, 67);
            this.ConnectSqlBtn.Name = "ConnectSqlBtn";
            this.ConnectSqlBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectSqlBtn.TabIndex = 36;
            this.ConnectSqlBtn.Text = "Connect Sql";
            this.ConnectSqlBtn.UseVisualStyleBackColor = true;
            this.ConnectSqlBtn.Click += new System.EventHandler(this.ConnectSqlBtn_Click);
            // 
            // CloseSqlBtn
            // 
            this.CloseSqlBtn.Location = new System.Drawing.Point(799, 67);
            this.CloseSqlBtn.Name = "CloseSqlBtn";
            this.CloseSqlBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseSqlBtn.TabIndex = 36;
            this.CloseSqlBtn.Text = "Close Connection";
            this.CloseSqlBtn.UseVisualStyleBackColor = true;
            this.CloseSqlBtn.Click += new System.EventHandler(this.CloseSqlBtn_Click);
            // 
            // CreateDbBtn
            // 
            this.CreateDbBtn.Location = new System.Drawing.Point(637, 67);
            this.CreateDbBtn.Name = "CreateDbBtn";
            this.CreateDbBtn.Size = new System.Drawing.Size(75, 23);
            this.CreateDbBtn.TabIndex = 36;
            this.CreateDbBtn.Text = "Create DB";
            this.CreateDbBtn.UseVisualStyleBackColor = true;
            this.CreateDbBtn.Click += new System.EventHandler(this.CreateDbBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(935, 564);
            this.Controls.Add(this.CloseSqlBtn);
            this.Controls.Add(this.CreateDbBtn);
            this.Controls.Add(this.ConnectSqlBtn);
            this.Controls.Add(this.DisplayBtn);
            this.Controls.Add(this.InsertionBtn);
            this.Controls.Add(this.CreateTableBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtLog);
            this.MinimumSize = new System.Drawing.Size(696, 461);
            this.Name = "Form1";
            this.Text = "The Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button CreateTableBtn;
        private System.Windows.Forms.Button InsertionBtn;
        private System.Windows.Forms.Button DisplayBtn;
        private System.Windows.Forms.Button ConnectSqlBtn;
        private System.Windows.Forms.Button CloseSqlBtn;
        private System.Windows.Forms.Button CreateDbBtn;
    }
}

