using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerManagementSystem
{
    //This form is actually a view from the mvc
    public partial class Form1 : Form
    {
        private CustomerController controller;
        public Form1()
        {
            // importing and creating instance of controller
            InitializeComponent();
            controller = new CustomerController();

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // accidently created these two methods, if I remove them build does not work so please just ignore
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // adding button method
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



        // Helper method to clear input fields
        private void ClearInputs()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
        }

        //update button method

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

        //customer button method
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

        // view button method
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
    }
}
