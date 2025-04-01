using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FormAddContact : Form
    {
        public string ContactName { get; private set; }
        private bool isBlacklist;

        public FormAddContact(bool isBlacklist)
        {
            InitializeComponent();
            this.isBlacklist = isBlacklist;

            this.Text = isBlacklist ? "Добавление в черный список" : "Добавление контакта";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.KeyPreview = true;
            this.KeyDown += FormAddContact_KeyDown;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите имя контакта!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ContactName = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FormAddContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                buttonCansel_Click(sender, e);
            }
        }
    }
}
