using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Consant Variables, this includes the Monthly insurance rate and the normal insurance rate.
        public static decimal InsuranceRate = 0.9m, MonthlyRate = 0.95m;
        
        //Insurance Summary global variables
        public static int TotalDevices = 0, TotalLaptops = 0, TotalDesktops = 0, TotalOther = 0;
        public static decimal TotalInsuranceValue = 0.0m, MostExpensive = 0, valueafterInsured = 0.0m;
        //deviceName is global since ill be using it in my summary which is in my main method.
        public static string deviceName = "";

        static void Main(string[] args)
        {
            //Console Title
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!\n\n\n");

            //While loop to continue for as much as the user needs
            char continueInput = 'y';
            while (continueInput == 'y' || continueInput.Equals('y'))
            {

                Console.WriteLine(OneDevice());


                Console.WriteLine("\n--------------------------------\nDo you want to process another device? (y/n)");
                continueInput = Console.ReadLine()[0];
            }

            //summary
            Console.WriteLine("\n==============================Summary==============================\n");
            Console.WriteLine($"Total Devices: {TotalDevices}\nTotal Laptops: {TotalLaptops}\nTotal Desktops: {TotalDesktops}\nTotal Other: {TotalOther}\n");
            Console.WriteLine($"Most Expensive Device: {deviceName} @ {CalculateMostExpensive().ToString("C")}\n");
            Console.WriteLine($"Total Insured Price of all Devices: {TotalInsuranceValue.ToString("C")}");
            Console.WriteLine("\n==================================================================\n");
        }
        //for my OneDevice I am limiting it to only user input.
        public static string OneDevice()
        {
            //Declaring Local variables
            List<string> QUESTIONS = new List<string> { "\n\nDevice name:", "\nAmount of Devices:", "\nPrice per Device:", "\nEnter Device Category: \n(1.Laptop\n(2.Desktop\n(3.Other(Phones, Consoles, etc)" };
            List<string> DEVICECATEGORY = new List<string> { "Laptop", "Desktop", "Other" };
            string id = "";
            decimal price = 0;
            int deviceAmount = 0;
            int devicecategoryNum = 0;
            string onedeviceOutput = "";
            id = Guid.NewGuid().ToString().Substring(0, 8);

            Console.WriteLine("\n============================Add Device========================\n");
          
            //Capture the Name
            deviceName = CheckName(QUESTIONS[0]);
            //Capture Amount of devices
            deviceAmount = CheckInt(QUESTIONS[1]);
            //Capture Price of one device
            price = CheckDecimal(QUESTIONS[2]);
            //Capture Category Number
            devicecategoryNum = CheckCategory(QUESTIONS[3]);

            //Generating an output for a Calculated Device
            onedeviceOutput += "\n\n=====================Insurance Outcome=======================";
            onedeviceOutput += $"\nID: {id}\n";
            onedeviceOutput += $"\nName: {deviceName}";
            onedeviceOutput += $"\nCategory: {DEVICECATEGORY[devicecategoryNum - 1]}";
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
            //Gathering the Total amount of devices calculated
            TotalDevices += deviceAmount;


            return onedeviceOutput;

        }
        public static decimal CalculateCost(int deviceAmount, decimal price)
        {
            //multiplying the User input price by the user input amount of devices.
            decimal cost = 0;
            cost = deviceAmount * price;


            return cost;
        }

        public static decimal CalculateValue(int deviceAmount, decimal price)
        {
          //Calculating value after insurance

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
            CalculateMostExpensive();
            
            

            return valueafterInsured;
        }
        public static string CalculateMonthlyValue(int deviceAmount, decimal price)
        {
            //Calculating monthly insurance and setting to a string
            decimal monthOne = 0, monthTwo = 0, monthThree = 0, monthFour = 0, monthFive = 0, monthSix = 0;
            string monthlyDepreciation = "";

            monthOne = monthOne = CalculateValue(deviceAmount, price);
            monthTwo = monthOne * MonthlyRate;
            monthThree = monthTwo * MonthlyRate;
            monthFour = monthThree * MonthlyRate;
            monthFive = monthFour * MonthlyRate;
            monthSix = monthFive * MonthlyRate;

            //Generating a summary for my Monthly Depreciation.
            monthlyDepreciation += "\n========================Monthly Summary=====================";
            monthlyDepreciation += $"\nMonth 1:      {monthOne.ToString("C")}";
            monthlyDepreciation += $"\nMonth 2:      {monthTwo.ToString("C")}";
            monthlyDepreciation += $"\nMonth 3:      {monthThree.ToString("C")}";
            monthlyDepreciation += $"\nMonth 4:      {monthFour.ToString("C")}";
            monthlyDepreciation += $"\nMonth 5:      {monthFive.ToString("C")}";
            monthlyDepreciation += $"\nMonth 6:      {monthSix.ToString("C")}";

            //Putting this in my monthly method since if its ran through any other methods it runs twice and saves twice the value.
            TotalInsuranceValue += valueafterInsured;
            return monthlyDepreciation;
        }

        public static decimal CalculateMostExpensive()
        {
            //Calculating most expensive devices.

            if (valueafterInsured > MostExpensive)
            {
                MostExpensive = valueafterInsured;
            }
            
            return MostExpensive;
        }

        static string CheckName(string question)
        {
            while (true)
            {
                // Ask for input
                Console.WriteLine(question);
                string nameInput = Console.ReadLine();
                // Check if name input is alphabetic characters, numbers and spaces only.
                if (Regex.IsMatch(nameInput, @"^[A-Za-z0-9\s]+$"))
                {
                    nameInput = nameInput[0].ToString().ToUpper() + nameInput.Substring(1);
                    return nameInput;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Names can only contain alphabetic characters, spaces and numbers!");
                    Console.ResetColor();
                }

            }

        }

        static int CheckInt(string question) //Int variable crash handler.
        {
            int userInput = 0;
            while (true)
            {
                try
                {

                    Console.WriteLine(question);
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput >= 1 && userInput <= 999) 
                    { 
                        return userInput;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Please enter a number between 1 and 999");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter a number");
                    Console.ResetColor();
                }
               
            }
            
        }

        static decimal CheckDecimal(string question) //Decimal variable crash handler.
        {
            decimal decimalInput = 0.0m;
            while (true)
            {
                try
                {
                    Console.WriteLine(question);
                    decimalInput = Convert.ToDecimal(Console.ReadLine());

                    if (decimalInput >= 20 && decimalInput <= 50000) 
                    {
                        return decimalInput;
                       
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Please enter between 20 and 50000.");
                        Console.ResetColor();
                    }
                   

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter a number");
                    Console.ResetColor();
                }
                
            }

        }

        static int CheckCategory(string question) //Category choice boundary and invalids
        {
            while (true)
            {

                try
                {

                    Console.WriteLine(question);
                    int userInput = Convert.ToInt32(Console.ReadLine());

                    //check if user input is between min and max value
                    if (userInput >= 1 && userInput <= 3)
                    {
                        return userInput;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Please enter 1, 2 or 3.");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: You must enter 1, 2 or 3");
                    Console.ResetColor();
                }


            }
        }
    }
}