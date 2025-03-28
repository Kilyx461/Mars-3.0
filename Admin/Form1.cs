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
        private TcpClient client;
        private BinaryFormatter bf1 = new BinaryFormatter();
        private List<string> users = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnBan_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (Test2.SelectedItem == null) return;

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
                if(ServerMess.message == "Not Found")
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
    }
}
