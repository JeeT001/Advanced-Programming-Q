namespace bankAccountManagementApplication
{


    public class Customer
    {
        private int customerId { get; set; }
        private int customerNumber { get; set; }

        private string customerAddress { get; set; }

        public string customerName;

        public Customer(int id, int number, string address, string name)
        {

            customerId = id;
            customerNumber = number;
            customerAddress = address;
            customerName = name;
        }

        public void getCustomerInfo()
        {
            Console.WriteLine("Customer info");
            Console.WriteLine($"ID: id")
        }   

    }


    internal class Program
    {
        //creating customer class



    }
}
