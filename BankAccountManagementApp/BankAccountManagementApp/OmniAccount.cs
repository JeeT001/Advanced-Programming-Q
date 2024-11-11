using System;

namespace BankAccountManagementApp
{
    public class OmniAccount : Account
    {
        public OmniAccount(int id, double balance, double interestRate, double overdraftLimit, double feeForFailedTrans)
            : base(id, balance, interestRate, overdraftLimit, feeForFailedTrans)
        {
        }

        // method to CalculateAndAddInterest
        public void CalculateAndAddInterest()
        {
            if (accountBalance > 1000)
            {
                double interest = accountBalance * (interestRate / 100);
                accountBalance += interest;
                Console.WriteLine($"Omni Account {accountId}: Interest added {interest}. Updated balance: {accountBalance}");
            }
            else
            {
                Console.WriteLine("Interest not added: Balance too low.");
            }
        }

        public void getAccountInfo()
        {
            Console.WriteLine("Omni account information:");
            base.getAccountInfo(); // Calling base method to display common account info
        }
    }
}
