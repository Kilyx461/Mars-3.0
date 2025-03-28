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
            this.BtnBan = new System.Windows.Forms.Button();
            this.Test2 = new System.Windows.Forms.ListBox();
            this.SearchUser = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnBan
            // 
            this.BtnBan.Location = new System.Drawing.Point(203, 320);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

