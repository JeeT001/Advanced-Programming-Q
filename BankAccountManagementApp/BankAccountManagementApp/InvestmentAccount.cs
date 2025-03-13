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


        public override void withdraw(double value)
        {
            if (accountBalance >= value)
            {
                accountBalance -= value;
                Console.WriteLine($"Withdrawal successful. New balance: {accountBalance}");
            }
            else
            {
                throw new WithdrawalException($"Investment Account {accountId}: Insufficient funds. No overdraft allowed.");
            }
        }

    }
}
