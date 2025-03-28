using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using ModelsLibrary;

namespace Client
{
   
    public partial class Form1: Form
    {
     
        string login = "";
        string passw = "";
        BinaryFormatter bf1 = new BinaryFormatter();

        string clientMessage = "";
        string serverMessage = "";
        TcpClient client = null;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ваш код инициализации формы, если требуется
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string test = listBox1.SelectedItem.ToString();
            try
            {

                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);


                    NetworkStream ns = client.GetStream();
                    MyRequest clientMassage = new MyRequest();
                    clientMassage.type = "GetChat";
                    clientMassage.login = test;
                    bf1.Serialize(ns, clientMassage);
                    MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                    ChatBox.Text = serverMessage.message;


                    ns.Close();
                    client.Close();
            }
            catch (SocketException sockEx)
            {
                Console.WriteLine($"\n> Client socket error! :{sockEx}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"\n> runtime error! :{Ex}");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }

                Console.WriteLine("Stopped connection!");
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {

                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);


                NetworkStream ns = client.GetStream();
                MyRequest clientMassage = new MyRequest();
                clientMassage.type = "SendMessage";
                clientMassage.message = textBox1.Text;
                clientMassage.login = listBox1.SelectedItem.ToString();
                bf1.Serialize(ns, clientMassage);
                MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                ChatBox.Text = serverMessage.message;
                


                ns.Close();
                client.Close();



            }
            catch (SocketException sockEx)
            {
                Console.WriteLine($"\n> Client socket error! :{sockEx}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"\n> runtime error! :{Ex}");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }

                Console.WriteLine("Stopped connection!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string test = listBox1.SelectedItem.ToString();
            try
            {

                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);


                NetworkStream ns = client.GetStream();
                MyRequest clientMassage = new MyRequest();
                clientMassage.type = "GetChat";
                clientMassage.login = test;
                bf1.Serialize(ns, clientMassage);
                
                MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                ChatBox.Text = serverMessage.message;


                ns.Close();
                client.Close();


            }
            catch (SocketException sockEx)
            {
                Console.WriteLine($"\n> Client socket error! :{sockEx}");
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"\n> runtime error! :{Ex}");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }

                Console.WriteLine("Stopped connection!");
            }
        }
    }
}

