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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ModelsLibrary;

namespace Client
{

    public partial class Form1 : Form
    {


        public static string StoredUsername { get; set; }
        public static string StoredLogin { get; set; }
        public static string StoredPassword { get; set; }

        bool sidebarExpend;
        bool homeCollapse;

        bool loginVisible = false;
        bool passwordVisible = false;

        private string storedLogin = "default_login"; // Здесь будет сохраненный логин
        private string storedPassword = "default_password"; // Здесь будет сохраненный пароль


       
        private bool showingBlackList = false; // Флаг для отслеживания текущего режима



        

        string login = null;
        string passw = null;
        string Username = null;
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
            login = Users.loginU;
            passw = Users.PasswordU;
            Username = Users.UserName;
            










        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginVisible = !loginVisible;
            if (loginVisible)
            {

                loginButton.Text = $"Login:*****";
            }
            else
            {
                loginButton.Text = $"Login:{login}";
            }
        }

        private void passwordButton_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;
            if (passwordVisible)
            {

                passwordButton.Text = $"Password:*****";
            }
            else
            {
                passwordButton.Text = $"Password:{passw}";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBoxContacts.SelectedItem != null)
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                    NetworkStream ns = client.GetStream();
                    MyRequest clientMassage = new MyRequest();
                    clientMassage.type = "GetChat";
                    clientMassage.login = login;
                    clientMassage.message = listBoxContacts.SelectedItem.ToString();

                    bf1.Serialize(ns, clientMassage);
                    ns.Flush();
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }
                    MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                    ChatBox.Text = serverMessage.message;

                    ns.Close();
                    client.Close();
                }
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
                clientMassage.login = listBoxContacts.SelectedItem.ToString();
                clientMassage.password = Username;
                bf1.Serialize(ns, clientMassage);
                ns.Flush();
                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (listBoxContacts.SelectedItem != null && listBoxContacts.SelectedItem.ToString() != " ")
            {
                
                string test = listBoxContacts.SelectedItem.ToString();
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                    NetworkStream ns = client.GetStream();
                    MyRequest clientMassage = new MyRequest();
                    clientMassage.type = "GetChat";
                    clientMassage.login = login;
                    clientMassage.message = test;
                    bf1.Serialize(ns, clientMassage);
                    ns.Flush();
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }

                    MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);
                    ChatBox.Clear();
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
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedItem != null) // Проверка, выбран ли элемент
            {
                string selectedContact = listBoxContacts.SelectedItem.ToString();

                // Открытие окна редактирования
                EditContactForm editForm = new EditContactForm(selectedContact);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    // Обновление выбранного элемента
                    int selectedIndex = listBoxContacts.SelectedIndex;
                    listBoxContacts.Items[selectedIndex] = editForm.UpdatedContact;
                }
            }
            else
            {
                MessageBox.Show("Выберите контакт для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedItem != null)
            {
                string contact = listBoxContacts.SelectedItem.ToString();
                DialogResult result = MessageBox.Show($"Добавить {contact} в черный список?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show($"{contact} добавлен в черный список.");
                    // Здесь можно добавить код для реального добавления в БД или список
                }
            }
            else
            {
                MessageBox.Show("Выберите контакт.");
            }
        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            // set timer interval  to lowest  to make it smoother
            sidebarTimer.Start();
        }

        private void sidebarTimer_Tick_1(object sender, EventArgs e)
        {
            // SET the minimum and maximum size of sidebar Panel
            if (sidebarExpend)
            {
                // if sidebar is expend , minimize
                sidebar.Width -= 10;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpend = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpend = true;
                    sidebarTimer.Stop();

                }
            }
        }

        private void HomeTimer_Tick(object sender, EventArgs e)
        {
            if (homeCollapse)
            {
                HomeContainer.Height += 10;
                if (HomeContainer.Height == HomeContainer.MaximumSize.Height)
                {
                    homeCollapse = false;
                    HomeTimer.Stop();
                }
            }
            else
            {
                HomeContainer.Height -= 10;
                if (HomeContainer.Height == HomeContainer.MinimumSize.Height)
                {
                    homeCollapse = true;
                    HomeTimer.Stop();
                }
            }
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            // set timer interval  to lowest  to make it smoother
            HomeTimer.Start();
            loginButton.Visible = !loginButton.Visible;
            passwordButton.Visible = !passwordButton.Visible;
        }





        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedItem != null)
            {
                string selectedContact = listBoxContacts.SelectedItem.ToString();

                DialogResult result = MessageBox.Show(
                    $"Ви впевнені, що хочете видалити цей контакт {selectedContact}?",
                    "Підтвердження видалення",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        client = new TcpClient();
                        client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                        NetworkStream ns = client.GetStream();
                        MyRequest clientMassage = new MyRequest();
                        clientMassage.type = "DeleteContact";
                        clientMassage.login = login;
                        clientMassage.message = selectedContact;

                        bf1.Serialize(ns, clientMassage);
                        MyRequest serverMessage = (MyRequest)bf1.Deserialize(ns);

                        if (serverMessage.message == "Success")
                        {
                            listBoxContacts.Items.Remove(selectedContact);
                            MessageBox.Show($"Контакт '{selectedContact}' успішно видалений!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Помилка видалення контакту!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ns.Close();
                        client.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка підключення до сервера: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Виберіть контакт для видалення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonContacts_Click(object sender, EventArgs e)
        {
            showingBlackList = false;
            listBoxContacts.Items.Clear();


            // Меняем цвет фона для обычного списка
            listBoxContacts.BackColor = Color.White;
            listBoxContacts.ForeColor = Color.Black;

            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest clientRequest = new MyRequest();
                clientRequest.type = "GetContacts";
                clientRequest.login = login;

                bf1.Serialize(ns, clientRequest);
                ns.Flush();
                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }
                MyRequest serverResponse = (MyRequest)bf1.Deserialize(ns);

                if (serverResponse.type == "Contacts-response")
                {
                    Console.WriteLine(serverResponse.message);
                    var result = serverResponse.message.Split('/');
                    foreach (string contact in result)
                    {
                        if(contact != " ")
                        listBoxContacts.Items.Add(contact);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Помилка оновлення списку контактів.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ns.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBlackContacts_Click(object sender, EventArgs e)
        {
            showingBlackList = true;
            listBoxContacts.Items.Clear();
            

            // Меняем цвет фона для черного списка
            listBoxContacts.BackColor = Color.DarkGray;
            listBoxContacts.ForeColor = Color.White;
            listBoxContacts.Items.Clear();

            try
            {
                client = new TcpClient();
                client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                NetworkStream ns = client.GetStream();
                MyRequest clientRequest = new MyRequest();
                clientRequest.type = "GetBLackList";
                clientRequest.login = login;

                bf1.Serialize(ns, clientRequest);
                ns.Flush();
                while (!ns.DataAvailable)
                {
                    System.Threading.Thread.Sleep(50);
                }
                MyRequest serverResponse = (MyRequest)bf1.Deserialize(ns);

                if (serverResponse.type == "BlackList-response")
                {
                    Console.WriteLine(serverResponse.message);
                    var result = serverResponse.message.Split('/');
                    foreach (string contact in result)
                    {
                        if (contact != " ")
                            listBoxContacts.Items.Add(contact);
                    }
                    

                }
                else
                {
                    MessageBox.Show("Помилка оновлення списку контактів.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ns.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedItem != null)
            {
                string contact = listBoxContacts.SelectedItem.ToString();
                DialogResult result = MessageBox.Show($"Добавить {contact} в черный список?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        client = new TcpClient();
                        client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                        NetworkStream ns = client.GetStream();
                        MyRequest clientRequest = new MyRequest();
                        clientRequest.type = "AddToBlacklist";
                        clientRequest.login = contact;
                        clientRequest.message = Username;

                        bf1.Serialize(ns, clientRequest);
                        MyRequest serverResponse = (MyRequest)bf1.Deserialize(ns);

                        if (serverResponse.message == "Success")
                        {
                            
                            listBoxContacts.Items.Remove(contact); // Убираем из обычного списка
                            MessageBox.Show($"{contact} добавлен в черный список.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка добавления в черный список.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        ns.Close();
                        client.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddContact form = new FormAddContact(); // false - обычный список
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(IPAddress.Parse("127.0.0.1"), 9090);

                    NetworkStream ns = client.GetStream();
                    MyRequest clientRequest = new MyRequest();
                    clientRequest.type = "AddContact";
                    clientRequest.login = form.Contact;
                    clientRequest.message = Username;

                    bf1.Serialize(ns, clientRequest);
                    ns.Flush();
                    while (!ns.DataAvailable)
                    {
                        System.Threading.Thread.Sleep(50);
                    }
                    MyRequest serverResponse = (MyRequest)bf1.Deserialize(ns);

                    if (serverResponse.type == "Contact-Success")
                    {
                        listBoxContacts.Items.Add(form.Container);
                        MessageBox.Show($"Контакт {form.Container} добавлен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        


                    }
                    else
                    {
                        MessageBox.Show("Ошибка добавления контакта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ns.Close();
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public partial class FormAddContact : Form
        {
            private TextBox textBoxContact;
            public string Contact { get; private set; } // Добавлено свойство

            public FormAddContact()
            {


                // Добавьте текстовое поле для редактирования имени
                textBoxContact = new TextBox
                {
                     // Установка текущего имени
                    Dock = DockStyle.Top,
                    Margin = new Padding(10)
                };
                this.Controls.Add(textBoxContact);

                // Добавьте кнопку "Сохранить"
                Button buttonSave = new Button
                {
                    Text = "Save",
                    Dock = DockStyle.Bottom
                };
                buttonSave.Click += (s, e) =>
                {
                    Contact = textBoxContact.Text; // Исправлено сохранение обновленного контакта
                    this.DialogResult = DialogResult.OK; // Закрываем форму с результатом OK
                    this.Close();
                };
                this.Controls.Add(buttonSave);

                // Настройка формы
                this.Text = "Добавление контакта";
                this.Size = new Size(300, 150);
                this.StartPosition = FormStartPosition.CenterParent;
            }

        }

        public partial class EditContactForm : Form
        {
            private TextBox textBoxContact;
            public string UpdatedContact { get; private set; } // Добавлено свойство

            public EditContactForm(string contact)
            {
                

                // Добавьте текстовое поле для редактирования имени
                textBoxContact = new TextBox
                {
                    Text = contact, // Установка текущего имени
                    Dock = DockStyle.Top,
                    Margin = new Padding(10)
                };
                this.Controls.Add(textBoxContact);

                // Добавьте кнопку "Сохранить"
                Button buttonSave = new Button
                {
                    Text = "Save",
                    Dock = DockStyle.Bottom
                };
                buttonSave.Click += (s, e) =>
                {
                    UpdatedContact = textBoxContact.Text; // Исправлено сохранение обновленного контакта
                    this.DialogResult = DialogResult.OK; // Закрываем форму с результатом OK
                    this.Close();
                };
                this.Controls.Add(buttonSave);

                // Настройка формы
                this.Text = "Редактирование контакта";
                this.Size = new Size(300, 150);
                this.StartPosition = FormStartPosition.CenterParent;
            }
        }

        private void textBoxContacts_TextChanged(object sender, EventArgs e)
        {

        }
    }
}