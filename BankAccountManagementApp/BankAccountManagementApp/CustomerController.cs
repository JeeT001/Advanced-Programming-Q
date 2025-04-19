using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementApp
{
    //controller class for manipulation of data but not directly
    public class CustomerController
    {
        public void InitializeDefaultCustomer()
        {
            AddCustomer(1, "John Doe");

            AddAccountToCustomer(1, new EverydayAccount(1, 500.0));
            AddAccountToCustomer(1, new InvestmentAccount(2, 5000.0, 3.0, 20.0));
            AddAccountToCustomer(1, new OmniAccount(3, 1200.0, 1.5, 500.0, 25.0));
        }

        private List<Customer> customers = new List<Customer>();

        // Add Customer
        public void AddCustomer(int id, string name, string role = "customer")
        {
            if (customers.Any(c => c.CustomerID == id))
                throw new InvalidOperationException("Customer ID already exists");

            customers.Add(new Customer(id, name, role));
        }

        public bool TransferBetweenAccounts(int customerId, string fromAccountType, string toAccountType, double amount)
        {
            var customer = GetCustomerById(customerId);

            var fromAccount = customer.GetAccountByType(fromAccountType);
            var toAccount = customer.GetAccountByType(toAccountType);

            if (fromAccount == null || toAccount == null)
                throw new InvalidOperationException("Invalid account type selected.");

            double fee = customer.Role == "staff" ? 0.0 : 2.0; // Flat fee for non-staff

            if (fromAccount.AccountBalance >= amount + fee)
            {
                fromAccount.withdraw(amount + fee);
                toAccount.deposit(amount);
                return true;
            }

            return false;
        }



        // Update Customer
        public void UpdateCustomer(int id, string newName)
        {
            var customer = GetCustomerById(id);
            customer.CustomerName = newName;
        }

        // Delete Customer
        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            customers.Remove(customer);
        }

        // Get all customers
        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        // Get specific customer
        public Customer GetCustomerById(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");
            return customer;
        }

        // Add account to a customer
        //public void AddAccountToCustomer(int customerId, Account account)
        //{
        //    var customer = GetCustomerById(customerId);
        //    customer.AddAccount(account);
        //}

        // Add account to a customer with duplicate checks
        public void AddAccountToCustomer(int customerId, Account account)
        {
            var customer = GetCustomerById(customerId);

            string accountType = account.GetType().Name;

            if (customer.Accounts.Any(a => a.GetType().Name == accountType))
                throw new InvalidOperationException($"Customer already has a {accountType}.");

            customer.AddAccount(account);
        }


        // Get customer by name
        public Customer GetCustomerByName(string name)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerName == name);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");
            return customer;
        }


        // Get accounts of a customer
        public List<Account> GetAccountsForCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            return customer.Accounts;
        }
    }
}
