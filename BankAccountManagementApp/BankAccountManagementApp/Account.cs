using System;

namespace BankAccountManagementApp
{
    public abstract class Account
    {
        public int accountId { get; set; }
        protected double accountBalance { get; set; }
        protected double interestRate { get; set; }
        protected double overDraftLimit { get; set; }
        protected double feeForFailedTransaction { get; set; }

        // Public read-only property for accountBalance
        public double AccountBalance
        {
            get { return accountBalance; }
        }

        // Constructor
        public Account(int id, double balance, double interest, double overDraftL, double fee)
        {
            accountId = id;
            accountBalance = balance;
            interestRate = interest;
            overDraftLimit = overDraftL;
            feeForFailedTransaction = fee;
        }

        // Deposit method
        public void deposit(double input)
        {
            accountBalance += input;
        }

        // Withdraw method
        public virtual void withdraw(double input)
        {
            if (accountBalance >= input)
            {
                accountBalance -= input;
            }
            else
            {
                throw new WithdrawalException($"Account {accountId}: Insufficient funds.");
            }
        }

        // Updated getAccountInfo to return a string
        public virtual string getAccountInfo()
        {
            // Return the account details as a formatted string
            return $"Account Info:\n" +
                   $"ID: {accountId}\n" +
                   $"Balance: {accountBalance}\n" +
                   $"Interest Rate: {interestRate}%\n" +
                   $"Overdraft Limit: {overDraftLimit}\n" +
                   $"Fee for Failed Transaction: {feeForFailedTransaction}";
        }
    }
}
