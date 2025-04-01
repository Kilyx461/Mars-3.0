namespace Admin
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
            this.BtnBan = new System.Windows.Forms.Button();
            this.Test2 = new System.Windows.Forms.ListBox();
            this.SearchUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RepBox = new System.Windows.Forms.ListBox();
            this.BtnIgnore = new System.Windows.Forms.Button();
            this.BtnBan2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnBan3 = new System.Windows.Forms.Button();
            this.BtnIgnore2 = new System.Windows.Forms.Button();
            this.RepBox2 = new System.Windows.Forms.ListBox();
            this.BtnBan4 = new System.Windows.Forms.Button();
            this.BtnIgnore3 = new System.Windows.Forms.Button();
            this.RepBox3 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BtnBan
            // 
            this.BtnBan.Location = new System.Drawing.Point(157, 405);
            this.BtnBan.Name = "BtnBan";
            this.BtnBan.Size = new System.Drawing.Size(75, 23);
            this.BtnBan.TabIndex = 0;
            this.BtnBan.Text = "Ban";
            this.BtnBan.UseVisualStyleBackColor = true;
            this.BtnBan.Click += new System.EventHandler(this.BtnBan_Click);
            // 
            // Test2
            // 
            this.Test2.FormattingEnabled = true;
            this.Test2.Items.AddRange(new object[] {
            "Test2"});
            this.Test2.Location = new System.Drawing.Point(12, 86);
            this.Test2.Name = "Test2";
            this.Test2.Size = new System.Drawing.Size(120, 342);
            this.Test2.TabIndex = 1;
            // 
            // SearchUser
            // 
            this.SearchUser.Location = new System.Drawing.Point(12, 12);
            this.SearchUser.Name = "SearchUser";
            this.SearchUser.Size = new System.Drawing.Size(120, 20);
            this.SearchUser.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SearchButton);
            // 
            // RepBox
            // 
            this.RepBox.FormattingEnabled = true;
            this.RepBox.Location = new System.Drawing.Point(538, 33);
            this.RepBox.Name = "RepBox";
            this.RepBox.Size = new System.Drawing.Size(221, 95);
            this.RepBox.TabIndex = 4;
            this.RepBox.SelectedIndexChanged += new System.EventHandler(this.ListBox);
            // 
            // BtnIgnore
            // 
            this.BtnIgnore.Location = new System.Drawing.Point(674, 86);
            this.BtnIgnore.Name = "BtnIgnore";
            this.BtnIgnore.Size = new System.Drawing.Size(75, 23);
            this.BtnIgnore.TabIndex = 5;
            this.BtnIgnore.Text = "Ignore";
            this.BtnIgnore.UseVisualStyleBackColor = true;
            this.BtnIgnore.Click += new System.EventHandler(this.BtnIgnore_Click);
            // 
            // BtnBan2
            // 
            this.BtnBan2.Location = new System.Drawing.Point(556, 86);
            this.BtnBan2.Name = "BtnBan2";
            this.BtnBan2.Size = new System.Drawing.Size(75, 23);
            this.BtnBan2.TabIndex = 6;
            this.BtnBan2.Text = "Ban";
            this.BtnBan2.UseVisualStyleBackColor = true;
            this.BtnBan2.Click += new System.EventHandler(this.btnBanReport);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // BtnBan3
            // 
            this.BtnBan3.Location = new System.Drawing.Point(556, 236);
            this.BtnBan3.Name = "BtnBan3";
            this.BtnBan3.Size = new System.Drawing.Size(75, 23);
            this.BtnBan3.TabIndex = 9;
            this.BtnBan3.Text = "Ban";
            this.BtnBan3.UseVisualStyleBackColor = true;
            this.BtnBan3.Click += new System.EventHandler(this.BtnBan3_Click);
            // 
            // BtnIgnore2
            // 
            this.BtnIgnore2.Location = new System.Drawing.Point(674, 236);
            this.BtnIgnore2.Name = "BtnIgnore2";
            this.BtnIgnore2.Size = new System.Drawing.Size(75, 23);
            this.BtnIgnore2.TabIndex = 8;
            this.BtnIgnore2.Text = "Ignore";
            this.BtnIgnore2.UseVisualStyleBackColor = true;
            this.BtnIgnore2.Click += new System.EventHandler(this.BtnIgnore2_Click);
            // 
            // RepBox2
            // 
            this.RepBox2.FormattingEnabled = true;
            this.RepBox2.Location = new System.Drawing.Point(538, 183);
            this.RepBox2.Name = "RepBox2";
            this.RepBox2.Size = new System.Drawing.Size(221, 95);
            this.RepBox2.TabIndex = 7;
            // 
            // BtnBan4
            // 
            this.BtnBan4.Location = new System.Drawing.Point(556, 386);
            this.BtnBan4.Name = "BtnBan4";
            this.BtnBan4.Size = new System.Drawing.Size(75, 23);
            this.BtnBan4.TabIndex = 12;
            this.BtnBan4.Text = "Ban";
            this.BtnBan4.UseVisualStyleBackColor = true;
            this.BtnBan4.Click += new System.EventHandler(this.BtnBan4_Click);
            // 
            // BtnIgnore3
            // 
            this.BtnIgnore3.Location = new System.Drawing.Point(674, 386);
            this.BtnIgnore3.Name = "BtnIgnore3";
            this.BtnIgnore3.Size = new System.Drawing.Size(75, 23);
            this.BtnIgnore3.TabIndex = 11;
            this.BtnIgnore3.Text = "Ignore";
            this.BtnIgnore3.UseVisualStyleBackColor = true;
            this.BtnIgnore3.Click += new System.EventHandler(this.BtnIgnore3_Click);
            // 
            // RepBox3
            // 
            this.RepBox3.FormattingEnabled = true;
            this.RepBox3.Location = new System.Drawing.Point(538, 333);
            this.RepBox3.Name = "RepBox3";
            this.RepBox3.Size = new System.Drawing.Size(221, 95);
            this.RepBox3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnBan4);
            this.Controls.Add(this.BtnIgnore3);
            this.Controls.Add(this.RepBox3);
            this.Controls.Add(this.BtnBan3);
            this.Controls.Add(this.BtnIgnore2);
            this.Controls.Add(this.RepBox2);
            this.Controls.Add(this.BtnBan2);
            this.Controls.Add(this.BtnIgnore);
            this.Controls.Add(this.RepBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SearchUser);
            this.Controls.Add(this.Test2);
            this.Controls.Add(this.BtnBan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBan;
        private System.Windows.Forms.ListBox Test2;
        private System.Windows.Forms.TextBox SearchUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox RepBox;
        private System.Windows.Forms.Button BtnIgnore;
        private System.Windows.Forms.Button BtnBan2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnBan3;
        private System.Windows.Forms.Button BtnIgnore2;
        private System.Windows.Forms.ListBox RepBox2;
        private System.Windows.Forms.Button BtnBan4;
        private System.Windows.Forms.Button BtnIgnore3;
        private System.Windows.Forms.ListBox RepBox3;
    }
}

