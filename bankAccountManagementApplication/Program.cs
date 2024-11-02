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

    public class Account
    {
        private int accountId { get; set; }
        private double accountBalance { get; set; }
        private double interestRate { get; set; }
        private double overDraftLimit { get; set; }
        private double feeForFailedTransaction { get; set; }


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
            //need implementation
            Console.WriteLine("money added to account");
        }

        public void withdraw()
        {   //need implementation
            Console.WriteLine("money withdraw");
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


    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of Customer
            Customer customer = new Customer(1, 123456, "123 Main St", "John Doe");

            // Displaying customer information
            customer.getCustomerInfo();

            Account account = new Account(2, 100.222, 4, 1000.2, 1000.1);

            account.getAccountInfo();
        }
    }
}
