﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementApp
{
    public class EverydayAccount : Account
    {
        // Everyday Account has no interest, no overdraft, and no transaction fees
        public EverydayAccount(int id, double balance) : base(id, balance, 0, 0, 0)
        {
        }

        public new void getAccountInfo()
        {
            Console.WriteLine("Everyday Account Info:");
            base.getAccountInfo(); // Display common account info
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
                throw new WithdrawalException($"Everyday Account {accountId}: Insufficient funds.");
            }
        }




    }


}
