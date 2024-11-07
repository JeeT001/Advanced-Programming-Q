namespace bankAccountManagementApplication
{


    public class Customer
    {
        //putting required customer info
        private int customerId { get; set; }
        private int customerNumber { get; set; }

        private string customerAddress { get; set; }

        public string customerName;

        // creating constructure class
        public Customer(int id, int number, string address, string name)
        {

            customerId = id;
            customerNumber = number;
            customerAddress = address;
            customerName = name;
        }
        //creating writelines to display the customers details
        public void getCustomerInfo()
        {
            Console.WriteLine("Customer info");
            Console.WriteLine($"ID:{customerId}");
            Console.WriteLine($"Number:{customerNumber}");
            Console.WriteLine($"Address:{customerAddress}");
        }   

    }

    public abstract class Account
    {
        protected int accountId { get; set; }
        protected double accountBalance { get; set; }
        protected double interestRate { get; set; }
        protected double overDraftLimit { get; set; }
        protected double feeForFailedTransaction { get; set; }


        public Account(int id, double balance, double interest, double overDraftL, double fee )
        {
            accountId = id;
            accountBalance = balance;
            interestRate = interest;
            overDraftLimit = overDraftL;
            feeForFailedTransaction = fee;
        }

        public void deposit()
        {
            //simple implementation by converting the readline string to double and then updating the account balance.
            Console.WriteLine("How much money you want to deposit?");
            string input = Console.ReadLine();
            double value;

            double.TryParse(input, out value);

            accountBalance += value;

            Console.WriteLine($"Your Account balance now is {accountBalance}");
        }

        public void withdraw()
        {  
            //copy and pasted the deposite method with little changes as minus instead of plus and some words.
            Console.WriteLine("How much money you want to withdraw?");
            string input = Console.ReadLine();
            double value;

            double.TryParse(input, out value);

            accountBalance -= value;

            Console.WriteLine($"Your Account balance now is {accountBalance}");
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



    }

    public class OmniAccount : Account
    {
        public OmniAccount(int id, double balance, double interestRate, double overdraftLimit, double feeForFailedTrans) : base(id, balance, interestRate, overdraftLimit, feeForFailedTrans)
        {

        }

        public void interest()
        {
            if (accountBalance > 1000)
            {
                double interest = accountBalance * (interestRate / 100);
                accountBalance += interest;
                Console.WriteLine($"Omni {accountId}; interest added {interest}, Updated balance {accountBalance}");

            }
            else
            {
                Console.WriteLine("interest not added");
            }
        }

        public void getAccountInfo()
        {
            Console.WriteLine("omni account information");
            base.getAccountInfo();
        }
    }


    public class InvestmentAccout : Account
    {
        public InvestmentAccout(int id, double balance, double interestRate, double feeForFailedTrans) : base(id, balance, interestRate, 0, feeForFailedTrans)
        {

        }

        public void interest()
        {
            if (accountBalance > 1000)
            {
                double interest = accountBalance * (interestRate / 100);
                accountBalance += interest;
                Console.WriteLine($"Investment {accountId}; interest added {interest}, Updated balance {accountBalance}");

            }
            else
            {
                Console.WriteLine("interest not added");
            }
        }

        // Overriding the withdraw method to implement the no overdraft rule and fee for failed transactions
        public new void withdraw()
        {
            Console.WriteLine("How much money do you want to withdraw?");
            if (double.TryParse(Console.ReadLine(), out double value))
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
            else
            {
                Console.WriteLine("Invalid input");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of Customer
            Customer customer = new Customer(1, 123456, "123 Main St", "John Doe");

            // Displaying customer information
            customer.getCustomerInfo();

            /* Just implemented absract keyword and It started to give error.

              Account account = new Account(2, 100.222, 4, 1000.2, 1000.1);

              account.getAccountInfo();
              account.deposit();
              account.withdraw();
            */

            // Creating an EverydayAccount instance
            EverydayAccount everydayAccount = new EverydayAccount(2, 500.0);
            everydayAccount.getAccountInfo();
         //   everydayAccount.deposit();
           // everydayAccount.withdraw();

            /*

            OmniAccount omniAccount = new OmniAccount(3, 2000.2, 4, 100, 50);
            omniAccount.getAccountInfo();
            omniAccount.deposit();
            omniAccount.interest();
            

            */

            InvestmentAccout investmentAccout = new InvestmentAccout(4, 4000, 5, 10);
            investmentAccout.getAccountInfo();
            investmentAccout.withdraw();
            investmentAccout.interest();
        }
    }
}
