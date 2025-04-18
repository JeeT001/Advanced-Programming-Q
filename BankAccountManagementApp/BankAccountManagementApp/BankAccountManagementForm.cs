using System;
using System.Linq;
using System.Windows.Forms;

namespace BankAccountManagementApp
{
    public partial class BankAccountManagementForm : Form
    {
        //private CustomerController customerController = new CustomerController();
        private CustomerController customerController;



        private User user;

        // Sample user setup with three account types
        private EverydayAccount everydayAccount = new EverydayAccount(1, 500.0);
        private InvestmentAccount investmentAccount = new InvestmentAccount(2, 5000.0, 3.0, 20.0);
        private OmniAccount omniAccount = new OmniAccount(3, 1200.0, 1.5, 500.0, 25.0);

        
        private Customer currentCustomer;


        //initializing 
        public BankAccountManagementForm(CustomerController controller)
        {
            InitializeComponent();
            customerController = controller;
            InitializeGUI();
            InitializeUser();
        }



        private void InitializeGUI()
        {


            accountTypeComboBox.Items.Add("Everyday Account");
            accountTypeComboBox.Items.Add("Investment Account");
            accountTypeComboBox.Items.Add("Omni Account");
            transactionListBox.Items.Clear();
            transactionListBox.Items.Add("Select an account and perform actions.");
        }

        private void InitializeUser()
        {
            customerController.AddCustomer(1, "John Doe");
            customerController.AddAccountToCustomer(1, new EverydayAccount(1, 500.0));
            customerController.AddAccountToCustomer(1, new InvestmentAccount(2, 5000.0, 3.0, 20.0));
            customerController.AddAccountToCustomer(1, new OmniAccount(3, 1200.0, 1.5, 500.0, 25.0));

            // Set current customer
            currentCustomer = customerController.GetCustomerById(1);
            PopulateCustomerComboBox();
            PopulateAccountComboBox();
        }

        private void PopulateAccountComboBox()
        {
            accountTypeComboBox.Items.Clear();
            if (currentCustomer != null)
            {
                foreach (var account in currentCustomer.Accounts)
                {
                    accountTypeComboBox.Items.Add($"{account.GetType().Name} (ID: {account.accountId})");
                }
            }

            accountTypeComboBox.SelectedIndex = 0; // optional default selection
        }

        private Account GetSelectedAccount()
        {
            if (currentCustomer == null || accountTypeComboBox.SelectedIndex == -1)
                return null;

            string selectedText = accountTypeComboBox.SelectedItem.ToString();
            int idStart = selectedText.IndexOf("ID: ") + 4;
            int idEnd = selectedText.IndexOf(")", idStart);
            string idString = selectedText.Substring(idStart, idEnd - idStart);

            if (int.TryParse(idString, out int selectedAccountId))
            {
                return currentCustomer.Accounts.FirstOrDefault(a => a.accountId == selectedAccountId);
            }

            return null;
        }


        // Method to get selected account based on combo box selection
        //private Account GetSelectedAccount()
        //{
        //    switch (accountTypeComboBox.SelectedItem?.ToString())
        //    {
        //        case "Everyday Account":
        //            return everydayAccount;
        //        case "Investment Account":
        //            return investmentAccount;
        //        case "Omni Account":
        //            return omniAccount;
        //        default:
        //            return null;
        //    }
        //}

        //Created by no will, If I remove these, it give me ton of errors
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        //Account info button
        private void viewInfoButton_Click(object sender, EventArgs e)
        {
            var account = GetSelectedAccount();
            if (account != null)
            {
                transactionListBox.Items.Add("Viewing Account Info:");
                account.getAccountInfo();  // Calls the account's getAccountInfo() method
                transactionListBox.Items.Add($"Balance: {account.AccountBalance}");
            }
            else
            {
                MessageBox.Show("Please select an account type.");
            }
        }

        //Deposit button
        private void depositButton_Click(object sender, EventArgs e)
        {
            var account = GetSelectedAccount();
            if (account != null)
            {
                if (double.TryParse(amountTextBox.Text, out double amount))
                {
                    account.deposit(amount);  // Update deposit method to take amount as parameter
                    transactionListBox.Items.Add($"Deposited ${amount}. New balance: {account.AccountBalance}");
                }
                else
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please select an account type.");
            }
        }

        // Withdraw Button Click


        //private void withdrawButton_Click_1(object sender, EventArgs e)
        //{
        //    var account = GetSelectedAccount();
        //    if (account != null)
        //    {
        //        if (double.TryParse(amountTextBox.Text, out double amount))
        //        {
        //            bool success = account.withdraw(amount);  // Update withdraw method to take amount as parameter
        //            if (success)
        //            {
        //                transactionListBox.Items.Add($"Withdrew ${amount}. New balance: {account.AccountBalance}");
        //            }
        //            else
        //            {
        //                transactionListBox.Items.Add("Failed transaction. Insufficient funds or overdraft limit reached.");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid amount. Please enter a valid number.");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an account type.");
        //    }

        //}

        private void withdrawButton_Click_1(object sender, EventArgs e)
        {
            var account = GetSelectedAccount();
            if (account != null)
            {
                if (double.TryParse(amountTextBox.Text, out double amount))
                {
                    try
                    {
                        account.withdraw(amount);  // No need to check success as it now throws an exception
                        transactionListBox.Items.Add($"Withdrew ${amount}. New balance: {account.AccountBalance}");
                    }
                    catch (WithdrawalException ex) // Catch the custom exception
                    {
                        transactionListBox.Items.Add(ex.Message);
                    }
                    catch (Exception ex) // Catch any other unexpected errors
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid amount. Please enter a valid number.");
                }
            }
            else
            {
                MessageBox.Show("Please select an account type.");
            }
        }

        private void PopulateCustomerComboBox()
        {
            customerComboBox.Items.Clear();
            foreach (var customer in customerController.GetAllCustomers())
            {
                customerComboBox.Items.Add(customer.CustomerName);
            }
            customerComboBox.SelectedIndex = 0;
        }

        private void customerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = customerComboBox.SelectedItem.ToString();
            currentCustomer = customerController.GetCustomerByName(selectedName);
            PopulateAccountComboBox();
        }



        //Calculate interest button
        private void calculateInterestButton_Click(object sender, EventArgs e)
        {
            var account = GetSelectedAccount();

            if (account is InvestmentAccount investmentAccount)
            {
                investmentAccount.CalculateAndAddInterest();
                transactionListBox.Items.Add($"Interest " +
                    $"added for Investment Account. New balance: {investmentAccount.AccountBalance}");
            }
            else if (account is OmniAccount omniAccount)
            {
                omniAccount.CalculateAndAddInterest();
                transactionListBox.Items.Add($"Interest added for Omni Account. New balance: {omniAccount.AccountBalance}");
            }
            else
            {
                MessageBox.Show("Interest calculation is not available for this account type.");
            }
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
