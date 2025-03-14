using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //creating constructor 
        public Account(int id, double balance, double interest, double overDraftL, double fee)
        {
            accountId = id;
            accountBalance = balance;
            interestRate = interest;
            overDraftLimit = overDraftL;
            feeForFailedTransaction = fee;
        }

        public void deposit(double input)
        {
            
            Console.WriteLine("How much money you want to deposit?");

            accountBalance += input;

            Console.WriteLine($"Your Account balance now is {accountBalance}");
        }


        public virtual void withdraw(double input)
        {
            if (accountBalance >= input)
            {
                accountBalance -= input;
                Console.WriteLine($"Withdrawal successful. New balance: {accountBalance}");
            }
            else
            {
                throw new WithdrawalException($"Account {accountId}: Insufficient funds.");
            }
        }


        public void getAccountInfo()
        {
            Console.WriteLine("Account Info: ");
            Console.WriteLine($"ID: {accountId}");
            Console.WriteLine($"Account Balance: {accountBalance}");
            Console.WriteLine($"Interest Rate: {interestRate}");
            Console.WriteLine($"Over Draft Limit: {overDraftLimit}");
            Console.WriteLine($"Fee For Failed Transaction: {feeForFailedTransaction}");
        }
    }
}
