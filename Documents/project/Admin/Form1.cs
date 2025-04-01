using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelsLibrary;
using System.Runtime.Serialization.Formatters.Binary;

namespace Admin
{
    public partial class Form1: Form
    {
         TcpClient client;
         BinaryFormatter bf1 = new BinaryFormatter();
         string Reports = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnBan_Click(object sender, EventArgs e)
        {
            if (Test2.SelectedItem != null)
            {

                string selectedUser = Test2.SelectedItem.ToString();
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                    NetworkStream ns = client.GetStream();
                    MyRequest request = new MyRequest { type = "BanUser", login = selectedUser };
                    bf1.Serialize(ns, request);
                    ns.Flush();

                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    ns.Close();
                    client.Close();

                    MessageBox.Show($"Пользователь {selectedUser} заблокирован.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
                }
            }
        }

        private void BtnIgnore_Click(object sender, EventArgs e)
        {
            RepBox.Text = null;
            RepBox.Hide();

            BtnBan2.Hide();
            BtnIgnore.Hide();

            string selectedUser = Test2.SelectedItem.ToString();
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest request = new MyRequest { type = "IgnoreRep", login = RepBox.Text.Split(':')[0] };
                bf1.Serialize(ns, request);
                ns.Flush();

                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }

                ns.Close();
                client.Close();

                MessageBox.Show($"Пользователь {selectedUser} заблокирован.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
            }


        }

        private void btnBanReport(object sender, EventArgs e)
        {
            if (Test2.SelectedItem == null) return;

            string selectedUser = Test2.SelectedItem.ToString();
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest request = new MyRequest { type = "BanUser", login = selectedUser };
                bf1.Serialize(ns, request);
                ns.Flush();

                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }

                ns.Close();
                client.Close();

                MessageBox.Show($"Пользователь {selectedUser} заблокирован.");

                BtnBan2.Hide();
                BtnIgnore.Hide();
                RepBox.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
            }
        }

        private void SearchButton(object sender, EventArgs e)
        {
           

            string selectedUser = SearchUser.Text;
            try
            {
                Test2.Items.Clear();

                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest request = new MyRequest { type = "SearchUser", login = selectedUser };
                bf1.Serialize(ns, request);
                ns.Flush();

                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }

                MyRequest ServerMess = (MyRequest)bf1.Deserialize(ns);
                if (ServerMess.message == "Not Found")
                {
                    MessageBox.Show("Не найдено");
                }
                else
                {
                    Test2.Items.Add(ServerMess.message);
                }


                ns.Close();
                client.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка нахождения пользователя: " + ex.Message);
            }
        }

        private void ListBox(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
          if(RepBox.Text == null)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                    NetworkStream ns = client.GetStream();
                    MyRequest request = new MyRequest { type = "GetReports" };
                    bf1.Serialize(ns, request);
                    ns.Flush();

                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                    if (serverMessage.message != null)
                    {
                        RepBox.Show();
                        BtnBan2.Show();
                        BtnIgnore.Show();

                        Reports = serverMessage.message;

                        var result = Reports.Split('/')[0];
                        RepBox.Text = result;

                        ns.Close();
                        client.Close();

                        MessageBox.Show($"Пользователь  заблокирован.");
                    }
                    else
                    {
                        Console.WriteLine("No reportes");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
                }
            }
            
           
        }



        private void BtnIgnore3_Click(object sender, EventArgs e)
        {
            RepBox3.Text = null;
            RepBox3.Hide();

            BtnBan4.Hide();
            BtnIgnore3.Hide();
        }

        private void BtnIgnore2_Click(object sender, EventArgs e)
        {
            RepBox2.Text = null;
            RepBox2.Hide();

            BtnBan3.Hide();
            BtnIgnore2.Hide();
        }

        private void BtnBan4_Click(object sender, EventArgs e)
        {
            if (Test2.SelectedItem == null) return;

            string selectedUser = Test2.SelectedItem.ToString();
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest request = new MyRequest { type = "BanUser", login = selectedUser };
                bf1.Serialize(ns, request);
                ns.Flush();

                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }

                ns.Close();
                client.Close();

                MessageBox.Show($"Пользователь {selectedUser} заблокирован.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
            }
        }

        private void BtnBan3_Click(object sender, EventArgs e)
        {
            if (Test2.SelectedItem == null) return;

            string selectedUser = Test2.SelectedItem.ToString();
            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest request = new MyRequest { type = "BanUser", login = selectedUser };
                bf1.Serialize(ns, request);
                ns.Flush();

                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }

                ns.Close();
                client.Close();

                MessageBox.Show($"Пользователь {selectedUser} заблокирован.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка блокировки пользователя: " + ex.Message);
            }
        }
    }
}
