using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementApp
{
    public class WithdrawalException : Exception
    {
        public WithdrawalException(string message) : base(message)
        {
        }
    }
}
