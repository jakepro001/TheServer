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

        private static Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //Thread _connectClient = new Thread(LoopConnect);

        

        public ClientPage()
        {
            InitializeComponent();
        }


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
                        msg("Server Connected...");
                    }
                    catch
                    {
                        msg("Connection attempts : " + attempts.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                msg("Failed Attempts >>" + ex.Message);
            }
        }

        delegate void SetTextCallback(string text);

        public void msg(string text)
        {
            //Debug.WriteLine(mesg);
            //LogLstBx.Items.Add(mesg);


            if (this.LogLstBx.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(msg);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.LogLstBx.Items.Add(text);
            }

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

        private void SendLoop(string text)
        {
            Debug.WriteLine(text);

            byte[] buffer = Encoding.ASCII.GetBytes(text);
            _clientSocket.Send(buffer);

            byte[] receivedBuf = new byte[1024];

            int rec = _clientSocket.Receive(receivedBuf);

            byte[] data = new byte[rec];

            Array.Copy(receivedBuf, data, rec);

            string recMsg = Encoding.ASCII.GetString(data);

            msg("Recieved : " + recMsg);


            if (recMsg.Contains("Search"))
            {
                int loc = recMsg.IndexOf("_");

                char[] te = recMsg.ToCharArray();

                string price = new string(te, loc + 1, (recMsg.Length - loc - 1));

                msg(price);

                SendtoPort(price);


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

                    for (n = 0,j = i; te[j] != '_'; j++,n++)
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

                    for (n=0,l = k + 1 ; te[l] != '$' ; l++,n++)
                    {
                        tempPrice[n] = te[l];
                        Debug.WriteLine(new string(tempPrice));
                    }
                    tempPrice[n] = '\0';
                    Price = new string(tempPrice);
                    Debug.WriteLine(Price);

                    i = l;

                    msg(Pid + Pname + Price);

                }

            }

        }

        private void MsgTxtBx_Click(object sender, EventArgs e)
        {
            MsgTxtBx.Text = "";
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            _clientSocket.Close();
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
                //MessageBox.Show(MsgTxtBx.Text);

                string te = "div001_" + MsgTxtBx.Text;

                SendLoop(te);

            }
        }

        private void SendtoPort(string price)
        {
            SerialPort MyCOMPort = new SerialPort(); 

            
            MyCOMPort.PortName = "COM6";          
            MyCOMPort.BaudRate = 115200;               
            MyCOMPort.Parity = Parity.None;        
            MyCOMPort.DataBits = 8;                  // No of Data bits = 8
            MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1

            MyCOMPort.Open();                        // Open the port
            MyCOMPort.Write(price);                    // Write an ascii "A"
            MyCOMPort.Close();
        }
    }
}
