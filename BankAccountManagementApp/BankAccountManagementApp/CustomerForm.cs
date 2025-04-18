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
    public partial class CustomerForm : Form
    {
        private CustomerController controller;

        public CustomerForm(CustomerController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void ClearInputs()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCustomerID.Text);
                string name = txtCustomerName.Text;
                controller.AddCustomer(id, name);
                MessageBox.Show("Customer added successfully");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCustomerID.Text);
                string name = txtCustomerName.Text;
                controller.UpdateCustomer(id, name);
                MessageBox.Show("Customer updated successfully");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtCustomerID.Text);
                controller.DeleteCustomer(id);
                MessageBox.Show("Customer deleted successfully");
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnViewAllCustomers_Click(object sender, EventArgs e)
        {
            try
            {
                var customers = controller.GetAllCustomers();
                lstCustomers.Items.Clear();
                foreach (var cust in customers)
                {
                    lstCustomers.Items.Add($"ID: {cust.CustomerID}, Name: {cust.CustomerName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
