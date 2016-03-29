using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace TheServer
{
    partial class TheServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DisplayBtn = new System.Windows.Forms.Button();
            this.tableGridVw = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseSqlBtn = new System.Windows.Forms.Button();
            this.ConnectSqlBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pidLbl = new System.Windows.Forms.Label();
            this.pnameLbl = new System.Windows.Forms.Label();
            this.catidLbl = new System.Windows.Forms.Label();
            this.manidLbl = new System.Windows.Forms.Label();
            this.brandLbl = new System.Windows.Forms.Label();
            this.qtyLbl = new System.Windows.Forms.Label();
            this.wtLbl = new System.Windows.Forms.Label();
            this.stkLbl = new System.Windows.Forms.Label();
            this.priceLbl = new System.Windows.Forms.Label();
            this.editPic = new System.Windows.Forms.PictureBox();
            this.delPic = new System.Windows.Forms.PictureBox();
            this.InsertPresetBtn = new System.Windows.Forms.Button();
            this.pidTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pnameTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.catidTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.manidTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.brandTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.qtyTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.wtTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.stkTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.priceTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.usernameTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.passwordTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.searchTxtBx = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.resetBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.InsertBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.loginBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.dashboardPicBx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableGridVw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPicBx)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(916, 50);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(294, 560);
            this.txtLog.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(914, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Log";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(914, 654);
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
            this.lblStatus.Location = new System.Drawing.Point(990, 654);
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
            this.lblConnected.Location = new System.Drawing.Point(1176, 654);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(13, 13);
            this.lblConnected.TabIndex = 32;
            this.lblConnected.Text = "0";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1075, 654);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Connected clients:";
            // 
            // DisplayBtn
            // 
            this.DisplayBtn.Location = new System.Drawing.Point(1057, 616);
            this.DisplayBtn.Name = "DisplayBtn";
            this.DisplayBtn.Size = new System.Drawing.Size(75, 23);
            this.DisplayBtn.TabIndex = 19;
            this.DisplayBtn.Text = "Display";
            this.DisplayBtn.UseVisualStyleBackColor = true;
            this.DisplayBtn.Click += new System.EventHandler(this.DisplayBtn_Click);
            // 
            // tableGridVw
            // 
            this.tableGridVw.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableGridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGridVw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.catid,
            this.mid,
            this.brand,
            this.qty,
            this.wt,
            this.stock,
            this.price});
            this.tableGridVw.Location = new System.Drawing.Point(12, 425);
            this.tableGridVw.Name = "tableGridVw";
            this.tableGridVw.ReadOnly = true;
            this.tableGridVw.Size = new System.Drawing.Size(889, 242);
            this.tableGridVw.TabIndex = 39;
            // 
            // pid
            // 
            this.pid.HeaderText = "PID";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            // 
            // pname
            // 
            this.pname.HeaderText = "PName";
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // catid
            // 
            this.catid.HeaderText = "CategoryId";
            this.catid.Name = "catid";
            this.catid.ReadOnly = true;
            // 
            // mid
            // 
            this.mid.HeaderText = "ManufactureID";
            this.mid.Name = "mid";
            this.mid.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "Brand";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.HeaderText = "Quantity";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // wt
            // 
            this.wt.HeaderText = "Weight";
            this.wt.Name = "wt";
            this.wt.ReadOnly = true;
            // 
            // stock
            // 
            this.stock.HeaderText = "Stock";
            this.stock.Name = "stock";
            this.stock.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Price";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // CloseSqlBtn
            // 
            this.CloseSqlBtn.Location = new System.Drawing.Point(982, 616);
            this.CloseSqlBtn.Name = "CloseSqlBtn";
            this.CloseSqlBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseSqlBtn.TabIndex = 18;
            this.CloseSqlBtn.Text = "Close Connection";
            this.CloseSqlBtn.UseVisualStyleBackColor = true;
            this.CloseSqlBtn.Click += new System.EventHandler(this.CloseSqlBtn_Click);
            // 
            // ConnectSqlBtn
            // 
            this.ConnectSqlBtn.Location = new System.Drawing.Point(909, 616);
            this.ConnectSqlBtn.Name = "ConnectSqlBtn";
            this.ConnectSqlBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectSqlBtn.TabIndex = 17;
            this.ConnectSqlBtn.Text = "Connect Sql";
            this.ConnectSqlBtn.UseVisualStyleBackColor = true;
            this.ConnectSqlBtn.Click += new System.EventHandler(this.ConnectSqlBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheServer.Properties.Resources.B;
            this.pictureBox2.Location = new System.Drawing.Point(909, 642);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(304, 2);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheServer.Properties.Resources.B;
            this.pictureBox1.Location = new System.Drawing.Point(907, 60);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2, 620);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TheServer.Properties.Resources.bord1;
            this.pictureBox4.Location = new System.Drawing.Point(12, 94);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(270, 53);
            this.pictureBox4.TabIndex = 42;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TheServer.Properties.Resources.bord1;
            this.pictureBox5.Location = new System.Drawing.Point(299, 94);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(602, 53);
            this.pictureBox5.TabIndex = 42;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(12, 141);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(270, 226);
            this.pictureBox6.TabIndex = 42;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(299, 142);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(602, 226);
            this.pictureBox7.TabIndex = 42;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::TheServer.Properties.Resources.bord1;
            this.pictureBox8.Location = new System.Drawing.Point(12, 377);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(889, 53);
            this.pictureBox8.TabIndex = 42;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Location = new System.Drawing.Point(12, 425);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(889, 242);
            this.pictureBox9.TabIndex = 42;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::TheServer.Properties.Resources.username;
            this.pictureBox11.Location = new System.Drawing.Point(42, 195);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(31, 30);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 43;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = global::TheServer.Properties.Resources.lock1;
            this.pictureBox12.Location = new System.Drawing.Point(42, 233);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(31, 30);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 43;
            this.pictureBox12.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Image = global::TheServer.Properties.Resources.bord2;
            this.label2.Location = new System.Drawing.Point(23, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Image = global::TheServer.Properties.Resources.bord2;
            this.label3.Location = new System.Drawing.Point(311, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Add Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Image = global::TheServer.Properties.Resources.bord2;
            this.label5.Location = new System.Drawing.Point(23, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "View all";
            this.label5.Click += new System.EventHandler(this.DisplayBtn_Click);
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = global::TheServer.Properties.Resources.keyhole;
            this.pictureBox13.Location = new System.Drawing.Point(230, 101);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(36, 35);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 45;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.Image = global::TheServer.Properties.Resources.plus1;
            this.pictureBox14.Location = new System.Drawing.Point(424, 102);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(41, 41);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 45;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::TheServer.Properties.Resources.eye1;
            this.pictureBox15.Location = new System.Drawing.Point(117, 382);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(41, 41);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 45;
            this.pictureBox15.TabStop = false;
            this.pictureBox15.Click += new System.EventHandler(this.DisplayBtn_Click);
            // 
            // pidLbl
            // 
            this.pidLbl.AutoSize = true;
            this.pidLbl.Enabled = false;
            this.pidLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pidLbl.Location = new System.Drawing.Point(332, 161);
            this.pidLbl.Name = "pidLbl";
            this.pidLbl.Size = new System.Drawing.Size(63, 14);
            this.pidLbl.TabIndex = 46;
            this.pidLbl.Text = "ProductID";
            // 
            // pnameLbl
            // 
            this.pnameLbl.AutoSize = true;
            this.pnameLbl.Enabled = false;
            this.pnameLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnameLbl.Location = new System.Drawing.Point(312, 203);
            this.pnameLbl.Name = "pnameLbl";
            this.pnameLbl.Size = new System.Drawing.Size(83, 14);
            this.pnameLbl.TabIndex = 46;
            this.pnameLbl.Text = "ProductName";
            // 
            // catidLbl
            // 
            this.catidLbl.AutoSize = true;
            this.catidLbl.Enabled = false;
            this.catidLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.catidLbl.Location = new System.Drawing.Point(323, 245);
            this.catidLbl.Name = "catidLbl";
            this.catidLbl.Size = new System.Drawing.Size(72, 14);
            this.catidLbl.TabIndex = 46;
            this.catidLbl.Text = "CategoryID";
            // 
            // manidLbl
            // 
            this.manidLbl.AutoSize = true;
            this.manidLbl.Enabled = false;
            this.manidLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manidLbl.Location = new System.Drawing.Point(306, 287);
            this.manidLbl.Name = "manidLbl";
            this.manidLbl.Size = new System.Drawing.Size(89, 14);
            this.manidLbl.TabIndex = 46;
            this.manidLbl.Text = "ManufactureID";
            // 
            // brandLbl
            // 
            this.brandLbl.AutoSize = true;
            this.brandLbl.Enabled = false;
            this.brandLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brandLbl.Location = new System.Drawing.Point(355, 329);
            this.brandLbl.Name = "brandLbl";
            this.brandLbl.Size = new System.Drawing.Size(40, 14);
            this.brandLbl.TabIndex = 46;
            this.brandLbl.Text = "Brand";
            // 
            // qtyLbl
            // 
            this.qtyLbl.AutoSize = true;
            this.qtyLbl.Enabled = false;
            this.qtyLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyLbl.Location = new System.Drawing.Point(632, 158);
            this.qtyLbl.Name = "qtyLbl";
            this.qtyLbl.Size = new System.Drawing.Size(55, 14);
            this.qtyLbl.TabIndex = 46;
            this.qtyLbl.Text = "Quantity";
            // 
            // wtLbl
            // 
            this.wtLbl.AutoSize = true;
            this.wtLbl.Enabled = false;
            this.wtLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wtLbl.Location = new System.Drawing.Point(639, 209);
            this.wtLbl.Name = "wtLbl";
            this.wtLbl.Size = new System.Drawing.Size(48, 14);
            this.wtLbl.TabIndex = 46;
            this.wtLbl.Text = "Weight";
            // 
            // stkLbl
            // 
            this.stkLbl.AutoSize = true;
            this.stkLbl.Enabled = false;
            this.stkLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stkLbl.Location = new System.Drawing.Point(650, 260);
            this.stkLbl.Name = "stkLbl";
            this.stkLbl.Size = new System.Drawing.Size(37, 14);
            this.stkLbl.TabIndex = 46;
            this.stkLbl.Text = "Stock";
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Enabled = false;
            this.priceLbl.Font = new System.Drawing.Font("Rockwell", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLbl.Location = new System.Drawing.Point(652, 308);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(35, 14);
            this.priceLbl.TabIndex = 46;
            this.priceLbl.Text = "Price";
            // 
            // editPic
            // 
            this.editPic.Image = global::TheServer.Properties.Resources.ed;
            this.editPic.Location = new System.Drawing.Point(764, 384);
            this.editPic.Name = "editPic";
            this.editPic.Size = new System.Drawing.Size(35, 35);
            this.editPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.editPic.TabIndex = 45;
            this.editPic.TabStop = false;
            this.editPic.Click += new System.EventHandler(this.editPic_Click);
            // 
            // delPic
            // 
            this.delPic.Image = global::TheServer.Properties.Resources.del;
            this.delPic.Location = new System.Drawing.Point(815, 385);
            this.delPic.Name = "delPic";
            this.delPic.Size = new System.Drawing.Size(34, 35);
            this.delPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delPic.TabIndex = 45;
            this.delPic.TabStop = false;
            this.delPic.Click += new System.EventHandler(this.delPic_Click);
            // 
            // InsertPresetBtn
            // 
            this.InsertPresetBtn.Location = new System.Drawing.Point(1133, 616);
            this.InsertPresetBtn.Name = "InsertPresetBtn";
            this.InsertPresetBtn.Size = new System.Drawing.Size(75, 23);
            this.InsertPresetBtn.TabIndex = 20;
            this.InsertPresetBtn.Text = "Preset Insert";
            this.InsertPresetBtn.UseVisualStyleBackColor = true;
            this.InsertPresetBtn.Click += new System.EventHandler(this.InsertPresetBtn_Click);
            // 
            // pidTxtBx
            // 
            this.pidTxtBx.Depth = 0;
            this.pidTxtBx.Hint = "Product ID";
            this.pidTxtBx.Location = new System.Drawing.Point(397, 157);
            this.pidTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.pidTxtBx.Name = "pidTxtBx";
            this.pidTxtBx.PasswordChar = '\0';
            this.pidTxtBx.SelectedText = "";
            this.pidTxtBx.SelectionLength = 0;
            this.pidTxtBx.SelectionStart = 0;
            this.pidTxtBx.Size = new System.Drawing.Size(190, 23);
            this.pidTxtBx.TabIndex = 5;
            this.pidTxtBx.UseSystemPasswordChar = false;
            this.pidTxtBx.Enter += new System.EventHandler(this.pidTxtBx_Enter);
            this.pidTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.pidTxtBx.Leave += new System.EventHandler(this.pidTxtBx_Leave);
            // 
            // pnameTxtBx
            // 
            this.pnameTxtBx.Depth = 0;
            this.pnameTxtBx.Hint = "Product Name";
            this.pnameTxtBx.Location = new System.Drawing.Point(397, 199);
            this.pnameTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnameTxtBx.Name = "pnameTxtBx";
            this.pnameTxtBx.PasswordChar = '\0';
            this.pnameTxtBx.SelectedText = "";
            this.pnameTxtBx.SelectionLength = 0;
            this.pnameTxtBx.SelectionStart = 0;
            this.pnameTxtBx.Size = new System.Drawing.Size(190, 23);
            this.pnameTxtBx.TabIndex = 6;
            this.pnameTxtBx.UseSystemPasswordChar = false;
            this.pnameTxtBx.Enter += new System.EventHandler(this.pnameTxtBx_Enter);
            this.pnameTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.pnameTxtBx.Leave += new System.EventHandler(this.pnameTxtBx_Leave);
            // 
            // catidTxtBx
            // 
            this.catidTxtBx.Depth = 0;
            this.catidTxtBx.Hint = "Category ID";
            this.catidTxtBx.Location = new System.Drawing.Point(397, 241);
            this.catidTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.catidTxtBx.Name = "catidTxtBx";
            this.catidTxtBx.PasswordChar = '\0';
            this.catidTxtBx.SelectedText = "";
            this.catidTxtBx.SelectionLength = 0;
            this.catidTxtBx.SelectionStart = 0;
            this.catidTxtBx.Size = new System.Drawing.Size(190, 23);
            this.catidTxtBx.TabIndex = 7;
            this.catidTxtBx.UseSystemPasswordChar = false;
            this.catidTxtBx.Enter += new System.EventHandler(this.catidTxtBx_Enter);
            this.catidTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.catidTxtBx.Leave += new System.EventHandler(this.catidTxtBx_Leave);
            // 
            // manidTxtBx
            // 
            this.manidTxtBx.Depth = 0;
            this.manidTxtBx.Hint = "Manufacture ID";
            this.manidTxtBx.Location = new System.Drawing.Point(397, 283);
            this.manidTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.manidTxtBx.Name = "manidTxtBx";
            this.manidTxtBx.PasswordChar = '\0';
            this.manidTxtBx.SelectedText = "";
            this.manidTxtBx.SelectionLength = 0;
            this.manidTxtBx.SelectionStart = 0;
            this.manidTxtBx.Size = new System.Drawing.Size(190, 23);
            this.manidTxtBx.TabIndex = 8;
            this.manidTxtBx.UseSystemPasswordChar = false;
            this.manidTxtBx.Enter += new System.EventHandler(this.manidTxtBx_Enter);
            this.manidTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.manidTxtBx.Leave += new System.EventHandler(this.manidTxtBx_Leave);
            // 
            // brandTxtBx
            // 
            this.brandTxtBx.Depth = 0;
            this.brandTxtBx.Hint = "Brand";
            this.brandTxtBx.Location = new System.Drawing.Point(397, 325);
            this.brandTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.brandTxtBx.Name = "brandTxtBx";
            this.brandTxtBx.PasswordChar = '\0';
            this.brandTxtBx.SelectedText = "";
            this.brandTxtBx.SelectionLength = 0;
            this.brandTxtBx.SelectionStart = 0;
            this.brandTxtBx.Size = new System.Drawing.Size(190, 23);
            this.brandTxtBx.TabIndex = 9;
            this.brandTxtBx.UseSystemPasswordChar = false;
            this.brandTxtBx.Enter += new System.EventHandler(this.brandTxtBx_Enter);
            this.brandTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.brandTxtBx.Leave += new System.EventHandler(this.brandTxtBx_Leave);
            // 
            // qtyTxtBx
            // 
            this.qtyTxtBx.Depth = 0;
            this.qtyTxtBx.Hint = "Quantity";
            this.qtyTxtBx.Location = new System.Drawing.Point(693, 157);
            this.qtyTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.qtyTxtBx.Name = "qtyTxtBx";
            this.qtyTxtBx.PasswordChar = '\0';
            this.qtyTxtBx.SelectedText = "";
            this.qtyTxtBx.SelectionLength = 0;
            this.qtyTxtBx.SelectionStart = 0;
            this.qtyTxtBx.Size = new System.Drawing.Size(190, 23);
            this.qtyTxtBx.TabIndex = 10;
            this.qtyTxtBx.UseSystemPasswordChar = false;
            this.qtyTxtBx.Enter += new System.EventHandler(this.qtyTxtBx_Enter);
            this.qtyTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.qtyTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MakeNewmericKeypress);
            this.qtyTxtBx.Leave += new System.EventHandler(this.qtyTxtBx_Leave);
            // 
            // wtTxtBx
            // 
            this.wtTxtBx.Depth = 0;
            this.wtTxtBx.Hint = "Weight";
            this.wtTxtBx.Location = new System.Drawing.Point(693, 206);
            this.wtTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.wtTxtBx.Name = "wtTxtBx";
            this.wtTxtBx.PasswordChar = '\0';
            this.wtTxtBx.SelectedText = "";
            this.wtTxtBx.SelectionLength = 0;
            this.wtTxtBx.SelectionStart = 0;
            this.wtTxtBx.Size = new System.Drawing.Size(190, 23);
            this.wtTxtBx.TabIndex = 11;
            this.wtTxtBx.UseSystemPasswordChar = false;
            this.wtTxtBx.Enter += new System.EventHandler(this.wtTxtBx_Enter);
            this.wtTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.wtTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MakeNewmericKeypress);
            this.wtTxtBx.Leave += new System.EventHandler(this.wtTxtBx_Leave);
            // 
            // stkTxtBx
            // 
            this.stkTxtBx.Depth = 0;
            this.stkTxtBx.Hint = "Stock";
            this.stkTxtBx.Location = new System.Drawing.Point(693, 255);
            this.stkTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.stkTxtBx.Name = "stkTxtBx";
            this.stkTxtBx.PasswordChar = '\0';
            this.stkTxtBx.SelectedText = "";
            this.stkTxtBx.SelectionLength = 0;
            this.stkTxtBx.SelectionStart = 0;
            this.stkTxtBx.Size = new System.Drawing.Size(190, 23);
            this.stkTxtBx.TabIndex = 12;
            this.stkTxtBx.UseSystemPasswordChar = false;
            this.stkTxtBx.Enter += new System.EventHandler(this.stkTxtBx_Enter);
            this.stkTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.stkTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MakeNewmericKeypress);
            this.stkTxtBx.Leave += new System.EventHandler(this.stkTxtBx_Leave);
            // 
            // priceTxtBx
            // 
            this.priceTxtBx.Depth = 0;
            this.priceTxtBx.Hint = "Price";
            this.priceTxtBx.Location = new System.Drawing.Point(693, 304);
            this.priceTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.priceTxtBx.Name = "priceTxtBx";
            this.priceTxtBx.PasswordChar = '\0';
            this.priceTxtBx.SelectedText = "";
            this.priceTxtBx.SelectionLength = 0;
            this.priceTxtBx.SelectionStart = 0;
            this.priceTxtBx.Size = new System.Drawing.Size(190, 23);
            this.priceTxtBx.TabIndex = 13;
            this.priceTxtBx.UseSystemPasswordChar = false;
            this.priceTxtBx.Enter += new System.EventHandler(this.priceTxtBx_Enter);
            this.priceTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.priceTxtBx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MakeNewmericKeypress);
            this.priceTxtBx.Leave += new System.EventHandler(this.priceTxtBx_Leave);
            // 
            // usernameTxtBx
            // 
            this.usernameTxtBx.Depth = 0;
            this.usernameTxtBx.Hint = "Username";
            this.usernameTxtBx.Location = new System.Drawing.Point(76, 202);
            this.usernameTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.usernameTxtBx.Name = "usernameTxtBx";
            this.usernameTxtBx.PasswordChar = '\0';
            this.usernameTxtBx.SelectedText = "";
            this.usernameTxtBx.SelectionLength = 0;
            this.usernameTxtBx.SelectionStart = 0;
            this.usernameTxtBx.Size = new System.Drawing.Size(190, 23);
            this.usernameTxtBx.TabIndex = 0;
            this.usernameTxtBx.UseSystemPasswordChar = false;
            // 
            // passwordTxtBx
            // 
            this.passwordTxtBx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.passwordTxtBx.Depth = 0;
            this.passwordTxtBx.Hint = "Password";
            this.passwordTxtBx.Location = new System.Drawing.Point(76, 236);
            this.passwordTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.passwordTxtBx.Name = "passwordTxtBx";
            this.passwordTxtBx.PasswordChar = '*';
            this.passwordTxtBx.SelectedText = "";
            this.passwordTxtBx.SelectionLength = 0;
            this.passwordTxtBx.SelectionStart = 0;
            this.passwordTxtBx.Size = new System.Drawing.Size(190, 23);
            this.passwordTxtBx.TabIndex = 1;
            this.passwordTxtBx.UseSystemPasswordChar = false;
            this.passwordTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTxtBx_KeyDown);
            // 
            // searchTxtBx
            // 
            this.searchTxtBx.BackColor = System.Drawing.Color.Gray;
            this.searchTxtBx.BackgroundImage = global::TheServer.Properties.Resources.bord3;
            this.searchTxtBx.Depth = 0;
            this.searchTxtBx.Hint = "Search";
            this.searchTxtBx.Location = new System.Drawing.Point(401, 49);
            this.searchTxtBx.MouseState = MaterialSkin.MouseState.HOVER;
            this.searchTxtBx.Name = "searchTxtBx";
            this.searchTxtBx.PasswordChar = '\0';
            this.searchTxtBx.SelectedText = "";
            this.searchTxtBx.SelectionLength = 0;
            this.searchTxtBx.SelectionStart = 0;
            this.searchTxtBx.Size = new System.Drawing.Size(190, 23);
            this.searchTxtBx.TabIndex = 4;
            this.searchTxtBx.UseSystemPasswordChar = false;
            this.searchTxtBx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTxtBx_KeyDown);
            this.searchTxtBx.Leave += new System.EventHandler(this.searchTxtBx_Leave);
            // 
            // resetBtn
            // 
            this.resetBtn.AutoSize = true;
            this.resetBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetBtn.Depth = 0;
            this.resetBtn.Location = new System.Drawing.Point(746, 329);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.resetBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Primary = false;
            this.resetBtn.Size = new System.Drawing.Size(53, 36);
            this.resetBtn.TabIndex = 15;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // InsertBtn
            // 
            this.InsertBtn.AutoSize = true;
            this.InsertBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.InsertBtn.Depth = 0;
            this.InsertBtn.Location = new System.Drawing.Point(815, 329);
            this.InsertBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.InsertBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.InsertBtn.Name = "InsertBtn";
            this.InsertBtn.Primary = false;
            this.InsertBtn.Size = new System.Drawing.Size(59, 36);
            this.InsertBtn.TabIndex = 14;
            this.InsertBtn.Text = "Insert";
            this.InsertBtn.UseVisualStyleBackColor = true;
            this.InsertBtn.Click += new System.EventHandler(this.InsertionBtn_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::TheServer.Properties.Resources.Screenshot__23_;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(-4, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1226, 666);
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // loginBtn
            // 
            this.loginBtn.AutoSize = true;
            this.loginBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loginBtn.Depth = 0;
            this.loginBtn.Location = new System.Drawing.Point(214, 275);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.loginBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Primary = false;
            this.loginBtn.Size = new System.Drawing.Size(52, 36);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // dashboardPicBx
            // 
            this.dashboardPicBx.Image = global::TheServer.Properties.Resources.dashboard;
            this.dashboardPicBx.Location = new System.Drawing.Point(12, 36);
            this.dashboardPicBx.Name = "dashboardPicBx";
            this.dashboardPicBx.Size = new System.Drawing.Size(889, 48);
            this.dashboardPicBx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dashboardPicBx.TabIndex = 63;
            this.dashboardPicBx.TabStop = false;
            // 
            // TheServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::TheServer.Properties.Resources.Screenshot__23_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1218, 679);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.InsertBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.searchTxtBx);
            this.Controls.Add(this.priceTxtBx);
            this.Controls.Add(this.stkTxtBx);
            this.Controls.Add(this.wtTxtBx);
            this.Controls.Add(this.qtyTxtBx);
            this.Controls.Add(this.brandTxtBx);
            this.Controls.Add(this.manidTxtBx);
            this.Controls.Add(this.catidTxtBx);
            this.Controls.Add(this.pnameTxtBx);
            this.Controls.Add(this.passwordTxtBx);
            this.Controls.Add(this.usernameTxtBx);
            this.Controls.Add(this.pidTxtBx);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.stkLbl);
            this.Controls.Add(this.wtLbl);
            this.Controls.Add(this.qtyLbl);
            this.Controls.Add(this.brandLbl);
            this.Controls.Add(this.manidLbl);
            this.Controls.Add(this.catidLbl);
            this.Controls.Add(this.pnameLbl);
            this.Controls.Add(this.pidLbl);
            this.Controls.Add(this.delPic);
            this.Controls.Add(this.editPic);
            this.Controls.Add(this.pictureBox15);
            this.Controls.Add(this.pictureBox14);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.tableGridVw);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.CloseSqlBtn);
            this.Controls.Add(this.ConnectSqlBtn);
            this.Controls.Add(this.InsertPresetBtn);
            this.Controls.Add(this.DisplayBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.dashboardPicBx);
            this.Controls.Add(this.pictureBox3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(696, 461);
            this.Name = "TheServer";
            this.Sizable = false;
            this.Text = "The Server";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGridVw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardPicBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button DisplayBtn;
        private System.Windows.Forms.DataGridView tableGridVw;
        private System.Windows.Forms.Button ConnectSqlBtn;
        private System.Windows.Forms.Button CloseSqlBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn wt;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn mid;
        private System.Windows.Forms.DataGridViewTextBoxColumn catid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.Label pidLbl;
        private System.Windows.Forms.Label pnameLbl;
        private System.Windows.Forms.Label catidLbl;
        private System.Windows.Forms.Label manidLbl;
        private System.Windows.Forms.Label brandLbl;
        private System.Windows.Forms.Label wtLbl;
        private System.Windows.Forms.Label stkLbl;
        private System.Windows.Forms.Label priceLbl;
        private System.Windows.Forms.Label qtyLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox editPic;
        private System.Windows.Forms.PictureBox delPic;
        private System.Windows.Forms.Button InsertPresetBtn;
        private MaterialSingleLineTextField pidTxtBx;
        private MaterialSingleLineTextField pnameTxtBx;
        private MaterialSingleLineTextField catidTxtBx;
        private MaterialSingleLineTextField manidTxtBx;
        private MaterialSingleLineTextField brandTxtBx;
        private MaterialSingleLineTextField qtyTxtBx;
        private MaterialSingleLineTextField wtTxtBx;
        private MaterialSingleLineTextField stkTxtBx;
        private MaterialSingleLineTextField priceTxtBx;
        private MaterialSingleLineTextField passwordTxtBx;
        private MaterialSingleLineTextField usernameTxtBx;
        private MaterialSingleLineTextField searchTxtBx;
        private MaterialFlatButton resetBtn;
        private MaterialFlatButton InsertBtn;
        private PictureBox pictureBox3;
        private MaterialFlatButton loginBtn;
        private PictureBox dashboardPicBx;
    }
}

