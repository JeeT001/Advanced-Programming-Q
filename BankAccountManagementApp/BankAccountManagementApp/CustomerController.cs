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
        private List<Customer> customers = new List<Customer>();

        //add method
        public void AddCustomer(int id, string name)
        {
            if (customers.Any(c => c.CustomerID == id))
                throw new InvalidOperationException("Customer ID already exists");

            customers.Add(new Customer(id, name));
        }

        // update method
        public void UpdateCustomer(int id, string newName)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            customer.CustomerName = newName;
        }

        //delete method
        public void DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            customers.Remove(customer);
        }

        // list method
        public List<Customer> GetAllCustomers()
        {
            return customers;
        }
    }
}
