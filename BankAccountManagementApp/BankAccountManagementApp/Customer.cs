using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementApp
{
    //main customer class
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public List<Account> Accounts { get; set; }

        public Customer(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Customer name cannot be empty");

            CustomerID = id;
            CustomerName = name;
            Accounts = new List<Account>();
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }

        public Account GetAccountByType(string accountType)
        {
            return Accounts.FirstOrDefault(a => a.GetType().Name == accountType);
        }
    }
}
