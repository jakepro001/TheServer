using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheClient
{
    public partial class ClientPage : Form
    {

        #region Variables
        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //delegate void SetTextCallback(string text);

        public delegate void invokeDelegate();

        SerialPort MyCOMPort;

        byte[] data;

        #endregion

        public ClientPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Client
        /// </summary>
        #region Client
        private void LoopConnect()
        {
            int attempts = 0;
            try
            {
                while (!_clientSocket.Connected)
                {
                    try
                    {
                        attempts++;
                        _clientSocket.Connect(IPAddress.Loopback, 100);
                        logCall(false,"Server Connected...");
                        ListenToPort();
                    }
                    catch
                    {
                        logCall(false,"Connection attempts : " + attempts.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logCall(false,"Failed Attempts >>" + ex.Message);
            }
        }
        private void SendLoop(string text)
        {
            //Debug.WriteLine(text);

            byte[] buffer = Encoding.ASCII.GetBytes(text);
            _clientSocket.Send(buffer);

            byte[] receivedBuf = new byte[1024];

            int rec = _clientSocket.Receive(receivedBuf);

            byte[] data = new byte[rec];

            Array.Copy(receivedBuf, data, rec);

            string recMsg = Encoding.ASCII.GetString(data);

            logCall(false,recMsg);


            if (recMsg.Contains("Search"))
            {

                string[] splitMsg = recMsg.Split('_');

                double price = Convert.ToDouble(splitMsg[1]);

                logCall(false,price.ToString());

                SendtoPort(price.ToString());


            }

            else if (recMsg.Contains("_") && recMsg.Contains("@") && recMsg.Contains("$"))
            {
                int len = recMsg.Length;
                char[] te = recMsg.ToCharArray();

                char[] tempPid, tempPname, tempPrice;

                tempPid = new char[30];
                tempPname = new char[30];
                tempPrice = new char[30];

                string Pid, Pname, Price;

                Debug.WriteLine(len.ToString());

                for (int i = 0; i < len; i++)
                {
                    int j, k, l, n = 0;

                    for (n = 0, j = i; te[j] != '_'; j++, n++)
                    {
                        tempPid[n] = te[j];
                        Debug.WriteLine(new string(tempPid));
                    }
                    tempPid[n] = '\0';
                    Pid = new string(tempPid);
                    Debug.WriteLine(Pid);

                    for (n = 0, k = j + 1; te[k] != '@'; k++, n++)
                    {
                        tempPname[n] = te[k];
                        Debug.WriteLine(new string(tempPname));
                    }
                    tempPname[n] = '\0';
                    Pname = new string(tempPname);
                    Debug.WriteLine(Pname);

                    for (n = 0, l = k + 1; te[l] != '$'; l++, n++)
                    {
                        tempPrice[n] = te[l];
                        Debug.WriteLine(new string(tempPrice));
                    }
                    tempPrice[n] = '\0';
                    Price = new string(tempPrice);
                    Debug.WriteLine(Price);

                    i = l;

                    logCall(false, Pid + Pname + Price);

                }

            }

        }

        #endregion

        /// <summary>
        /// Serial Port
        /// </summary>
        /// <param name="price"></param>
        #region Serial Port

        private void SendtoPort(string price)
        {
            try
            {                    
                MyCOMPort.Write(price);
            }
            catch(Exception ex)
            {
                logCall(false,"Exception In Sending to port");
                logCall(false, ex.Message);
            }
        }

        private void ListenToPort()
        {
            try
            {
                if (MyCOMPort == null)
                {
                    MyCOMPort = new SerialPort();

                    MyCOMPort.PortName = "COM6";
                    MyCOMPort.BaudRate = 115200;
                    MyCOMPort.Parity = Parity.None;
                    MyCOMPort.DataBits = 8;
                    MyCOMPort.StopBits = StopBits.One;
                }

                if (MyCOMPort.IsOpen)
                {
                    MyCOMPort.Close();
                }

                if (!MyCOMPort.IsOpen)
                    MyCOMPort.Open();

                MyCOMPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataRecieved);
            }
            catch(Exception ex)
            {
                logCall(false,"Exceptin in listen to port");
                logCall(false,ex.Message);
            }
        }

        private void SerialPortDataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            int dataLength = MyCOMPort.BytesToRead;
            data = new byte[dataLength];
            int nbrDataRead = MyCOMPort.Read(data, 0, dataLength);
            if (nbrDataRead == 0)
                return;

            string text = Encoding.ASCII.GetString(data);

            Debug.WriteLine("Rec frm COM : " + text);
            logCall(false,"Rec frm COM : " + text);

            text = text.ToLower();
            if(text.Contains("insert"))
            {
                insrtLbl.ForeColor = Color.Chartreuse;
                insrtLbl.Text = "Insert";
            }
            else if(text.Contains("remove"))
            {
                insrtLbl.ForeColor = Color.OrangeRed;
                insrtLbl.Text = "Remove";
            }
            else
            {
                logCall(false,"Exception in data recieved from COM");
            }


        }

        

        #endregion

        /// <summary>
        /// UI Control
        /// </summary>
        /// <param name="text"></param>
        #region UI Control        
        //For Log calls
        public void logCall(bool sent, string text)
        {
            invokeDelegate del = () =>
            {
                logData(sent, text);
            };
            Invoke(del);
        }
        public void logData(bool sent, string text)
        {
            txtLog.Text += "\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt") + (sent ? " SENT:\r\n" : " RECEIVED:\r\n");
            txtLog.Text += text;
            txtLog.Text += "\r\n";
            if (txtLog.Lines.Length > 500)
            {
                string[] temp = new string[500];
                Array.Copy(txtLog.Lines, txtLog.Lines.Length - 500, temp, 0, 500);
                txtLog.Lines = temp;
            }
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        #endregion

        /// <summary>
        /// Event Handlers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Event Handlers

        private void ClientPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MyCOMPort.IsOpen)
                MyCOMPort.Close();
        }
        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            LoopConnect();
            SendLoop("div001_Initialize");
        }
        
        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (MsgTxtBx.Text != null)
            {
                SendLoop(MsgTxtBx.Text);
            }
        }        

        private void MsgTxtBx_Click(object sender, EventArgs e)
        {
            MsgTxtBx.Text = "";
        }

        private void MsgTxtBx_TextChanged(object sender, EventArgs e)
        {
            /*
            if(MsgTxtBx.Text.Length == 12)
            {
                MessageBox.Show(MsgTxtBx.Text);
            }
            */
        }

        private void MsgTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string te = string.Empty;
                if (insrtLbl.Text == "Insert")
                    te = "div001_" + MsgTxtBx.Text + "_Insert";
                else if (insrtLbl.Text == "Remove")
                    te = "div001_" + MsgTxtBx.Text + "_Remove";

                SendLoop(te);

                MsgTxtBx.Text = "";

            }
        }

        private void InsrtBtn_Click(object sender, EventArgs e)
        {
            insrtLbl.ForeColor = Color.Chartreuse;
            insrtLbl.Text = "Insert";
        }

        private void rmvBtn_Click(object sender, EventArgs e)
        {
            insrtLbl.ForeColor = Color.OrangeRed;
            insrtLbl.Text = "Remove";
        }



        #endregion

        
    }
}
