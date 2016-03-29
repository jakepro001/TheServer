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
using MaterialSkin;
using MaterialSkin.Controls;

namespace TheServer
{
    public partial class TheServer : MaterialForm
    {

        #region The Variables

        private readonly MaterialSkinManager materialSkinManager;

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


        public TheServer()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);


            //Disabling the labels if they are enabled
            hideLabel();

            //locking the ui
            disablingEverything();

        }


        /// <summary>
        /// The Login Logout
        /// </summary>
        #region Login Logout

        //Login Section
        private void login()
        {
            try
            {
                sqlite_cmd.CommandText = "SELECT * FROM users";
                sqlite_cmd.CommandTimeout = 30;
                sqlite_cmd.CommandType = CommandType.Text;

                sqlite_datareader = sqlite_cmd.ExecuteReader();

                bool loggedIn = false;

                while (sqlite_datareader.Read())
                {

                    if (usernameTxtBx.Text == sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("uname")).ToString())
                    {
                        if (passwordTxtBx.Text == sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pass")).ToString())
                        {
                            logCall(false, "Logged in");
                            enableEverything();
                            disableLogin();
                            loggedIn = true;
                        }
                    }
                }

                if(!loggedIn)
                {
                    MessageBox.Show("InCorrect Username or Password", "Failed To Login");
                    usernameTxtBx.Text = "";
                    passwordTxtBx.Text = "";
                }

            }
            catch (Exception ex)
            {
                logCall(false, "Exception in Login");
                logCall(false, ex.Message); 
            }
        }
        private void disableLogin()
        {
            usernameTxtBx.Text = "";
            passwordTxtBx.Text = "";


            usernameTxtBx.Enabled = false;
            passwordTxtBx.Enabled = false;

            loginBtn.Text = "LogOut";

        }

        //UI Section
        private void disablingEverything()
        {

            dashboardPicBx.Visible = false;

            //searchPic.Visible = false;
            searchTxtBx.Visible = false;

            

            catidTxtBx.Enabled = false;
            manidTxtBx.Enabled = false;
            brandTxtBx.Enabled = false;
            qtyTxtBx.Enabled = false;
            pnameTxtBx.Enabled = false;
            pidTxtBx.Enabled = false;
            wtTxtBx.Enabled = false;
            stkTxtBx.Enabled = false;
            priceTxtBx.Enabled = false;


            pictureBox7.Enabled = false;

            InsertBtn.Enabled = false;
            resetBtn.Enabled = false;

            tableGridVw.Enabled = false;

            delPic.Enabled = false;
            editPic.Enabled = false;

            pictureBox15.Enabled = false;
            label5.Enabled = false;

            tableGridVw.Rows.Clear();

            pidTxtBx.Text = "";
            pnameTxtBx.Text = "";
            catidTxtBx.Text = "";
            manidTxtBx.Text = "";
            brandTxtBx.Text = "";
            qtyTxtBx.Text = "";
            wtTxtBx.Text = "";
            stkTxtBx.Text = "";
            priceTxtBx.Text = "";

            InsertBtn.Text = "Insert";

        }

        void enableEverything()
        {

            dashboardPicBx.Visible = true;
            
            searchTxtBx.Visible = true;

            catidTxtBx.Enabled = true;
            manidTxtBx.Enabled = true;
            brandTxtBx.Enabled = true;
            qtyTxtBx.Enabled = true;
            pnameTxtBx.Enabled = true;
            pidTxtBx.Enabled = true;
            wtTxtBx.Enabled = true;
            stkTxtBx.Enabled = true;
            priceTxtBx.Enabled = true;


            pictureBox7.Enabled = true;

            InsertBtn.Enabled = true;
            resetBtn.Enabled = true;

            tableGridVw.Enabled = true;

            delPic.Enabled = true;
            editPic.Enabled = true;

            pictureBox15.Enabled = true;
            label5.Enabled = true;

        }

        //Logout Section
        private void logout()
        {
            enableLogin();
            disablingEverything();
            logCall(false, "Logged Out");
            MessageBox.Show("Logged Out");
        }

        private void enableLogin()
        {
            usernameTxtBx.Text = "";
            passwordTxtBx.Text = "";


            usernameTxtBx.Enabled = true;
            passwordTxtBx.Enabled = true;

            loginBtn.Text = "Login";            
        }

        #endregion
        

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

                                    sqlite_cmd.CommandText = "CREATE TABLE " + id + "(pid varchar(50), pname varchar(50), price float, num int);";
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

            if(retResult == string.Empty || retResult == "" || retResult == null)
            {
                retResult = "Nill";
            }

            return retResult;
        }
        
        private string DiviceHandle(string text,string id)
        {
            string retResult = string.Empty;
            string barcode = string.Empty;       
            string searchKey = string.Empty;

            bool insert = true;

            if(text.Contains("Remove"))
            {
                insert = false;
            }
            

            string[] splitMsg = text.Split('_');

            barcode = splitMsg[1];

            searchKey = barcode.Substring(6, 5);


            logCall(false, "Search From Device");
            logCall(false, "key : " + searchKey);


            ConnectToSql();            
            retResult = SearchSqlForDevice(searchKey, id,insert);
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
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
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
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
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
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
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
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
                }

                

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
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
                }

                ConnectToSql();
                displaySql();
                CloseSqlConnection();

            }
            else //Inserting from the text boxes
            {
                try
                {
                    if (pidTxtBx.Text != "" && pnameTxtBx.Text != "" && catidTxtBx.Text != "" && manidTxtBx.Text != "" && catidTxtBx.Text != "" && brandTxtBx.Text != "" && qtyTxtBx.Text != "" && wtTxtBx.Text != "" && stkTxtBx.Text != "" && priceTxtBx.Text != "")
                    {
                        sqlite_cmd.CommandText = "INSERT INTO " + tname + " VALUES (" + pidTxtBx.Text + ",'" + pnameTxtBx.Text + "'," + catidTxtBx.Text + "," + manidTxtBx.Text + ",'" + brandTxtBx.Text + "'," + qtyTxtBx.Text + "," + wtTxtBx.Text + "," + stkTxtBx.Text + "," + priceTxtBx.Text + ");";                        
                        sqlite_cmd.ExecuteNonQuery();

                        logCall(false, "Inserted");

                        ConnectToSql();
                        displaySql();
                        CloseSqlConnection();

                    }
                    else
                    {
                        logCall(false, "Data Not Complete");
                        MessageBox.Show("Data Not Complete", "Error");
                    }
                }
                catch (Exception ex)
                {
                    logCall(false, "Sql Exception in insertion:");
                    logCall(false, ex.Message); MessageBox.Show(ex.Message,"Exception");
                    MessageBox.Show(ex.Message, "Error In Insertion");
                }
            }

        }        

        public void displaySql()
        {

            logCall(false, "Display");

            using (sqlite_cmd)
            {                
             
                sqlite_cmd.CommandText = "SELECT * FROM Products;";

                sqlite_cmd.CommandTimeout = 30;


                sqlite_cmd.CommandType = CommandType.Text;

                sqlite_datareader = sqlite_cmd.ExecuteReader();
                

                tableGridVw.Rows.Clear();
                
                while (sqlite_datareader.Read()) 
                {
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

        private void SearchSql(bool device, string s)
        {
            bool found = false;

            ConnectToSql();
            using (sqlite_cmd)
            {

                tableGridVw.Rows.Clear();

                logCall(false, "Searching...");
                
                sqlite_cmd.CommandText = "SELECT * FROM Products WHERE pname LIKE '%" + s + "%' OR pname LIKE '%" + s + "%'";

                sqlite_cmd.CommandTimeout = 30;

                sqlite_cmd.CommandType = CommandType.Text;

                sqlite_datareader = sqlite_cmd.ExecuteReader();

                found = false;
                
                while (sqlite_datareader.Read()) 
                {
                    found = true;
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
            }





                sqlite_conn.Close();

                if (found == false)
                {
                    ConnectToSql();
                    using (sqlite_cmd)
                    {

                        tableGridVw.Rows.Clear();

                        logCall(false, "Searching...");
                    
                        sqlite_cmd.CommandText = "SELECT * FROM Products WHERE pid LIKE '%" + s + "%' OR pname LIKE '%" + s + "%'";

                        sqlite_cmd.CommandTimeout = 30;

                        sqlite_cmd.CommandType = CommandType.Text;

                        
                        sqlite_datareader = sqlite_cmd.ExecuteReader();

                        found = false;
                    
                        while (sqlite_datareader.Read()) 
                        {
                            found = true;
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

            if(found == false)
            {
                MessageBox.Show("Not Found");
            }



           
        }

        private string SearchSqlForDevice(string searchKey, string id, bool insert)
        {

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

                int count = 0;
                //Searching wheather exist
                try
                {
                    ConnectToSql();
                    sqlite_cmd.CommandText = "SELECT pid,num FROM " + id + " WHERE pid = " + searchKey + ";";
                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    logCall(false, "In removal/updation, Searching if it exist");

                    searchKey = searchKey.ToLower();

                    while (sqlite_datareader.Read())
                    {
                        count = 0;
                        if (sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pid")).ToString().ToLower().Equals(searchKey))
                        {
                            string num = sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("num")).ToString();
                            count = Int32.Parse(num);                            
                            break;
                        }
                    }
                    logCall(false, "No of Existing Pids = " + count.ToString());
                    CloseSqlConnection();
                }
                catch (SQLiteException ex)
                {
                    logCall(false, "Sql Exception in Removal");
                    logCall(false, ex.Message); 
                }
                catch (Exception ex)
                {
                    logCall(false, "Exception in Removal");
                    logCall(false, ex.Message); 
                }



                if (RetString != string.Empty && insert)
                {
                    //Insertion/Updation into device
                    try
                    {
                        if (count == 0) //Insert
                        {
                            logCall(false, "Inserting");
                            count++;
                            ConnectToSql();
                            sqlite_cmd.CommandText = "INSERT INTO " + id + " VALUES( '" + searchKey + "', '" + pname + "', '" + price + "', " + count.ToString() +");";
                            sqlite_cmd.ExecuteNonQuery();
                            CloseSqlConnection();
                        }
                        else //Update
                        {
                            logCall(false, "Updating");
                            count++;
                            ConnectToSql();
                            sqlite_cmd.CommandText = "UPDATE " + id + " SET num = " + count.ToString() + " WHERE pid = " + searchKey + ";";
                            sqlite_cmd.ExecuteNonQuery();
                            CloseSqlConnection();
                        }
                    }
                    catch (Exception ex)
                    {
                        logCall(false, "Exception in insertion/updation from the device");
                        logCall(false, ex.Message); 
                    }
                }
                else if(RetString != string.Empty && !insert)
                {
                    

                    //Deletion/Updation from device
                    try
                    {
                        ConnectToSql();

                        if (count == 1)
                        {
                            //Delete
                            sqlite_cmd.CommandText = "DELETE FROM " + id + " WHERE pid = " + searchKey + ";";
                            logCall(false, "Deletion acc to device req");
                        }
                        else
                        {
                            //Update
                            count--;
                            sqlite_cmd.CommandText = "UPDATE " + id + " SET num = " + count.ToString()+"WHERE pid = " + searchKey + ";";
                            logCall(false, "Updation acc to device req");
                        }

                        sqlite_cmd.ExecuteNonQuery();                       

                        RetString = "-" + RetString;

                        logCall(false, "Removed/Updated from the " + id + " table");
                        CloseSqlConnection();

                    }
                    catch (Exception ex)
                    {
                        logCall(false, "Exception in Deletion/Updation from the device");
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

        private string deviceDatabaseReturning(string id)
        {
            logCall(false, "In the database return func");

            string retResults = string.Empty;

            using (sqlite_cmd)
            {
                try
                {
                    sqlite_cmd.CommandText = "SELECT * FROM " + id + " ;";
                    sqlite_cmd.CommandTimeout = 30;
                    sqlite_cmd.CommandType = CommandType.Text;

                    sqlite_datareader = sqlite_cmd.ExecuteReader();

                    logCall(false, "Searching");
                    retResults = "";
                    while(sqlite_datareader.Read())
                    {
                        try
                        {
                            retResults += sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pid")).ToString() + "_" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("pname")).ToString() + "_" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("price")).ToString() + "_" + sqlite_datareader.GetValue(sqlite_datareader.GetOrdinal("num")).ToString() + "_";
                        }
                        catch(Exception ex)
                        {
                            logCall(false, "Exception in while in database returning : Not found");
                            logCall(false, ex.Message); 
                        }
                    }

                    retResults = "Device_" + retResults;


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

        private void deleteFromDatabase()
        {
            Int32 selectedCellCount = tableGridVw.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                for (int i = 0; i < tableGridVw.SelectedRows.Count; i++)
                {
                    int rowIndex = tableGridVw.SelectedCells[i].RowIndex;
                    DataGridViewRow row = tableGridVw.Rows[rowIndex];

                    try
                    {
                        sqlite_cmd.CommandText = "DELETE FROM Products WHERE pid = " + row.Cells[0].Value.ToString() + ";";
                        sqlite_cmd.ExecuteNonQuery();

                        logCall(false, "Deleted Selected row");
                    }
                    catch(SQLiteException ex)
                    {
                        logCall(false, "Sql Exception in Deletion");
                        logCall(false, ex.Message); 
                    }
                    catch(Exception ex)
                    {
                        logCall(false, "Exception in Deletion");
                        logCall(false, ex.Message); 
                    }

                }
            }            
        }

        private void editFromDatabase()
        {
            Int32 selectedCellCount = tableGridVw.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (tableGridVw.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {

                    if(tableGridVw.SelectedRows.Count == 1)
                    {

                        InsertBtn.Text = "Edit";

                        //Retrieve the data from the table and set it to the edit textboxes

                        int rowIndex = tableGridVw.SelectedCells[0].RowIndex;

                        DataGridViewRow row = tableGridVw.Rows[rowIndex];

                        //MessageBox.Show(row.Cells[1].Value.ToString());
                          pidTxtBx.Text = row.Cells[0].Value.ToString();
                        pnameTxtBx.Text = row.Cells[1].Value.ToString();
                        catidTxtBx.Text = row.Cells[2].Value.ToString();
                        manidTxtBx.Text = row.Cells[3].Value.ToString();
                        brandTxtBx.Text = row.Cells[4].Value.ToString();
                          qtyTxtBx.Text = row.Cells[5].Value.ToString();
                           wtTxtBx.Text = row.Cells[6].Value.ToString();
                          stkTxtBx.Text = row.Cells[7].Value.ToString();
                        priceTxtBx.Text = row.Cells[8].Value.ToString();



                    }
                    else
                    {
                        MessageBox.Show("Multiple Columns Selected");
                    }
                }
            }
        }

        private void Editing()
        {
            try
            {                
                sqlite_cmd.CommandText = "UPDATE Products SET pid = " + pidTxtBx.Text + ", pname = '" + pnameTxtBx.Text + "', catid = " + catidTxtBx.Text + ", mid = " + manidTxtBx.Text + ",brand = '"+brandTxtBx.Text+"', qty = " + qtyTxtBx.Text + ",wt=" + wtTxtBx.Text + ",stock = " + stkTxtBx.Text + ", price = " + priceTxtBx.Text + " WHERE pid = " + pidTxtBx.Text + ";";
                sqlite_cmd.ExecuteNonQuery();                

                logCall(false, "Database Upddated");

                resettingTextBx();
                InsertBtn.Text = "Insert";

            }
            catch (Exception ex)
            {
                logCall(false, "Sql Exception in Editting : ");
                logCall(false, ex.Message); 
            }

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

        private void resettingTextBx()
        {
            pidTxtBx.Text = "";
            pnameTxtBx.Text = "";
            catidTxtBx.Text = "";
            manidTxtBx.Text = "";
            brandTxtBx.Text = "";
            qtyTxtBx.Text = "";
            wtTxtBx.Text = "";
            stkTxtBx.Text = "";
            priceTxtBx.Text = "";

            hideLabel();
        }

        private void visibleLabel()
        {
            pidLbl.Visible = pnameLbl.Visible = catidLbl.Visible = manidLbl.Visible = brandLbl.Visible = qtyLbl.Visible = qtyLbl.Visible = wtLbl.Visible = stkLbl.Visible = priceLbl.Visible =  true;           
        }

        private void hideLabel()
        {
            pidLbl.Visible = pnameLbl.Visible = catidLbl.Visible = manidLbl.Visible = brandLbl.Visible = qtyLbl.Visible = qtyLbl.Visible = wtLbl.Visible = stkLbl.Visible = priceLbl.Visible = false;           
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

            if (InsertBtn.Text == "Insert")
                Insertion("Products", false);
            else if (InsertBtn.Text == "Edit")
            {
                Editing();
                hideLabel();
            }
            CloseSqlConnection();

            /*
            ConnectToSql();
            displaySql();
            CloseSqlConnection();
            */
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

        private void searchTxtBx_Leave(object sender, EventArgs e)
        {
            searchTxtBx.Text = "";
        }

        private void searchPic_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            string s = searchTxtBx.Text;
            SearchSql(false,s);
            CloseSqlConnection();
        }

        private void searchTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConnectToSql();
                string s = searchTxtBx.Text;
                SearchSql(false, s);
                CloseSqlConnection();
            }
            else if(e.KeyCode == Keys.Escape)
            {
                label1.Focus();
            }
        }

        private void searchTxtBx_Click(object sender, EventArgs e)
        {
            //searchTxtBx.Text = "";
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            resettingTextBx();
            InsertBtn.Text = "Insert";
        }        

        private void editPic_Click(object sender, EventArgs e)
        {
            visibleLabel();
            ConnectToSql();
            editFromDatabase();
            CloseSqlConnection();            
        }

        private void delPic_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            deleteFromDatabase();
            CloseSqlConnection();

            ConnectToSql();
            displaySql();
            CloseSqlConnection();

        }       

        private void InsertPresetBtn_Click(object sender, EventArgs e)
        {
            ConnectToSql();
            Insertion("Products", true);
            CloseSqlConnection();
        }


        #endregion

        #region UI - Material

        private void MakeNewmericKeypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void pidTxtBx_Enter(object sender, EventArgs e)
        {
            pidLbl.Visible = true;
        }

        private void pidTxtBx_Leave(object sender, EventArgs e)
        {
            if (pidTxtBx.Text == "")
            {
                pidLbl.Visible = false;
            }
            else
            {
                pidLbl.Visible = true;
            }
        }

        private void pnameTxtBx_Enter(object sender, EventArgs e)
        {
            pnameLbl.Visible = true;
        }

        private void pnameTxtBx_Leave(object sender, EventArgs e)
        {
            if (pnameTxtBx.Text == "")
            {
                pnameLbl.Visible = false;
            }
            else
            {
                pnameLbl.Visible = true;
            }

        }

        private void catidTxtBx_Enter(object sender, EventArgs e)
        {
            catidLbl.Visible = true;
        }

        private void catidTxtBx_Leave(object sender, EventArgs e)
        {
            if (catidTxtBx.Text == "")
            {
                catidLbl.Visible = false;
            }
            else
            {
                catidLbl.Visible = true;
            }
        }

        private void manidTxtBx_Enter(object sender, EventArgs e)
        {
            manidLbl.Visible = true;
        }

        private void manidTxtBx_Leave(object sender, EventArgs e)
        {
            if (manidTxtBx.Text == "")
            {
                manidLbl.Visible = false;
            }
            else
            {
                manidLbl.Visible = true;
            }
        }

        private void brandTxtBx_Enter(object sender, EventArgs e)
        {
            brandLbl.Visible = true;
        }

        private void brandTxtBx_Leave(object sender, EventArgs e)
        {
            if (brandTxtBx.Text == "")
            {
                brandLbl.Visible = false;
            }
            else
            {
                brandLbl.Visible = true;
            }
        }

        private void qtyTxtBx_Enter(object sender, EventArgs e)
        {
            qtyLbl.Visible = true;
        }

        private void qtyTxtBx_Leave(object sender, EventArgs e)
        {
            if (qtyTxtBx.Text == "")
            {
                qtyLbl.Visible = false;
            }
            else
            {
                qtyLbl.Visible = true;
            }
        }

        private void wtTxtBx_Enter(object sender, EventArgs e)
        {
            wtLbl.Visible = true;
        }

        private void wtTxtBx_Leave(object sender, EventArgs e)
        {
            if (wtTxtBx.Text == "")
            {
                wtLbl.Visible = false;
            }
            else
            {
                wtTxtBx.Visible = true;
            }
        }

        private void stkTxtBx_Enter(object sender, EventArgs e)
        {
            stkLbl.Visible = true;
        }

        private void stkTxtBx_Leave(object sender, EventArgs e)
        {
            if (stkTxtBx.Text == "")
            {
                stkLbl.Visible = false;
            }
            else
            {
                stkLbl.Visible = true;
            }
        }

        private void priceTxtBx_Enter(object sender, EventArgs e)
        {
            priceLbl.Visible = true;
        }

        private void priceTxtBx_Leave(object sender, EventArgs e)
        {
            if (priceTxtBx.Text == "")
            {
                priceLbl.Visible = false;
            }
            else
            {
                priceLbl.Visible = true;
            }
        }

        #endregion

        #region Login Events
        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (loginBtn.Text == "Login")
            {
                ConnectToSql();
                login();
                CloseSqlConnection();
            }
            else if(loginBtn.Text == "LogOut")
            {
                logout();
            }
        }


        private void passwordTxtBx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConnectToSql();
                login();
                CloseSqlConnection();
            }
        }







        #endregion

        #endregion

       
    }
}
