using System;

namespace BankAccountManagementApp
{

    //create instance from Account class
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(int id, double balance, double interestRate, double feeForFailedTrans)
            : base(id, balance, interestRate, 0, feeForFailedTrans)
        {
        }

        // Method for calculating interest 
        public void CalculateAndAddInterest()
        {
            if (accountBalance > 1000)
            {
                double interest = accountBalance * (interestRate / 100);
                accountBalance += interest;
                Console.WriteLine($"Investment Account {accountId}: Interest added {interest}. Updated balance: {accountBalance}");
            }
            else
            {
                Console.WriteLine("Interest not added: Balance too low.");
            }
        }

        // Overriding the withdraw method for no overdraft rule and fee for failed transactions
        public new void withdraw(double value)
        {
            if (accountBalance - value >= 0)
            {
                accountBalance -= value;
                Console.WriteLine($"Your Account balance is now {accountBalance}");
            }
            else
            {
                accountBalance -= feeForFailedTransaction;
                Console.WriteLine($"Insufficient funds. A fee of {feeForFailedTransaction} is incurred for a failed transaction. Updated balance {accountBalance}");
            }
        }
    }
}
