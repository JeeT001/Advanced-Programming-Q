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
    public partial class AccountTransferForm : Form
    {
        private CustomerController customerController;
        public AccountTransferForm(CustomerController controller)
        {
            InitializeComponent();
            customerController = controller;
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            customerComboBox.Items.Clear();
            foreach (var customer in customerController.GetAllCustomers())
            {
                customerComboBox.Items.Add(customer.CustomerName);
            }
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = customerComboBox.SelectedItem.ToString();
            var customer = customerController.GetCustomerByName(name);

            fromAccountComboBox.Items.Clear();
            toAccountComboBox.Items.Clear();

            foreach (var account in customer.Accounts)
            {
                string type = account.GetType().Name;
                fromAccountComboBox.Items.Add(type);
                toAccountComboBox.Items.Add(type);
            }
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = customerComboBox.SelectedItem.ToString();
                var customer = customerController.GetCustomerByName(name);

                string fromType = fromAccountComboBox.SelectedItem?.ToString();
                string toType = toAccountComboBox.SelectedItem?.ToString();
                double amount = double.Parse(amountTextBox.Text);

                if (fromType == toType)
                {
                    MessageBox.Show("Cannot transfer to the same account type.");
                    return;
                }

                bool success = customerController.TransferBetweenAccounts(customer.CustomerID, fromType, toType, amount);

                if (success)
                    MessageBox.Show($"Transfer successful!");
                else
                    MessageBox.Show($"Failed transfer due to insufficient balance.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
