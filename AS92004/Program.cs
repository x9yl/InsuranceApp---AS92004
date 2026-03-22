using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Consant Variables, this includes the Monthly insurance rate and the device amount insurance rate.
        public static decimal InsuranceRate = 0.9m, MonthlyRate = 0.95m;
        //Declaring my Global variables. This includes my Device category list
        public static List<string> DEVICECATEGORY = new List<string> { "Laptop", "Desktop", "Other" };
        //Insurance Summary global variables
        public static int TotalDevices = 0, TotalLaptops = 0, TotalDesktops = 0, TotalOther = 0;
        public static decimal TotalInsuranceValue = 0.0m, MostExpensive = 0, valueafterInsured = 0.0m;
        //deviceName is global since ill be using it in my summary in my main method.
        public static string deviceName = "";




        static void Main(string[] args)
        {
            //Console Title
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!");
            
            //While loop to continue for as much as the user needs
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {
                
                Console.WriteLine(OneDevice());
                

                Console.WriteLine("\n--------------------------------\nDo you want to process another device? (y/n)");
                continueInput = Console.ReadLine()[0];
            }

            //summary
            Console.WriteLine("==============================Summary==============================\n\n");
            Console.WriteLine($"Total Devices: {TotalDevices}\nTotal Laptops: {TotalLaptops}\nTotal Desktops: {TotalDesktops}\nTotal Other: {TotalOther}\n");
            Console.WriteLine($"Most Expensive Device: {deviceName} @ {CalculateMostExpensive(valueafterInsured).ToString("C")}\n");
            Console.WriteLine($"Total Insured Price of all Devices: {TotalInsuranceValue}");
        }
        //for my OneDevice I am limiting it to only user input.
       public static string OneDevice()
        {
            //Declaring Local variables for OneDevice, this includes all the variables that will be listed in the output.
            
            string id = "";
            decimal price = 0;
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
            //Gathering the total amount of devices
            TotalDevices += deviceAmount;

            //Capture Device price
            Console.WriteLine("\nPrice per Device: ");
            price = Convert.ToDecimal(Console.ReadLine());



            //Calculate Device Category
          
                Console.WriteLine("\nWhat category is your Device?: \n(1. Laptop \n(2. Desktop \n(3. Other(Phones, Consoles, etc.)");
            devicecategoryNum = Convert.ToInt32(Console.ReadLine());
            //Gathering the total Device Count
           

            //Generating an output for a Calculated Device
            onedeviceOutput += "\n\n=====================Insurance Outcome======================";
            onedeviceOutput += $"\nID: {id}\n";
            onedeviceOutput += $"\nName: {deviceName}";
            onedeviceOutput += $"\nCategory: {DEVICECATEGORY[devicecategoryNum-1]}";
            onedeviceOutput += $"\nAmount: {deviceAmount}";
            onedeviceOutput += $"\nPrice: {price.ToString("C")}";
            onedeviceOutput += $"\nInsured Value: {CalculateValue(deviceAmount, price).ToString("C")}";
            onedeviceOutput += $"{CalculateMonthlyValue(deviceAmount, price)}";

            //Putting it in my oneDevice gives me access to the local variables that are needed to be used, since its global it stores over the whole time instead of reseting after every loop.
            //it also allows the summary count to run inside the while loop and calculate what is needed over time
            if (devicecategoryNum == 1)
            {
                TotalLaptops += deviceAmount;
            }
            else if (devicecategoryNum == 2)
            {
                TotalDesktops += deviceAmount;
            }
            else
            {
                TotalOther += deviceAmount;
            }

            

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
                valueafterInsured = ((CalculateCost(deviceAmount, price) - (5 * price)) * InsuranceRate);
                valueafterInsured = valueafterInsured + (5 * price);
               
            }
            else
            {
                valueafterInsured = CalculateCost(deviceAmount, price);
                
            }
            //Running my most Expensive method every time a value is calculated.
            CalculateMostExpensive(valueafterInsured);
            //Also using calculate value to loop and add all the values altogether for the TotalInsuranceValue
            TotalInsuranceValue += valueafterInsured;

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

            //Generating a summary for my Monthly summary.
            monthlyDepreciation += "\n========================Monthly Summary=====================";
            monthlyDepreciation += $"\nMonth 1:      {monthOne.ToString("C")}";
            monthlyDepreciation += $"\nMonth 2:      {monthTwo.ToString("C")}";
            monthlyDepreciation += $"\nMonth 3:      {monthThree.ToString("C")}";
            monthlyDepreciation += $"\nMonth 4:      {monthFour.ToString("C")}";
            monthlyDepreciation += $"\nMonth 5:      {monthFive.ToString("C")}";
            monthlyDepreciation += $"\nMonth 6:      {monthSix.ToString("C")}";


            return monthlyDepreciation;
        }


        public static decimal CalculateMostExpensive(decimal valueafterInsured)
        {

            if (valueafterInsured > MostExpensive)
            { 
            MostExpensive = valueafterInsured;
            }

            return MostExpensive;
        }

    }
}