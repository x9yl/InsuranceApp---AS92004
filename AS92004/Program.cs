using System.Security.Cryptography.X509Certificates;

namespace AS92004
{
    internal class Program
    {
        //Declaring my Constant Variables for the Program. This includes device prices, insurance rate, category type, monthlyRate
        public static int deviceAmount = 0;
        public static decimal insuranceRate = 0.9m, monthlyRate = 0.95m;
        public static int laptop = 1, desktop = 2, other = 3, EX2Price = 499, ASUSPrice = 725, XPPrice = 350, S23Price = 799, deviceType = 0;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" /$$$$$$                                                                                       /$$$$$$                     \r\n|_  $$_/                                                                                      /$$__  $$                    \r\n  | $$   /$$$$$$$   /$$$$$$$ /$$   /$$  /$$$$$$  /$$$$$$  /$$$$$$$   /$$$$$$$  /$$$$$$       | $$  \\ $$  /$$$$$$   /$$$$$$ \r\n  | $$  | $$__  $$ /$$_____/| $$  | $$ /$$__  $$|____  $$| $$__  $$ /$$_____/ /$$__  $$      | $$$$$$$$ /$$__  $$ /$$__  $$\r\n  | $$  | $$  \\ $$|  $$$$$$ | $$  | $$| $$  \\__/ /$$$$$$$| $$  \\ $$| $$      | $$$$$$$$      | $$__  $$| $$  \\ $$| $$  \\ $$\r\n  | $$  | $$  | $$ \\____  $$| $$  | $$| $$      /$$__  $$| $$  | $$| $$      | $$_____/      | $$  | $$| $$  | $$| $$  | $$\r\n /$$$$$$| $$  | $$ /$$$$$$$/|  $$$$$$/| $$     |  $$$$$$$| $$  | $$|  $$$$$$$|  $$$$$$$      | $$  | $$| $$$$$$$/| $$$$$$$/\r\n|______/|__/  |__/|_______/  \\______/ |__/      \\_______/|__/  |__/ \\_______/ \\_______/      |__/  |__/| $$____/ | $$____/ \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       | $$      | $$      \r\n                                                                                                       |__/      |__/      ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("!!This program is for educational use only!!");




            //summary
        }
        public static string OneDevice(int deviceAmount, int deviceType)
        {
            //Declaring Local variables for OneDevice
            string onedeviceOutput = "";
            string displaydeviceType = "";
            //capture device type
            Console.WriteLine("\n\nWhich device would you like to calculate? \n(1. EX2\n(2. ASUS\n(3. XP\n(4. S23");
            deviceType = (Convert.ToInt32(Console.ReadLine()));

            //Calculate deviceType into a string, I thought using a list select would be easier since there is room for less human error.
            switch (deviceType)
            {
                case 1:
                    displaydeviceType = "EX2";
                    break;

                case 2:
                    displaydeviceType = "ASUS";
                    break;

                case 3:
                    displaydeviceType = "XP";
                    break;

                case 4:
                    displaydeviceType = "S23";
                    break;
                    //I used default for invalid cases.
                default:
                    Console.WriteLine("Invalid device choice. Please input a listed number");
                    break;
            }

            //Capture Device amount
            Console.WriteLine("\nHow many of these are you wanting to calculate?");
            deviceAmount = (Convert.ToInt32(Console.ReadLine()));

            //Calculate number of devices in each category


            return onedeviceOutput;
        }
        public static int CalculateCost(int deviceAmount, string displaydeviceType, int EX2Price, int XPPrice, int S23Price, int ASUSPrice)
        {
            //local variables
            int cost = 0;

            //Calculate cost
            switch (displaydeviceType)
            {
                case "EX2":
                    cost = deviceAmount * EX2Price;
                    break;

                case "XP":
                    cost = deviceAmount * XPPrice;
                    break;

                case "S23":
                    cost = deviceAmount * S23Price;
                    break;

                case "ASUS":
                    cost = deviceAmount * ASUSPrice;
                    break;
            }

            return cost;
        }


        public static decimal CalculateValue(int cost, int deviceAmount)
        {

        }
        public static decimal CalculateInsurance()
        {

        }
        public static string GenerateOutput()
        {

        }
    }
}