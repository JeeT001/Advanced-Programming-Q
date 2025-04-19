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
            customerComboBox.SelectedIndexChanged += customerComboBox_SelectedIndexChanged;

        }

        private void InitializeUser()
        {
            customerController.AddCustomer(1, "John Doe");
            customerController.AddAccountToCustomer(1, new EverydayAccount(1, 500.0));
            customerController.AddAccountToCustomer(1, new InvestmentAccount(2, 5000.0, 3.0, 20.0));
            customerController.AddAccountToCustomer(1, new OmniAccount(3, 1200.0, 1.5, 500.0, 25.0));

            // Set current customer
           // currentCustomer = customerController.GetCustomerById(1);
            PopulateCustomerComboBox();
           // PopulateAccountComboBox();
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

          //  accountTypeComboBox.SelectedIndex = 0; // optional default selection
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
        //private void viewInfoButton_Click(object sender, EventArgs e)
        //{
        //    // Ensure a customer is selected
        //    if (currentCustomer == null)
        //    {
        //        MessageBox.Show("Please select a customer.");
        //        return;
        //    }

        //    // Ensure an account is selected
        //    var account = GetSelectedAccount();
        //    if (account != null)
        //    {
        //        // Clear previous info (optional)
        //        transactionListBox.Items.Clear();

        //        // Show customer and account info
        //        transactionListBox.Items.Add($"--- Account Info ---");
        //        transactionListBox.Items.Add($"Customer: {currentCustomer.CustomerName}");
        //        transactionListBox.Items.Add($"Account Type: {account.GetType().Name}");
        //        transactionListBox.Items.Add($"Account ID: {account.accountId}");
        //        transactionListBox.Items.Add($"Balance: ${account.AccountBalance}");

        //        // Add more details manually since getAccountInfo() writes to console
        //        transactionListBox.Items.Add($"Interest Rate: {account.GetType().GetProperty("interestRate", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account)}");
        //        transactionListBox.Items.Add($"Overdraft Limit: {account.GetType().GetProperty("overDraftLimit", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account)}");
        //        transactionListBox.Items.Add($"Fee for Failed Transaction: {account.GetType().GetProperty("feeForFailedTransaction", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account)}");

        //        transactionListBox.Items.Add("--------------------------------------------");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an account type.");
        //    }
        //}

        private void viewInfoButton_Click(object sender, EventArgs e)
        {
            if (currentCustomer == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            transactionListBox.Items.Clear();

            if (currentCustomer.Accounts.Count == 0)
            {
                transactionListBox.Items.Add($"Customer {currentCustomer.CustomerName} has no accounts.");
                return;
            }

            transactionListBox.Items.Add($"--- Account Info for {currentCustomer.CustomerName} ---");

            foreach (var account in currentCustomer.Accounts)
            {
                transactionListBox.Items.Add($"Account Type: {account.GetType().Name}");
                transactionListBox.Items.Add($"Account ID: {account.accountId}");
                transactionListBox.Items.Add($"Balance: ${account.AccountBalance}");

                // Use reflection to fetch optional properties like interest rate, etc.
                var interestRate = account.GetType().GetProperty("interestRate", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account);
                var overdraftLimit = account.GetType().GetProperty("overDraftLimit", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account);
                var failedFee = account.GetType().GetProperty("feeForFailedTransaction", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)?.GetValue(account);

                if (interestRate != null)
                    transactionListBox.Items.Add($"Interest Rate: {interestRate}");
                if (overdraftLimit != null)
                    transactionListBox.Items.Add($"Overdraft Limit: {overdraftLimit}");
                if (failedFee != null)
                    transactionListBox.Items.Add($"Fee for Failed Transaction: {failedFee}");

                transactionListBox.Items.Add("--------------------------------------------");
            }
        }

        private void PopulateAccountTypeComboBoxForCreation()
        {
            accountTypeComboBox.Items.Clear();
            accountTypeComboBox.Items.Add("Everyday Account");
            accountTypeComboBox.Items.Add("Investment Account");
            accountTypeComboBox.Items.Add("Omni Account");
            accountTypeComboBox.SelectedIndex = 0;
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
            PopulateAccountTypeComboBoxForCreation();
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (double.TryParse(transferAmountTextBox.Text, out double amount))
            {
                string from = fromAccountComboBox.SelectedItem.ToString().Split(' ')[0]; // Assume "Everyday Account"
                string to = toAccountComboBox.SelectedItem.ToString().Split(' ')[0];

                bool result = customerController.TransferBetweenAccounts(currentCustomer.CustomerID, from, to, amount);

                if (result)
                {
                    transactionListBox.Items.Add($"Transferred ${amount} from {from} to {to}");
                }
                else
                {
                    transactionListBox.Items.Add("Transfer failed: Insufficient funds including fee.");
                }

                PopulateAccountComboBox(); // Refresh balances
            }
            else
            {
                MessageBox.Show("Enter a valid transfer amount.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            string selectedCustomerName = customerComboBox.SelectedItem.ToString();
            Customer customer = customerController.GetCustomerByName(selectedCustomerName);

            if (customer == null)
            {
                MessageBox.Show("Customer not found.");
                return;
            }

            string accountType = accountTypeComboBox.SelectedItem?.ToString();
            if (!double.TryParse(amountTextBox.Text, out double balance))
            {
                MessageBox.Show("Enter a valid initial balance.");
                return;
            }

            // Generate a new account ID
            int newAccountId = customer.Accounts.Count > 0
                ? customer.Accounts.Max(a => a.accountId) + 1
                : 1;

            Account newAccount = null;

            if (accountType.Contains("Everyday"))
                newAccount = new EverydayAccount(newAccountId, balance);
            else if (accountType.Contains("Investment"))
                newAccount = new InvestmentAccount(newAccountId, balance, 3.0, 20.0);
            else if (accountType.Contains("Omni"))
                newAccount = new OmniAccount(newAccountId, balance, 1.5, 500.0, 25.0);
            else
            {
                MessageBox.Show("Please select a valid account type.");
                return;
            }

            customerController.AddAccountToCustomer(customer.CustomerID, newAccount);
            MessageBox.Show($"{accountType} created for {customer.CustomerName} with ${balance}.");

            if (currentCustomer?.CustomerID == customer.CustomerID)
                PopulateAccountComboBox();  // Refresh account list if this is the current customer
        }
        //t

        private void customerComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedItem == null) return;

            string selectedName = customerComboBox.SelectedItem.ToString();
            currentCustomer = customerController.GetCustomerByName(selectedName);
            PopulateAccountComboBox();  // Refresh account list for the selected customer
            PopulateAccountTypeComboBoxForCreation();
        }
    }
}
