using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedCorona.Net;
using System.Net;

namespace TheServer
{
    public partial class Form1 : Form
    {        

        private byte[] _buffer = new byte[1024];

        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private List<Socket> _clientSockets = new List<Socket>();

        public delegate void invokeDelegate();

        public Form1()
        {
            InitializeComponent();
        }


        /*

        /*
        //[code:Red corona]

        /// <summary>
        /// Client Handling
        /// </summary>
        #region Client/Information Handle
            
        private void send()
        {
            string text = "Acknowledged";
            server.Broadcast(Encoding.UTF8.GetBytes(text));
        }



        #endregion


        /// <summary>
        /// Server Side
        /// </summary>
        #region The Server

        
        
        void StartServer()
        {
            try
            {
                server = new Server(3001, new ClientEvent(ClientConnect));
                lblStatus.Text = "Server is Up";
                lblStatus.BackColor = Color.Lime;
                invokeDelegate del = () =>
                {
                    logData(false, "Server up");
                };
                Invoke(del);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Server Down";
                lblStatus.BackColor = Color.Red;
                invokeDelegate del = () =>
                 {
                     logData(false, "Exception :: " + ex.Message);
                 };
                Invoke(del);
            }
                       

        }

        bool ClientConnect(Server serv, ClientInfo new_client)
        {
            invokeDelegate del = () =>
            {
                logData(false, "Connected");
            };
            Invoke(del);

            new_client.Delimiter = "\n";
            new_client.OnRead += new ConnectionRead(ReadData);
            return true;
        }

        private void ReadData(ClientInfo ci, string text)
        {
            invokeDelegate del = () =>
            {
                logData(false, "  "+ci.ID + ":" + text);
            };
            Invoke(del);

            if (text[0]=='!')
            {
                server.Broadcast(Encoding.UTF8.GetBytes(text));
            }
            else
            {
                ci.Send(text);
            }
        }

        



        #endregion

        

        */

        /// <summary>
        /// The Server Side
        /// </summary>
        #region The Server

        private void StartServer()
        {

            logCall(false, "Setting up server");
            try
            {
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
                _serverSocket.Listen(5);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);


                logCall(false, "Server is up");
                lblStatus.Text = "Server is Up";
                lblStatus.BackColor = Color.Lime;

            }
            catch (Exception ex)
            {
                lblStatus.Text = "Server is Down";
                lblStatus.BackColor = Color.Red;
                logCall(false, "Server is down");
                logCall(false, ex.Message);
            }

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = _serverSocket.EndAccept(ar);
                _clientSockets.Add(socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                _serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);

                logCall(false, "Client Connected");
                lblConUpdate(true);
            }
            catch(Exception ex)
            {
                logCall(false, "Client Cannot Connect");
                logCall(false, ex.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);

                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);

                string text = Encoding.ASCII.GetString(dataBuf);
                logCall(false, text);



                byte[] data;

                if (text.ToLower() == "get time")
                {
                    logCall(true, DateTime.Now.ToLongTimeString());
                    data = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());                   
                }
                else if (text.ToLower() == "initialize")
                {
                    logCall(true, "Done");
                    data = Encoding.ASCII.GetBytes("Done");
                }
                else
                {
                    logCall(true, "Ack");
                    data = Encoding.ASCII.GetBytes("Ack");
                    
                }


                //Sending the data back
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch (Exception ex)
            {
                logCall(false, "Client Disconnected");
                logCall(false, ex.Message);
                lblConUpdate(false);
            }


        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }

        #endregion


        /// <summary>
        /// The DataBase Controllers
        /// </summary>
        #region The DataBase






        #endregion

        /// <summary>
        /// The Contols For UI
        /// </summary>
        #region UI Control                

        //For Log calls
        public void logCall(bool sent, string text)
        {
            invokeDelegate del = () =>
            {
                logData(sent,text);
            };
            Invoke(del);
        }
        public void logData(bool sent, string text)
        {
            txtLog.Text += "\r\n" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss tt")+ (sent ? " SENT:\r\n" : " RECEIVED:\r\n");
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

        //For No: of client connected label
        public void lblConUpdate(bool connected)
        {
            invokeDelegate del = () =>
            {
                lblUpdatDelCall(connected);
            };
            Invoke(del);
        }
        public void lblUpdatDelCall(bool connected)
        {
            string temp = lblConnected.Text;
            int n = Int32.Parse(temp);
            if (connected == true)
            {
                n += 1;
            }
            else
            {
                n -= 1;
            }
            lblConnected.Text = n.ToString();
        }

    
    

        #endregion


        /// <summary>
        /// The Event Handlers
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            StartServer();
        }       

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }       

        private void btnSend_Click(object sender, EventArgs e)
        {
            //send();
        }
        


        #endregion
    }
}
