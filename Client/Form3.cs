using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Client
{
    public partial class Form3 : Form
    {
        [Serializable]
        public class MyRequest
        {
            public string type { get; set; }
            public string login { get; set; }
            public string password { get; set; }
            public string message { get; set; }
        }

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли логин и пароль
            if (string.IsNullOrWhiteSpace(textLogin.Text) || string.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please fill in both fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (TcpClient client = new TcpClient())
                {
                    // Подключаемся к серверу
                    client.Connect("127.0.0.1", 9090);

                    using (NetworkStream ns = client.GetStream())
                    {
                        // Создаем запрос
                        MyRequest clientMessage = new MyRequest
                        {
                            type = "CheckLogin",
                            login = textLogin.Text,
                            password = textPassword.Text
                        };

                        // Сериализуем и отправляем запрос
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ns, clientMessage);
                        ns.Flush();

                        // Ждем ответа от сервера
                        while (!ns.DataAvailable)
                        {
                            System.Threading.Thread.Sleep(50);
                        }

                        // Десериализуем ответ
                        MyRequest serverMessage = (MyRequest)bf.Deserialize(ns);

                        // Обрабатываем ответ от сервера
                        if (serverMessage.type == "LoginSuccess")
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Переход на следующую форму
                            Form2 loginForm = new Form2();
                            loginForm.Show();
                            this.Hide();
                        }
                        else if (serverMessage.type == "LoginFailed")
                        {
                            MessageBox.Show("Invalid login or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Unexpected response: {serverMessage.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Переход на форму входа
            Form2 loginForm = new Form2();
            loginForm.Show();
            this.Hide();
        }
    }
}
