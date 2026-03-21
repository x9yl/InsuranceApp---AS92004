using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Consant Variables, this includes the Monthly insurance rate and the normal device amount insurance rate.
        public static decimal InsuranceRate = 0.9m, MonthlyRate = 0.95m;
        //Declaring my Global variables. This includes my Insurance O
        public static List<string> InsuredDevices = new List<string>();
        public static decimal valueAfterInsured = 0.0m;
        public static List<string> DeviceCategory = new List<string> { "Laptop", "Desktop", "Other" };




        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!");
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {
                Console.WriteLine(OneDevice());
                

                Console.WriteLine("\n--------------------------------\nDo you want to process another device? (y/n)");
                continueInput = Console.ReadLine()[0];
            }
            




            //summary
        }
        //for my OneDevice I am limiting it to only user input.
       public static string OneDevice()
        {
            //Declaring Local variables for OneDevice, this includes all the variables that will be listed in the output.
            
            string id = "";
            decimal price = 0;
            string deviceName = "";
            int deviceAmount = 0;
            int devicecategoryNum = 0;
            string onedeviceOutput = "";
            id = Guid.NewGuid().ToString().Substring(0, 8);

            //capture device name
            Console.WriteLine("\n==================================================="); 
            Console.WriteLine("\n\nDevice name: ");
            deviceName = (Console.ReadLine());


            //Capture Device amount
            Console.WriteLine("\nAmount of Devices: ");
            deviceAmount = (Convert.ToInt32(Console.ReadLine()));

            //Capture Device price
            Console.WriteLine("\nPrice per Device: ");
            price = Convert.ToDecimal(Console.ReadLine());



            //Calculate Device Category
          
                Console.WriteLine("\nWhat category is your Device?: \n(1. Laptop \n(2. Desktop \n(3. Other(Phones, Consoles, etc.)");
            devicecategoryNum = Convert.ToInt32(Console.ReadLine());


            //Generating and output for a Calculated Device
            onedeviceOutput += "\n\n=====================Insurance Outcome=====================";
            onedeviceOutput += $"\nID: {id}\n";
            onedeviceOutput += $"\nName: {deviceName}";
            onedeviceOutput += $"\nCategory: {DeviceCategory[devicecategoryNum-1]}";
            onedeviceOutput += $"\nAmount: {deviceAmount}";
            onedeviceOutput += $"\nPrice: {price.ToString("C")}";
            onedeviceOutput += $"\nInsured Value: {CalculateValue(deviceAmount, price).ToString("C")}";
            onedeviceOutput += $"{CalculateMonthlyValue(deviceAmount, price)}";

            

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

            if (deviceAmount > 5)
            {
                valueafterInsured = ((CalculateCost(deviceAmount,price) - (5 * price)) * InsuranceRate);
                valueafterInsured = valueafterInsured + (5 * price);


            }
            else
            {
                valueafterInsured = CalculateCost(deviceAmount, price);
            }
            
           
            return valueafterInsured;
        }
        public static string CalculateMonthlyValue(int deviceAmount, decimal price)
        {
            decimal monthOne = 0, monthTwo = 0, monthThree = 0, monthFour = 0, monthFive = 0, monthSix = 0;
            string monthlyDepreciation = "";

            monthOne = monthOne = CalculateValue(deviceAmount, price);
            monthTwo = monthOne * MonthlyRate;
            monthThree = monthTwo * MonthlyRate;
            monthFour = monthThree * MonthlyRate;
            monthFive = monthFour * MonthlyRate;
            monthSix = monthFive * MonthlyRate;
            monthlyDepreciation += "\n========================Monthly Summary=====================";
            monthlyDepreciation += $"\nMonth One: {monthOne.ToString("C")}";
            monthlyDepreciation += $"\nMonth Two: {monthTwo.ToString("C")}";
            monthlyDepreciation += $"\nMonth Three: {monthThree.ToString("C")}";
            monthlyDepreciation += $"\nMonth Four: {monthFour.ToString("C")}";
            monthlyDepreciation += $"\nMonth Five: {monthFive.ToString("C")}";
            monthlyDepreciation += $"\nMonth Six: {monthSix.ToString("C")}";


            return monthlyDepreciation;
        }

    }
}