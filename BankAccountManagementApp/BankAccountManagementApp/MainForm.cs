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

        private CustomerController sharedCustomerController = new CustomerController();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide(); // Hide this form

            //// Assuming BankAccountManagementForm is another form you created
            //BankAccountManagementForm bankForm = new BankAccountManagementForm();
            //bankForm.FormClosed += (s, args) => this.Close();
            //bankForm.Show();

            BankAccountManagementForm bankForm = new BankAccountManagementForm(sharedCustomerController);
            bankForm.FormClosed += (s, args) => this.Close();
            bankForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // // Assuming BankAccountManagementForm is another form you created
            // CustomerForm cusForm = new CustomerForm();
            //// cusForm.FormClosed += (s, args) => this.Close();
            // cusForm.Show();
            CustomerForm cusForm = new CustomerForm(sharedCustomerController);
            cusForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
