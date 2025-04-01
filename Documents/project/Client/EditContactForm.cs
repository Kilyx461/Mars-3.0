using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class EditContactForm : Form
    {

      

        public string UpdatedContact { get; private set; } // Для передачи обновленного имени
        public string contact { get;  set; }
        public EditContactForm()
        {
            
        }

        private void EditContactForm_Load(object sender, EventArgs e)
        {
           
           
        }

       

        private void CanselButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {

        }
    }
}
