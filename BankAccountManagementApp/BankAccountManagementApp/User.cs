using System.Collections.Generic;

namespace BankAccountManagementApp
{
    public class User
    {
        public string UserName { get; set; }
        public List<Account> Accounts { get; set; }

        // Constructor for hardcoding the user with accounts
        public User(string userName)
        {
            UserName = userName;
            Accounts = new List<Account>();
        }

        // Method to add an account to the user
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
    }
}
