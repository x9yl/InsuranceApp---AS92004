using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Consant Variables, this includes the Monthly insurance rate and the normal device amount insurance rate.
        public static decimal insuranceRate = 0.9m, monthlyRate = 0.95m;
        //Declaring my Global variables. This includes the list for price, devicetype and the Device amount
        public static List<string> InsuranceSummary = new List<string>();
       
       
        
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!");
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {
                OneDevice();

                Console.WriteLine("\n--------------------------------\nDo you want to process another device? (y/n)");
                continueInput = Console.ReadLine()[0];
            }
            




            //summary
        }
        //for my OneDevice I am limiting it to only user input.
       public static string OneDevice()
        {
            //Declaring Local variables for OneDevice, this includes all the variables that will be listed in the output.
            string onedeviceOutput = "";
            string id = "";
            decimal price = 0;
            string deviceName = "";
            int deviceAmount = 0;
            List<string> deviceCategory = new List<string> {"Laptop", "Desktop", "Other" };
            id = Guid.NewGuid().ToString();

            //capture device name
            Console.WriteLine("\n\n What is device would you like to calculate? : ");
            deviceName.Equals(Console.ReadLine());


            //Capture Device amount
            Console.WriteLine("\nHow many of these are you wanting to calculate? : ");
            deviceAmount = (Convert.ToInt32(Console.ReadLine()));

            //Capture Device price
            Console.WriteLine("\nHow much did your device cost? : ");
            price = Convert.ToDecimal(Console.ReadLine());



            //Calculate number of devices in each category
          
                Console.WriteLine("\nWhat category would your device fit under? : \n (1. Laptop \n(2. Desktop \n(3. Other ");
                deviceCategory.
               
            

            onedeviceOutput = $"ID : {id}\nName : {deviceName}\nPrice : {price}\nAmount : {deviceAmount}\nInsured Value : {CalculateValue(deviceAmount, insuranceRate, price)}\nMonthly Depreciation :  ";
            return onedeviceOutput;
            
        }
        public static decimal CalculateCost(int deviceAmount, decimal price)
        {
            decimal cost = 0;
            cost = deviceAmount * price;


            return cost;
        }


        public static decimal CalculateValue(int deviceAmount, decimal price)
        {
            decimal valueafterInsured = 0.0m;

            if (deviceAmount >= 6)
            {
                valueafterInsured = ((CalculateCost(deviceAmount,price) - (5 * price)) * insuranceRate);
                valueafterInsured = valueafterInsured + (5 * price);


            }
            else
            {
                valueafterInsured = CalculateCost(deviceAmount, price);
            }
            
           
            return valueafterInsured;
        }
        
    }
}