//imports

using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace InternalNumberOne
{
    internal class Program
    {
        //Global Variables
        readonly static List<string> CATEGORY = new List<string>()
        {
                "Desktop", "Laptop", "Phone/drone"
        };
        static int catOneCounter, catTwoCounter, catThreeCounter, totalDeviceCounter = 0;
        static float totalInsurance, mostExpensiveDevice = 0;
        static string topDeviceName = "";

        // Methods and functions

        //Checks if the user wants to continue using the app
        static string CheckProceed()
        {
            //A method checking if the user wants to continue using the program
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press <Enter> to add another employee or type 'X' to exit");
                Console.ForegroundColor= ConsoleColor.White;
                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X"))
                {
                    return checkProceed;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Please press <Enter> or X");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        //Generates the menu using the specified list
        static string GenerateMenu(string menuType, List<string> listData)
        {


            string menu = $"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                            $"Select the {menuType}:\n";

            for (int loop = 0; loop < listData.Count; loop++)
            {
                menu += $"{loop + 1}. {listData[loop]}\n";
            }

            return menu;

        }

        //Checks the users choice for the menu and stores it
        static int MenuChoice(string menuType, List<string> listData)
        {

            string menu = GenerateMenu(menuType, listData);

            return CheckInt(menu, 1, listData.Count) - 1;
        }

        //Checks all float vairables for boundary and invald data
        static float CheckFloat(string question, float min, float max)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    float userfloat = (float)Convert.ToDecimal(Console.ReadLine());

                    if (userfloat >= min && userfloat <= max)
                    {
                        return userfloat;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter a number between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }

        //Insurance for the devices
        static float InsureDevice(float numofdevice, float cost)
            {
                float deviceInsurance = 0;

                if (numofdevice < 6)
                {
                    //Calculate the insurance price before discount
                    deviceInsurance = numofdevice * cost;
                }
                else
                {
                    //Calculating the price with discount
                    deviceInsurance = (numofdevice - 5) * cost * 0.9f;
                    deviceInsurance += 5 * cost;

                }

                return deviceInsurance;
            }

        //Checks Int vairables for boundary and Invalid data
        static int CheckInt(string question, int min, int max)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine(question);

                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"ERROR: You must enter an integer between {min} and {max}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: You must enter a number!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                
            }


        }

        //Checks string vairables for boundary and invalid adata
        static string CheckName()
        {
            while (true)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                    "Enter the device name:");

                string name = Console.ReadLine();

                if (!name.Equals(""))
                {
                    name = name[0].ToString().ToUpper() + name.Substring(1);

                    return name;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: You must enter a name");
                Console.ForegroundColor= ConsoleColor.White;
            }

        }

        //Collects device data and calculates insurance, value loss and print summary
        static void OneDevice()
        {
            //User picks a category
            int deviceCategory = MenuChoice("category", CATEGORY);
            //User enters device name
            string deviceName = CheckName();
            //User enters device cost
            float deviceCost = CheckFloat("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                                            "Please enter the cost of the device:", 0, 10000);
            //User enters how many devices they want insured
            int numOfDevice = CheckInt("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                "How many devices do you want to insure?", 0, 150);
            //Save how many devices are in a category
            if (deviceCategory.Equals (0))
            {
                catOneCounter += numOfDevice;
            }
            else if (deviceCategory.Equals (1))
            {
                catTwoCounter += numOfDevice;
            }
            else if(deviceCategory.Equals (2))
            {
                catThreeCounter += numOfDevice;
            }
            totalDeviceCounter = totalDeviceCounter + numOfDevice;
            //Calculates the total value lost over a 6 month period
            float deviceInsurance = InsureDevice(numOfDevice, deviceCost);
            float valueLoss = deviceCost;

            Console.WriteLine($"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n" +
                $"Total insurance cost for {numOfDevice}x {deviceName} devices: ${deviceInsurance}");

            Console.WriteLine($"Month\tValue Loss");

            for (int month = 0; month < 6; month++)
            {
                valueLoss = valueLoss * 0.95f;
                Console.WriteLine($"{month + 1}:\t{float.Round(valueLoss, 2)}");


            }
            //Display what category of deivce the user chose
            Console.WriteLine($"Category: {CATEGORY[deviceCategory]}\n" +
                $"$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\n");
            //Storing the most expensive devices price and name
            if ( mostExpensiveDevice < deviceCost )
            {
                mostExpensiveDevice = deviceCost;
                topDeviceName = deviceName;

            }

        }

        //Main process / When run...
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n    ____            _              ____                                          \r\n   / __ \\___ _   __(_)_______     /  _/___  _______  ___________ _____  ________ \r\n  / / / / _ \\ | / / / ___/ _ \\    / // __ \\/ ___/ / / / ___/ __ `/ __ \\/ ___/ _ \\\r\n / /_/ /  __/ |/ / / /__/  __/  _/ // / / (__  ) /_/ / /  / /_/ / / / / /__/  __/\r\n/_____/\\___/|___/_/\\___/\\___/  /___/_/ /_/____/\\____/_/   \\____/_/ /_/\\___/\\___/ \r\n                                                                                 \r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Insurance App!");

            string proceed = "";

            while (proceed.Equals(""))
            {
                OneDevice();
                proceed = CheckProceed();


            }
            //Summative information 
            Console.WriteLine($"*****************************************\n" +
                $"Total number of Desktops: {catOneCounter}");
            Console.WriteLine($"Total number of Laptops: {catTwoCounter}");
            Console.WriteLine($"Total number of Phones/drones: {catThreeCounter}");
            Console.WriteLine($"Total number of devices: {totalDeviceCounter}");
            Console.WriteLine($"Most expensive device: {topDeviceName} at ${mostExpensiveDevice}\n" +
                $"*****************************************");
        }
    }
}