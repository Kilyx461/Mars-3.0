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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Client
{
    public partial class Form2 : Form
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {


            try
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please fill in both fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Получаем логин из текстового поля
                string enteredLogin = textBox1.Text;
                string enteredPassword = textBox2.Text;

                // Настраиваем подключение к серверу
                using (TcpClient client = new TcpClient("127.0.0.1", 9090)) // Укажите IP и порт сервера
                {
                    NetworkStream ns = client.GetStream();

                    // Создаем запрос
                    MyRequest clientMessage = new MyRequest
                    {
                        type = "CheckLogin", // Указываем тип запроса
                        login = enteredLogin, // Передаем логин
                        password = enteredPassword
                    };

                    // Сериализуем запрос

                    Console.WriteLine("client serialize");
                    bf.Serialize(ns, clientMessage);
                    Console.WriteLine("after client serialize");
                    ns.Flush();
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    // Получаем ответ от сервера
                    MyRequest serverMessage = (MyRequest)bf.Deserialize(ns);

                    // Обрабатываем ответ
                    if (serverMessage.type == "LoginSuccess")
                    {
                        Users.loginU = serverMessage.login;
                        Users.UserName = serverMessage.message;
                        Users.PasswordU = serverMessage.password;

                        Form1 telegramForm = new Form1();
                        telegramForm.Show(); // Открываем форму Телеграма
                        this.Hide(); // Скрываем текущую форму
                    }
                    else if (serverMessage.type == "LoginFailed")
                    {
                        MessageBox.Show("Неправильный логин! Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный ответ от сервера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // password ///
        }
    }
 }

