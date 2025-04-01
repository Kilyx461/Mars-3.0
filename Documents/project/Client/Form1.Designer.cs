namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label17 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBoxContacts = new System.Windows.Forms.ListBox();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonDelete = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.PictureBox();
            this.HomeContainer = new System.Windows.Forms.Panel();
            this.passwordButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.sidebarTimer = new System.Windows.Forms.Timer(this.components);
            this.HomeTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonContacts = new System.Windows.Forms.Button();
            this.buttonBlackContacts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).BeginInit();
            this.HomeContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(353, 28);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 31);
            this.label17.TabIndex = 29;
            this.label17.Text = "Контакти";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Items.AddRange(new object[] {
            "Пошук"});
            this.listBox2.Location = new System.Drawing.Point(352, 62);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(131, 17);
            this.listBox2.TabIndex = 30;
            // 
            // listBoxContacts
            // 
            this.listBoxContacts.FormattingEnabled = true;
            this.listBoxContacts.Items.AddRange(new object[] {
            "."});
            this.listBoxContacts.Location = new System.Drawing.Point(300, 151);
            this.listBoxContacts.Name = "listBoxContacts";
            this.listBoxContacts.ScrollAlwaysVisible = true;
            this.listBoxContacts.Size = new System.Drawing.Size(224, 433);
            this.listBoxContacts.TabIndex = 31;
            this.listBoxContacts.UseWaitCursor = true;
            this.listBoxContacts.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // ChatBox
            // 
            this.ChatBox.Location = new System.Drawing.Point(562, 110);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(875, 450);
            this.ChatBox.TabIndex = 32;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(562, 575);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(875, 38);
            this.textBox1.TabIndex = 33;
            this.textBox1.Text = "Написати повідомлення";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(946, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 31);
            this.label3.TabIndex = 34;
            this.label3.Text = "КОНТАКТ";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(1394, 575);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(43, 38);
            this.SendButton.TabIndex = 35;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(205, 167);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(89, 23);
            this.buttonDelete.TabIndex = 36;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(209, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Redaction";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(300, 93);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(103, 23);
            this.buttonAdd.TabIndex = 38;
            this.buttonAdd.Text = "AddContacts";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.HomeContainer);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.MaximumSize = new System.Drawing.Size(200, 676);
            this.sidebar.MinimumSize = new System.Drawing.Size(64, 676);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(200, 676);
            this.sidebar.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuButton);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(197, 102);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "menu";
            // 
            // menuButton
            // 
            this.menuButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.Location = new System.Drawing.Point(3, 26);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(63, 50);
            this.menuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.menuButton.TabIndex = 42;
            this.menuButton.TabStop = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // HomeContainer
            // 
            this.HomeContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.HomeContainer.Controls.Add(this.passwordButton);
            this.HomeContainer.Controls.Add(this.loginButton);
            this.HomeContainer.Controls.Add(this.buttonHome);
            this.HomeContainer.Location = new System.Drawing.Point(3, 111);
            this.HomeContainer.MaximumSize = new System.Drawing.Size(197, 133);
            this.HomeContainer.MinimumSize = new System.Drawing.Size(197, 50);
            this.HomeContainer.Name = "HomeContainer";
            this.HomeContainer.Size = new System.Drawing.Size(197, 51);
            this.HomeContainer.TabIndex = 45;
            // 
            // passwordButton
            // 
            this.passwordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.passwordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordButton.ForeColor = System.Drawing.Color.White;
            this.passwordButton.Location = new System.Drawing.Point(0, 100);
            this.passwordButton.Name = "passwordButton";
            this.passwordButton.Size = new System.Drawing.Size(200, 35);
            this.passwordButton.TabIndex = 44;
            this.passwordButton.Text = "Password: ******";
            this.passwordButton.UseVisualStyleBackColor = false;
            this.passwordButton.Click += new System.EventHandler(this.passwordButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(55)))), ((int)(((byte)(60)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(0, 56);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 38);
            this.loginButton.TabIndex = 43;
            this.loginButton.Text = "Login: ******";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(0, 3);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(200, 50);
            this.buttonHome.TabIndex = 42;
            this.buttonHome.Text = " Home";
            this.buttonHome.UseVisualStyleBackColor = false;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.sidebarTimer_Tick_1);
            // 
            // HomeTimer
            // 
            this.HomeTimer.Interval = 10;
            this.HomeTimer.Tick += new System.EventHandler(this.HomeTimer_Tick);
            // 
            // buttonContacts
            // 
            this.buttonContacts.Location = new System.Drawing.Point(300, 122);
            this.buttonContacts.Name = "buttonContacts";
            this.buttonContacts.Size = new System.Drawing.Size(103, 23);
            this.buttonContacts.TabIndex = 41;
            this.buttonContacts.Text = "Contacts";
            this.buttonContacts.UseVisualStyleBackColor = true;
            this.buttonContacts.Click += new System.EventHandler(this.buttonContacts_Click);
            // 
            // buttonBlackContacts
            // 
            this.buttonBlackContacts.Location = new System.Drawing.Point(435, 122);
            this.buttonBlackContacts.Name = "buttonBlackContacts";
            this.buttonBlackContacts.Size = new System.Drawing.Size(89, 23);
            this.buttonBlackContacts.TabIndex = 42;
            this.buttonBlackContacts.Text = "BlackContacts";
            this.buttonBlackContacts.UseVisualStyleBackColor = true;
            this.buttonBlackContacts.Click += new System.EventHandler(this.buttonBlackContacts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(423, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "buttonBlackContacts";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 676);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonBlackContacts);
            this.Controls.Add(this.buttonContacts);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.listBoxContacts);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.label17);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.sidebar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuButton)).EndInit();
            this.HomeContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBoxContacts;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox menuButton;
        private System.Windows.Forms.Timer sidebarTimer;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Panel HomeContainer;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Timer HomeTimer;
        private System.Windows.Forms.Button passwordButton;
        private System.Windows.Forms.Button buttonContacts;
        private System.Windows.Forms.Button buttonBlackContacts;
        private System.Windows.Forms.Button button1;
    }
}

