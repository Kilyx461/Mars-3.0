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

namespace Client
{
    public partial class Form2 : Form
    {
        [Serializable] // Обязательно для сериализации
        public class MyRequest
        {
            public string type { get; set; }  // Тип запроса, например "CheckLogin", "GetChat" и т.д.
            public string login { get; set; } // Логин пользователя
            public string message { get; set; } // Дополнительные данные, например сообщение
            public string password { get; set; } // Пароль
        }
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
                string enteredPassword = textBox1.Text;

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
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(ns, clientMessage);
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
                            Form2 telegramForm = new Form2();
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
           // Где passwordTextBox - поле для ввода пароля
            string login = textBox1.Text; // loginTextBox - поле для ввода логина

            // Отправляем запрос на сервер
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 9090); // IP и порт сервера
                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();

                // Формируем запрос
                MyRequest loginRequest = new MyRequest
                {
                    type = "Password",
                    login = login,
                    
                };

                // Отправляем данные на сервер
                bf.Serialize(ns, loginRequest);

                // Получаем ответ от сервера
                MyRequest serverResponse = (MyRequest)bf.Deserialize(ns);

                // Проверяем результат
                if (serverResponse.type == "Success")
                {
                    MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 telegramForm = new Form1(); // Загружаем форму телеграма
                    telegramForm.Show();
                    this.Hide(); // Скрываем текущую форму
                }
                else
                {
                    MessageBox.Show("Неправильный пароль! Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ns.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordButton_Click(object sender, EventArgs e)
        {
            string enteredPassword = textBox1.Text; // Где passwordTextBox - поле для ввода пароля
            string login = textBox1.Text; // loginTextBox - поле для ввода логина

            // Отправляем запрос на сервер
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 9090); // IP и порт сервера
                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();

                // Формируем запрос
                MyRequest loginRequest = new MyRequest
                {
                    type = "Password",
                    login = login,
                    password = enteredPassword
                };

                // Отправляем данные на сервер
                bf.Serialize(ns, loginRequest);

                // Получаем ответ от сервера
                MyRequest serverResponse = (MyRequest)bf.Deserialize(ns);

                // Проверяем результат
                if (serverResponse.type == "Success")
                {
                    MessageBox.Show("Успешный вход!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 telegramForm = new Form1(); // Загружаем форму телеграма
                    telegramForm.Show();
                    this.Hide(); // Скрываем текущую форму
                }
                else
                {
                    MessageBox.Show("Неправильный пароль! Попробуйте снова.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ns.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

