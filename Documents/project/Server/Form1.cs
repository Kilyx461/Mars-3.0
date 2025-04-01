using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using ModelsLibrary;

namespace Server
{
    public partial class Form1: Form
    {
        MyRequest clientMessage = null;
        MyRequest serverMessage = null;
        TcpListener server = null;
        BinaryFormatter bf1 = new BinaryFormatter();

        public Form1()
        {
            
            InitializeComponent();
        }

        private async void Server()
        {
            serverMessage = new MyRequest();
            try
            {


                server = new TcpListener(IPAddress.Parse(IPField.Text), int.Parse(PortField.Text));
                server.Start(10);
                Console.WriteLine("Server Started!");

                while (true)
                {

                    TcpClient acceptor = server.AcceptTcpClient();
                    NetworkStream ns = acceptor.GetStream();
                    ns.Flush();
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    Console.WriteLine("deserialize server");
                    clientMessage = (MyRequest)bf1.Deserialize(ns);
                    Console.WriteLine("after deserialize server");

                    if (clientMessage.type == "CheckLogin")
                    {
                        using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                        {
                            if (db.QueryFirstOrDefault<int?>($"select Access from Users where loginU = '{clientMessage.login.Replace(" ", "")}'") == 0)
                            {
                                serverMessage.type = "LoginFailed";
                                serverMessage.message = $"Banned!";

                            }
                            else
                            {
                                clientMessage.login = clientMessage.login.Replace(" ", "");
                                clientMessage.password = clientMessage.password.Replace(" ", "");


                                int? response = db.QueryFirstOrDefault<int?>($"SELECT Id FROM Users WHERE loginU = '{clientMessage.login.Replace(" ", "")}' and PasswordU = '{clientMessage.password.Replace(" ", "")}'");
                                string Username = db.QueryFirstOrDefault<string>($"SELECT UserName FROM Users WHERE loginU = '{clientMessage.login.Replace(" ", "")}' and PasswordU = '{clientMessage.password.Replace(" ", "")}'");


                                Console.WriteLine(clientMessage.login.Replace(" ", "") + " " + clientMessage.password.Replace(" ", "") + " " + Username);

                                if (response != null)
                                {




                                    serverMessage.type = "LoginSuccess";
                                    serverMessage.login = clientMessage.login.Replace(" ", "");
                                    serverMessage.password = clientMessage.password.Replace(" ", "");
                                    serverMessage.message = Username;









                                }
                                else
                                {
                                    serverMessage.type = "LoginFailed";
                                    serverMessage.message = $"Failed";
                                }
                            }
                            ns.Flush();


                        }
                    }
                    else
                    {
                        if (clientMessage.type == "GetChat")
                        {
                            using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                            {



                                Console.WriteLine(clientMessage.login+"------------------------");
                                int? userId1 = db.QueryFirstOrDefault<int?>("SELECT Id FROM Users WHERE loginU = @login",
                                new { login = clientMessage.login.Replace(" ", "") });

                                Console.WriteLine($"user1id = {userId1}");

                                int? userId2 = db.QueryFirstOrDefault<int?>("SELECT Id FROM Users WHERE UserName = @login",
                                new { login = clientMessage.message.Replace(" ", "") });
                                Console.WriteLine($"user2id = {userId2}");

                                if (userId1 == null ||userId2 == null)
                                {
                                    Console.WriteLine("User not found! Message not saved.");
                                    serverMessage.message = "";
                                    return;

                                }

                                string oldMessages = db.QueryFirstOrDefault<string>(
                                "SELECT MessagesU FROM Chat WHERE (User1Id = @user1id OR User2Id = @user1id) and  (User1Id = @user2id OR User2Id = @user2id) ",
                                new { user1id =  userId1, user2id = userId2  });

                                serverMessage = new MyRequest();
                                serverMessage.type = "Chat-response";
                                serverMessage.message = oldMessages;
                                ns.Flush();

                                Console.WriteLine("Serialized server");


                            }

                        }
                        else
                        {
                            if (clientMessage.type == "SendMessage")
                            {


                                using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                {
                                    if (clientMessage.message.ToLower().Contains("hitler") || clientMessage.message.ToLower().Contains("holocost") || clientMessage.message.ToLower().Contains("kill the president") || clientMessage.message.ToLower().Contains("kill children"))
                                    {
                                        db.Execute($"insert into Reports(Message,UserId) values ({clientMessage.message}, (SELECT Id FROM Users WHERE loginU = {clientMessage.login.Replace(" ", "")}))");
                                    }
                                    Console.WriteLine(clientMessage.login);
                                    int? userId = db.QueryFirstOrDefault<int?>("SELECT Id FROM Users WHERE UserName = @login",
                                    new { login = clientMessage.login.Replace(" ", "") });

                                    int? userId2 = db.QueryFirstOrDefault<int?>("SELECT Id FROM Users WHERE UserName = @login",
                                    new { login = clientMessage.password.Replace(" ", "") });

                                    /*
                                    string username = db.QueryFirstOrDefault<string>("SELECT UserName FROM Users WHERE loginU = @login",
                                    new { login = clientMessage.login.Replace(" ", "") });
                                    */

                                    if (userId == null || userId2 == null)
                                    {
                                        Console.WriteLine("User not found! Message not saved.");

                                    }


                                    string oldMessages = db.QueryFirstOrDefault<string>(
                                    "SELECT MessagesU FROM Chat WHERE User1Id = @user1id OR User2Id = @user1id and  User1Id = @user2id OR User2Id = @user2id ",
                                    new { user1id = userId, user2id = userId2 });

                                    if (oldMessages == null) oldMessages = "";

                                    string newMessage = $"\r\n{DateTime.Now:HH:mm}\r\n{clientMessage.password}:\r\n{clientMessage.message}";


                                    int rowsAffected = db.Execute(
                                        "UPDATE Chat SET MessagesU = @newMessages WHERE User1Id = @userid OR User2Id = @userid and User1Id = @user2id OR User2Id = @user2id ",
                                        new { newMessages = oldMessages + "\n" + newMessage,userid = userId, user2id = userId2 });

                                    if (rowsAffected > 0)
                                    {
                                        Console.WriteLine("Message successfully saved!");
                                        serverMessage.message = oldMessages + "\n" + newMessage;
                                        serverMessage.type = "Chat-response";
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to update chat. No rows affected.");
                                    }



                                }


                            }
                            else
                            {
                                if (clientMessage.type == "GetContacts")
                                {
                                    using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                    {



                                        Console.WriteLine(clientMessage.login);
                                        string UserContacts = db.QueryFirstOrDefault<string>("SELECT Contacts FROM Users WHERE loginU = @login",
                                        new { login = clientMessage.login.Replace(" ", "") });

                                        if (UserContacts == null)
                                        {
                                            Console.WriteLine("User not found! Contacts not found.");

                                        }



                                        serverMessage = new MyRequest();
                                        serverMessage.type = "Contacts-response";
                                        serverMessage.message = UserContacts;
                                        Console.WriteLine(UserContacts);

                                        ns.Flush();




                                    }

                                }
                                else
                                {
                                    if (clientMessage.type == "GetReports")
                                    {
                                        using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                        {



                                            Console.WriteLine(clientMessage.login);
                                            string Reports = db.QueryFirstOrDefault<string>("SELECT Reports FROM Reports");

                                            if (Reports == null)
                                            {
                                                Console.WriteLine("User not found! Contacts not found.");

                                            }
                                            var splitted = Reports.Split('/');
                                            var Result = splitted[0] + "/" + splitted[1] + "/" + splitted[2] + "/" + splitted[3] + "/" + splitted[4];



                                            serverMessage = new MyRequest();
                                            serverMessage.type = "Reports-response";
                                            serverMessage.message = Result;

                                            ns.Flush();




                                        }

                                    }
                                    else
                                    {
                                        if (clientMessage.type == "Register")
                                        {
                                            using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                            {
                                                try
                                                {
                                                    var UserContacts = db.Execute($"insert into Users (LoginU,PasswordU,Username)  values ('{clientMessage.login}','{clientMessage.password}','{clientMessage.message}')");

                                                    serverMessage = new MyRequest();
                                                    serverMessage.type = "RegisterSuccess";
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine(ex.Message);
                                                    serverMessage.type = "RegisterFailed";
                                                    serverMessage.message = "Reg ERROR!";
                                                }



                                                ns.Flush();




                                            }

                                        }
                                        else
                                        {
                                            if (clientMessage.type == "AddContact")
                                            {
                                                using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                {


                                                    string oldContacts = db.QueryFirstOrDefault<string>($"SELECT Contacts FROM Users WHERE UserName = '{clientMessage.message.Replace(" ", "")}'");
                                                    Console.WriteLine(clientMessage.message.Replace(" ", "") + "OOOOOLD");

                                                    int rowsAffected2 = db.Execute($"insert into Chat (User1Id, User2Id) values ((select Id from Users where UserName = '{clientMessage.login.Replace(" ", "")}'),(select Id from Users where UserName = '{clientMessage.message.Replace(" ", "")}'))");

                                                    if (rowsAffected2 > 0)
                                                    {


                                                        int rowsAffected = db.Execute($"UPDATE Users SET Contacts = '{oldContacts + $"{clientMessage.login.Replace(" ", "")}/"}' where UserName = '{clientMessage.message.Replace(" ", "")}'");
                                                        int rowsAffected3 = db.Execute($"UPDATE Users SET Contacts = '{oldContacts + $"{clientMessage.message.Replace(" ", "")}/"}' where UserName = '{clientMessage.login.Replace(" ", "")}'");










                                                        if (rowsAffected > 0)
                                                        {
                                                            Console.WriteLine("Message successfully saved!");
                                                            serverMessage.message = oldContacts + $"{clientMessage.login.Replace(" ", "")}/";
                                                            serverMessage.type = "Contact-Success";
                                                        }
                                                        else
                                                        {
                                                            serverMessage.type = "Contact-Failed";
                                                            Console.WriteLine("Failed to update contacts. No rows affected.");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        serverMessage.type = "Contact-Failed";
                                                        Console.WriteLine("Failed to update chat. No rows affected.");
                                                    }









                                                }




                                            }
                                            else
                                            {
                                                if (clientMessage.type == "DeleteContact")
                                                {
                                                    using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                    {



                                                        Console.WriteLine(clientMessage.login);
                                                        string UserContacts = db.QueryFirstOrDefault<string>("SELECT Contacts FROM Users WHERE loginU = @login",
                                                        new { login = clientMessage.login.Replace(" ", "") });

                                                        if (UserContacts == null)
                                                        {
                                                            Console.WriteLine("User not found! Contacts not found.");

                                                        }
                                                        var result = UserContacts.Split('/');
                                                        string newresult = "";
                                                        foreach (var contact in result)
                                                        {
                                                            if (contact != " " && contact != clientMessage.message)
                                                            {
                                                                newresult += contact + "/";
                                                            }
                                                        }

                                                        int rows = db.Execute("update Users set Contacts = @contact where loginU = @login",
                                                        new { login = clientMessage.login.Replace(" ", ""), contact = newresult });



                                                        serverMessage = new MyRequest();
                                                        serverMessage.type = "Contacts-response";
                                                        serverMessage.message = "Success";
                                                        Console.WriteLine(UserContacts);

                                                        ns.Flush();




                                                    }

                                                }
                                                else
                                                {
                                                    if (clientMessage.type == "AddToBlacklist")
                                                    {
                                                        using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                        {


                                                            string oldContacts = db.QueryFirstOrDefault<string>($"SELECT BlackList FROM Users WHERE UserName = '{clientMessage.message.Replace(" ", "")}'");
                                                            Console.WriteLine(clientMessage.message.Replace(" ", "") + "OOOOOLD");






                                                            int rowsAffected = db.Execute($"UPDATE Users SET Contacts = '{oldContacts + $"{clientMessage.login.Replace(" ", "")}/"}' where UserName = '{clientMessage.message.Replace(" ", "")}'");











                                                            if (rowsAffected > 0)
                                                            {
                                                                Console.WriteLine("Message successfully saved!");
                                                                serverMessage.message = oldContacts + $"{clientMessage.login.Replace(" ", "")}/";
                                                                serverMessage.type = "Contact-Success";
                                                            }
                                                            else
                                                            {
                                                                serverMessage.type = "Contact-Failed";
                                                                Console.WriteLine("Failed to update contacts. No rows affected.");
                                                            }


                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (clientMessage.type == "GetBlackList")
                                                        {
                                                            using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                            {



                                                                Console.WriteLine(clientMessage.login);
                                                                string UserContacts = db.QueryFirstOrDefault<string>("SELECT BlackList FROM Users WHERE loginU = @login",
                                                                new { login = clientMessage.login.Replace(" ", "") });

                                                                if (UserContacts == null)
                                                                {
                                                                    Console.WriteLine("User not found! Contacts not found.");

                                                                }



                                                                serverMessage = new MyRequest();
                                                                serverMessage.type = "BlackList-response";
                                                                serverMessage.message = UserContacts;
                                                                Console.WriteLine(UserContacts);

                                                                ns.Flush();




                                                            }

                                                        }
                                                        else
                                                        {
                                                            if (clientMessage.type == "SearchUser")
                                                            {
                                                                using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                                {




                                                                    string UserContacts = db.QueryFirstOrDefault<string>("SELECT loginU FROM Users WHERE loginU = @login",
                                                                    new { login = clientMessage.login.Replace(" ", "") });

                                                                    if (UserContacts == null)
                                                                    {
                                                                        Console.WriteLine("User not found! Contacts not found.");

                                                                    }



                                                                    serverMessage = new MyRequest();
                                                                    serverMessage.type = "Search-response";
                                                                    serverMessage.message = UserContacts;
                                                                    Console.WriteLine(UserContacts);

                                                                    ns.Flush();




                                                                }

                                                            }
                                                            else
                                                            {
                                                                if (clientMessage.type == "BanUser")
                                                                {
                                                                    using (var db = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=Users"))
                                                                    {




                                                                        int UserContacts = db.Execute("update Users set Access = 0 where loginU = @login",
                                                                        new { login = clientMessage.login.Replace(" ", "") });

                                                                        if (UserContacts == null)
                                                                        {
                                                                            Console.WriteLine("User not found! Contacts not found.");

                                                                        }



                                                                        serverMessage = new MyRequest();
                                                                        serverMessage.type = "Ban-response";
                                                                        
                                                                        Console.WriteLine(UserContacts);

                                                                        ns.Flush();




                                                                    }

                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                        }
                                    }

                                }

                            }
                        }
                    }













                    Console.WriteLine("server serialize");
                    bf1.Serialize(ns, serverMessage);
                    Console.WriteLine("after server serialize");
                    ns.Close();
                    acceptor.Close();


                }
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine($"\n>server socket error! :{sockEx}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"\n> runtime error! :{Ex}");
            }
            finally
            {
                if (server != null)
                {
                    server.Stop();

                }
                Console.WriteLine("Server Stopped!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Thread serv = new Thread(Server);
                serv.IsBackground = true;
                serv.Start();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка запуску серверного потоку", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
