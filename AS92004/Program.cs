using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Constant Variables for the Program. This includes device prices, insurance rate, category type, monthlyRate
        
        public static decimal insuranceRate = 0.9m, monthlyRate = 0.95m;
        public static int laptop = 1, desktop = 2, other = 3;
        //Declaring my Global variables. This includes the list for price, devicetype and the Device amount
        public static int deviceAmount = 0;
        List<decimal> price = new List<decimal>();
        List<string> deviceType = new List<string>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!");
          
            



            //summary
        }
        public static string OneDevice(int deviceAmount, int deviceType, int laptop, int desktop, int other, decimal price)
        {
            //Declaring Local variables for OneDevice
            string onedeviceOutput = "";
            
            //capture device type
            Console.WriteLine("\n\n What is device would you like to calculate? : ");
            deviceType.Equals(Console.ReadLine());


            //Capture Device amount
            Console.WriteLine("\nHow many of these are you wanting to calculate? : ");
            deviceAmount = (Convert.ToInt32(Console.ReadLine()));

            //Capture Device type
            Console.WriteLine("\nHow much did your device cost? : ");
            price = Convert.ToDecimal(Console.ReadLine());


            //Calculate number of devices in each category
            Console.WriteLine("What category would your device fit under? : \n (1. Laptop \n(2. Desktop \n(3. Other ");



            return onedeviceOutput;
        }
        public static decimal CalculateCost(int deviceAmount, string displaydeviceType, decimal price)
        {
            decimal cost = 0;
            cost = deviceAmount * price;


            return cost;
        }


        public static decimal CalculateValue(int cost, int deviceAmount,decimal insuranceRate, decimal price)
        {
            decimal valueafterInsured = 0.0m;

           if (deviceAmount >= 6)
            {
                valueafterInsured = deviceAmount - 5 * cost * insuranceRate + (5 * cost);
            }
            return valueafterInsured;
        }
        public static decimal CalculateMonthlyValue(decimal valuefterInsured)
        {
          





        }
        public static string GenerateOutput()
        {

        }
    }
}