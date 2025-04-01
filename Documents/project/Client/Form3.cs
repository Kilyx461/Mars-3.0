using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using ModelsLibrary;
namespace Client
{
    public partial class Form3 : Form
    {
        

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || // Исправлено: textBox1
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                            type = "Register",
                            message = textBox2.Text, // Исправлено: textBox1
                            login = textBox1.Text,
                            password = textBox4.Text
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

                        // Десериализуем ответ с защитой от ошибок
                        try
                        {
                            MyRequest serverMessage = (MyRequest)bf.Deserialize(ns);

                            // Обрабатываем ответ от сервера
                            if (serverMessage.type == "RegisterSuccess")
                            {
                                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Переход на следующую форму
                                Form2 loginForm = new Form2();
                                loginForm.Show();
                                this.Hide();
                            }
                            else if (serverMessage.type == "RegisterFailed")
                            {
                                MessageBox.Show("Registration failed: " + serverMessage.message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Unexpected response: {serverMessage.message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        catch (Exception deserializationEx)
                        {
                            MessageBox.Show($"Error processing server response: {deserializationEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
