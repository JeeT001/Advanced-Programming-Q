using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccountManagementApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide this form

            // Assuming BankAccountManagementForm is another form you created
            BankAccountManagementForm bankForm = new BankAccountManagementForm();
            bankForm.FormClosed += (s, args) => this.Close();
            bankForm.Show();
        }
    }
}
