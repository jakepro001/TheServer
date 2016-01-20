using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
                        msg("Client Connected...");
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
            SendLoop("Initialize");
        }
        
        private void SendBtn_Click(object sender, EventArgs e)
        {
            SendLoop(MsgTxtBx.Text);
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

            msg("Recieved : " + Encoding.ASCII.GetString(data));            

        }

        private void MsgTxtBx_Click(object sender, EventArgs e)
        {
            MsgTxtBx.Text = "";
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            _clientSocket.Close();
        }
    }
}
