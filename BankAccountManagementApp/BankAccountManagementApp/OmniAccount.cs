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

        public override void withdraw(double value)
        {
            if (accountBalance - value >= -overDraftLimit)
            {
                accountBalance -= value;
                Console.WriteLine($"Omni Account {accountId}: Withdrawal successful. Updated balance: {accountBalance}");
            }
            else
            {
                throw new WithdrawalException($"Omni Account {accountId}: Overdraft limit exceeded. Withdrawal denied.");
            }
        }

    }
}
