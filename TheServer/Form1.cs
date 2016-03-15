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
using Finisar.SQLite;
using System.Diagnostics;

namespace TheServer
{
    public partial class Form1 : Form
    {

        #region The Variables

        private byte[] _buffer = new byte[1024];
        public delegate void invokeDelegate();

        #region Client Variable

        

        #endregion

        #region connection variables
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> _clientSockets = new List<Socket>();

        #endregion        

        #region DB Variables
        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;

        #endregion


        #endregion

        public Form1()
        {
            InitializeComponent();

            //locking the ui
            //disablingEverything();

        }


        #region Login 

        private void disablingEverything()
        {

            pictureBox3.Visible = false;

            searchPic.Visible = false;
            searchTxtBx.Visible = false;

            catidTxtBx.Enabled = false;
            manidTxtBx.Enabled = false;
            brandTxtBx.Enabled = false;
            qtyTxtBx.Enabled = false;
            pnameTxtBt.Enabled = false;
            pidTxtBx.Enabled = false;
            wtTxtBx.Enabled = false;
            stkTxtBx.Enabled = false;
            priceTxtBx.Enabled = false;


            pictureBox7.Enabled = false;

            InsertBtn.Enabled = false;
            resetBtn.Enabled = false;

            searchPic.Enabled = false;
            searchTxtBx.Enabled = false;

            tableGridVw.Enabled = false;

            delPic.Enabled = false;
            editPic.Enabled = false;

            pictureBox15.Enabled = false;
            label5.Enabled = false;          

        }

        void enableEverything()
        {

            pictureBox3.Visible = true;

            searchPic.Visible = true;
            searchTxtBx.Visible = true;

            catidTxtBx.Enabled = true;
            manidTxtBx.Enabled = true;
            brandTxtBx.Enabled = true;
            qtyTxtBx.Enabled = true;
            pnameTxtBt.Enabled = true;
            pidTxtBx.Enabled = true;
            wtTxtBx.Enabled = true;
            stkTxtBx.Enabled = true;
            priceTxtBx.Enabled = true;


            pictureBox7.Enabled = true;

            InsertBtn.Enabled = true;
            resetBtn.Enabled = true;

            searchPic.Enabled = true;
            searchTxtBx.Enabled = true;

            tableGridVw.Enabled = true;

            delPic.Enabled = true;
            editPic.Enabled = true;

            pictureBox15.Enabled = true;
            label5.Enabled = true;

        }

        private void disableLogin()
        {
            usernameTxtBx.Text = "";
            passwordTxtBx.Text = "";


            usernameTxtBx.Enabled = false;
            passwordTxtBx.Enabled = false;

            loginBtn.Enabled = false;

        }


        private void login()
        {            
            try
            {
                sqlite_cmd.CommandText = "SELECT * FROM users";
                sqlite_cmd.CommandTimeout = 30;
                sqlite_cmd.CommandType = CommandType.Text;
                
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {

                    if (usernameTxtBx.Text == sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("uname")).ToString())
                    {
                        if (passwordTxtBx.Text == sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pass")).ToString())
                        {
                            logCall(false, "Logged in");
                            enableEverything();
                            disableLogin();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                logCall(false, "Exception in Login");
                logCall(false, ex.Message);
            }
        }

        #endregion

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

        //When a client tries to connect
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


                string nilValue = "Nill";

                string id = string.Empty;

                string retData = nilValue;
                byte[] data = Encoding.ASCII.GetBytes(retData);


                //If a null text or an empty one gets in

                if ((text == string.Empty )||( text == null )||( text == ""))
                {
                    retData = nilValue;
                    data = Encoding.ASCII.GetBytes(retData);

                    logCall(true, retData);
                    Debug.WriteLine("Sending : " + retData);

                    //Sending the data back
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);

                    return;
                }


                try
                {


                    //getting first three letters for identification
                    try
                    {

                        try  //for id creation
                        {
                            id = string.Empty;

                            char[] te = text.ToCharArray();

                            int loc_ = text.IndexOf('_');

                            id = new string(te, 0, loc_);

                            Debug.WriteLine("Id : " + id);
                            logCall(false, "Id:" + id);

                        }
                        catch (Exception ex)
                        {
                            logCall(false, "Exception in id creation");
                            logCall(false, ex.Message);
                        }

                        //Creating Table for the connected device


                        //Debug.WriteLine(id.Length.ToString());

                        string whichOne = text.Substring(0, 3);

                        int len = id.Length;

                        if (len > 3)
                        {
                            //Debug.WriteLine("String Len:" + len.ToString());

                            if (text.Contains("Initialize") && text.Contains("div"))
                            {
                                Debug.WriteLine("Got the first call Initialize from device " + id);
                                retData = "Acknowledged";

                                try
                                {
                                    ConnectToSql();

                                    sqlite_cmd.CommandText = "DROP TABLE " + id + ";";
                                    sqlite_cmd.ExecuteNonQuery();
                                    logCall(false, "Dropped existing table");

                                    CloseSqlConnection();
                                }
                                catch (Exception ex)
                                {
                                    logCall(false, "Exception in creating table for the device");
                                    logCall(false, ex.Message);
                                }

                                try
                                {
                                    ConnectToSql();

                                    sqlite_cmd.CommandText = "CREATE TABLE " + id + "(pid varchar(50), pname varchar(50), price float);";
                                    sqlite_cmd.ExecuteNonQuery();
                                    logCall(false, "Created the table for device " + id);

                                    CloseSqlConnection();
                                }
                                catch (Exception ex)
                                {
                                    logCall(false, "Exception in creating table for the device");
                                    logCall(false, ex.Message);
                                }

                            }
                            else if (text.Contains("Initialize") && text.Contains("cou"))
                            {
                                Debug.WriteLine("Got the first call Initialize from client " + id);
                                retData = "Acknowledged";
                            }
                            else if (whichOne == "div")
                            {
                                retData = string.Empty;
                                Debug.WriteLine("Got into device condition");
                                retData = DiviceHandle(text, id);

                            }
                            else if (whichOne == "cou")
                            {
                                retData = string.Empty;
                                Debug.WriteLine("Got into client condition");
                                retData = CounterHandle(text);
                            }
                            else
                            {
                                logCall(false, "Exception in the received text: Invalid Format");
                                logCall(false, "Text: " + text);
                            }
                        }
                        else
                        {
                            logCall(false, "Exception : Id Recognition");
                            logCall(false, "The id is not recognized.. Discarding the request");
                        }
                    }
                    catch (Exception ex)
                    {
                        logCall(false, ex.Message);
                    }
                    

                    if(retData == string.Empty || retData ==null || retData == "")
                    {
                        retData = nilValue;
                    }

                    logCall(true, retData);
                    Debug.WriteLine("Sending : " + retData);
                                        
                    data = Encoding.ASCII.GetBytes(retData);

                    //Sending the data back
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);

                }

                catch (Exception ex)
                {
                    socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                    logCall(false, ex.Message);
                }

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

        private string CounterHandle(string text)
        {

            string retResult = string.Empty;
            string req = string.Empty;

            char[] te = text.ToCharArray();

            int loc_ = text.IndexOf('_');
            int len = (text.Length - loc_) - 1;

            req = new string(te, (loc_ + 1), len);

            logCall(false, "Req from counter: " + req);

            ConnectToSql();
            retResult = deviceDatabaseReturning(req);
            CloseSqlConnection();

            

            return retResult;
        }

        
        private string DiviceHandle(string text,string id)
        {
            string retResult = string.Empty;
            string barcode = string.Empty;       
            string searchKey = string.Empty;

            char[] te = text.ToCharArray();

            int loc_ = text.IndexOf('_');
            int len = (text.Length - loc_) - 1;

            barcode = new string(te,(loc_+1), len); //get the barcode

            logCall(false, "Barcode : " + barcode);

            te = barcode.ToCharArray();
            
            //len = (barcode.Length - 6);

            searchKey = new string(te, 6, 5);


            logCall(false, "Search From Device");
            logCall(false, "key : " + searchKey);


            ConnectToSql();
            retResult = SearchSqlForDevice(searchKey,id);
            CloseSqlConnection();

            string retResultSer = "Search_" + retResult;

            if (retResult == string.Empty)
            {
                logCall(false, "Exception: Results not founnd");
            }
            
            return retResultSer;
        }

        



        #endregion


        /// <summary>
        /// The DataBase Controllers
        /// </summary>
        #region The DataBase

        public void ConnectToSql()
        {
            try
            {
                if (!File.Exists("database.db"))
                {
                    // create a new database connection:
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=True;Compress=True;");
                    //CreateTableBtn.Enabled = true;
                }
                else
                {
                    sqlite_conn = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
                    //CreateTableBtn.Enabled = false;
                }

                logCall(false, "Created DB ");
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }


            try
            {
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();                

                logCall(false, "DB Connection established");
            }
            catch(Exception ex)
            {
                logCall(false, ex.Message);
            }


        }

        public void CreateTable()
        {
            //Product Table
            try
            {
                sqlite_cmd.CommandText = "CREATE TABLE Categories (catid int primary key, catname varchar(30), num int);";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Category Table Created");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: In Categories");
                logCall(false, ex.Message);
            }
            catch(Exception ex)
            {
                logCall(false, ex.Message);
            }


            //Main Table
            try
            {
                sqlite_cmd.CommandText = "CREATE TABLE Products (pid varchar(10) primary key, pname varchar(30), catid int  , mid int, brand varchar(50),  qty float , wt float , stock float, price float ,foreign key(catid) references Categories(catid));";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Products Table Created");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: In Products");
                logCall(false, ex.Message);
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }

            //User Table
            try
            {
                sqlite_cmd.CommandText = "CREATE TABLE Users(uid int primary key, uname varchar(50), pass varchar(50));";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Users Table Created");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: in Users");
                logCall(false, ex.Message);
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }


            //Deleting the existing Cart device table
            try
            {
                sqlite_cmd.CommandText = "DROP TABLE CartDevice";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Deleted Cart device table");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: in Dropping table");
                logCall(false, ex.Message);
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }

            //Creating Cart device table
            try
            {
                sqlite_cmd.CommandText = "CREATE TABLE CartDevice (did varchar(50) primary key);";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Cart Device Table Created");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: in Creation of device table");
                logCall(false, ex.Message);
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }

            //Deleting the existing Counter device table
            try
            {
                sqlite_cmd.CommandText = "DROP TABLE CounterDevice";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Deleted Counter device table");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: in Dropping table");
                logCall(false, ex.Message);
            }
            catch (Exception ex) 
            {
                logCall(false, ex.Message);
            }

            //Creating Counter device table
            try
            {
                sqlite_cmd.CommandText = "CREATE TABLE CounterDevice (did varchar(50) primary key);";
                sqlite_cmd.ExecuteNonQuery();
                logCall(false, "Counter Device Table Created");
            }
            catch (SQLiteException ex)
            {
                logCall(false, "SQL Exception: in Creation of device table");
                logCall(false, ex.Message);
            }
            catch (Exception ex)
            {
                logCall(false, ex.Message);
            }


        }

        public void Insertion(string tname,bool preSet)
        {
            if(preSet == true)
            {
                //insertion to the Product table
                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (1,'TIGER',100,0101,'Britannia',100,50,1000,10);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted tiger");
                }
                catch(Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }

                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (2,'SUNFEAST',100,0102,'Nestle',100,50,1000,20);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted sunfeast");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }

                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (3,'OREO',100,0103,'Britannia',100,20,900,15);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }

                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (4,'LUX',102,0201,'LUX',100,50,100,20);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }

                /*
                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (1,'TIGER',100,0101,'Britannia',100,50,1000,10);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }

                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (1,'TIGER',100,0101,'Britannia',100,50,1000,10);";
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet Product insertion:");
                    logCall(false, ex.Message);
                }
                */

                //Insertion into Users
                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO Users VALUES (1,'admin','admin');";
                    sqlite_cmd.ExecuteNonQuery();
                    logCall(false, "inserted to user table");
                }
                catch(Exception ex)
                {
                    logCall(false, "Exception in Insertion to Users:");
                    logCall(false, ex.Message);
                }

            }
            else
            {
                try
                {
                    sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (" + pidTxtBx.Text + ",'" + pnameTxtBt.Text + "'," + catidTxtBx.Text + "," + manidTxtBx.Text + ",'" + brandTxtBx.Text + "'," + qtyTxtBx.Text + "," + wtTxtBx.Text + "," + stkTxtBx.Text + "," + priceTxtBx.Text + ");";
                    System.Console.WriteLine(sqlite_cmd.CommandText);
                    sqlite_cmd.ExecuteNonQuery();

                    logCall(false, "Inserted");
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in preSet insertion:");
                    logCall(false, ex.Message);
                }
            }

            ConnectToSql();
            displaySql();
            CloseSqlConnection();


        }        

        public void displaySql()
        {

            logCall(false, "Display");

            using (sqlite_cmd)
            {
                
                //sqlite_cmd = new SQLiteCommand();
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM Products;";

                sqlite_cmd.CommandTimeout = 30;

                sqlite_cmd.CommandType = CommandType.Text;

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                //(pid int primary key, pname varchar(30), catid int, mid int, brand varchar(50), qty float, wt float, stock float, price float, foreign key(catid) references Categories(catid)); ";

                tableGridVw.Rows.Clear();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    // Print out the content of the text field:
                    System.Console.WriteLine(sqlite_datareader["pid"]);
                    System.Console.WriteLine(sqlite_datareader["pname"]);
                    System.Console.WriteLine(sqlite_datareader["catid"]);
                    System.Console.WriteLine(sqlite_datareader["mid"]);
                    System.Console.WriteLine(sqlite_datareader["brand"]);
                    System.Console.WriteLine(sqlite_datareader["qty"]);
                    System.Console.WriteLine(sqlite_datareader["wt"]);
                    System.Console.WriteLine(sqlite_datareader["stock"]);
                    System.Console.WriteLine(sqlite_datareader["price"]);

                    tableGridVw.Rows.Add(new object[] {

                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("catid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("mid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("brand")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("qty")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("wt")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("stock")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price"))

                    });


                }




                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
                //sqlite_conn.Open();

                logCall(false, "Complete");
                

            }
            

        }

        private void SearchSql( bool device, string s)
        {
            using (sqlite_cmd)
            {

                tableGridVw.Rows.Clear();

                logCall(false, "Searching...");

                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT * FROM Products WHERE pname LIKE '%" + s + "%';";

                sqlite_cmd.CommandTimeout = 30;

                sqlite_cmd.CommandType = CommandType.Text;

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();



                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {


                    // Print out the content of the text field:
                    System.Console.WriteLine(sqlite_datareader["pid"]);
                    System.Console.WriteLine(sqlite_datareader["pname"]);
                    System.Console.WriteLine(sqlite_datareader["catid"]);
                    System.Console.WriteLine(sqlite_datareader["mid"]);
                    System.Console.WriteLine(sqlite_datareader["brand"]);
                    System.Console.WriteLine(sqlite_datareader["qty"]);
                    System.Console.WriteLine(sqlite_datareader["wt"]);
                    System.Console.WriteLine(sqlite_datareader["stock"]);
                    System.Console.WriteLine(sqlite_datareader["price"]);

                    tableGridVw.Rows.Add(new object[] {

                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("catid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("mid")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("brand")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("qty")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("wt")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("stock")),
                        sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price"))

                    });



                }





                sqlite_conn.Close();


                logCall(false, "Complete");


            }


            
        }

        private string SearchSqlForDevice(string searchKey, string id)
        {

            /// The format of search will be as
            ///If it is a search from the insie of the application, then it will be the name of the product
            ///
            ///If the search is from the Device, then the pid will be searched            

            string RetString = string.Empty;

            try
            {


                logCall(false, "Searching... Req from device");

                sqlite_cmd.CommandText = "SELECT * FROM Products WHERE pid LIKE '%" + searchKey + "%';";
                sqlite_cmd.CommandTimeout = 30;
                sqlite_cmd.CommandType = CommandType.Text;

                //logCall(false, "Execution of the code");
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                //logCall(false, "Going for while loop");

                string pname = string.Empty;
                string price = string.Empty;

                while (sqlite_datareader.Read())
                {

                    try
                    {

                        //RetString = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")).ToString() + "_" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price")).ToString();
                        RetString = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price")).ToString();
                        pname = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")).ToString();
                        price = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price")).ToString();
                    }
                    catch (Exception ex)
                    {
                        logCall(false, "Exception in device req search inside while");
                        logCall(false, ex.Message);
                    }

                }

                CloseSqlConnection();

                if (RetString != string.Empty)
                {
                    try
                    {
                        ConnectToSql();
                        sqlite_cmd.CommandText = "INSERT INTO " + id + " VALUES( '" + searchKey + "', '" + pname + "', '" + price + "');";
                        sqlite_cmd.ExecuteNonQuery();
                        CloseSqlConnection();
                    }
                    catch (Exception ex)
                    {
                        logCall(false, "Exception in insertion from the device");
                        logCall(false, ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                logCall(false, "Exception in searching by device request");
                logCall(false, ex.Message);
            }

            return RetString;
        }

        private string deviceDatabaseReturning(string req)
        {
            logCall(false, "In the database return func");

            string retResults = string.Empty;

            using (sqlite_cmd)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM " + req + " ;";
                    sqlite_cmd.CommandTimeout = 30;
                    sqlite_cmd.CommandType = CommandType.Text;

                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    logCall(false, "Searching");
                    retResults = "";
                    while(sqlite_datareader.Read())
                    {
                        try
                        {
                            retResults += sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pid")).ToString() + "_" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")).ToString() + "@" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price")).ToString()+"$";                                                   
                        }
                        catch(Exception ex)
                        {
                            logCall(false, "Exception in while in database returning : Not found");
                            logCall(false, ex.Message);
                        }
                    }


                }
                catch(Exception ex)
                {
                    logCall(false, "Exception in Database returning according to the req from counter");
                    logCall(false, ex.Message);
                }
            }
                       

            if (retResults == string.Empty)
            {
                logCall(false, "Not found");
            }
            else
            {
                logCall(false, "Returning Result");
                logCall(false, retResults);
            }

            return retResults;
        }


        public void CloseSqlConnection()
        {
           sqlite_conn.Close();
        }

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

        #region Form Events
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
        #endregion

        #region ServerEvents
        private void btnSend_Click(object sender, EventArgs e)
        {
            //send();
        }

        #endregion        

        #region Database events

        private void ConnectSqlBtn_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            CreateTable();
            CloseSqlConnection();
        }
        private void CreateTableBtn_Click(object sender, EventArgs e)
        {
            //CreateTable();
        }

        private void InsertionBtn_Click(object sender, EventArgs e)
        {
           ConnectToSql();
            Insertion("Products", false);
            CloseSqlConnection();
        }

        private void DisplayBtn_Click(object sender, EventArgs e)
        {            
            ConnectToSql();
            displaySql();
            CloseSqlConnection();
        }

        private void CloseSqlBtn_Click(object sender, EventArgs e)
        {
            CloseSqlConnection();
        }

        

        private void searchPic_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            string s = searchTxtBx.Text;
            SearchSql(false,s);
            CloseSqlConnection();
        }

        private void searchTxtBx_Click(object sender, EventArgs e)
        {
            searchTxtBx.Text = "";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            pidTxtBx.Text = "";
            pnameTxtBt.Text = "";
            catidTxtBx.Text = "";
            manidTxtBx.Text = "";
            brandTxtBx.Text = "";
            qtyTxtBx.Text = "";
            wtTxtBx.Text = "";
            stkTxtBx.Text = "";
            priceTxtBx.Text = "";
        }

        private void editPic_Click(object sender, EventArgs e)
        {

        }

        private void delPic_Click(object sender, EventArgs e)
        {

        }

        private void InsertPresetBtn_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            Insertion("Products", true);
            CloseSqlConnection();
        }


        #endregion

        #region Login Events
        private void loginBtn_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            login();
            CloseSqlConnection();
        }


        #endregion

        #endregion


    }
}
