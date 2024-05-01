//imports

using System.Diagnostics;

namespace InternalNumberOne
{
    internal class Program
    {
        //Global Variables
        static List<string> category = new List<string>()
        {
                "Desktop", "Laptop", "Phone/drone"
        };
        static int catOneCounter, catTwoCounter, catThreeCounter, totalDeviceCounter = 0;

        // Methods and functions

        static string checkProceed()
        {
            while (true)
            {
                Console.WriteLine("Press <Enter> to add another employee or type 'X' to exit");
                string checkProceed = Console.ReadLine();

                checkProceed = checkProceed.ToUpper();

                if (checkProceed.Equals("") || checkProceed.Equals("X"))
                {
                    return checkProceed;
                }
            }
        }
        static string GenerateMenu()
        {

            string menu = $"Select the device category:\n";
            for (int index = 0; index < category.Count; index++)
            {
                menu += $"{index + 1}. {category[index]}\n";
            }
            return menu;
        }


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
                deviceInsurance = (numofdevice - 5) * cost * 0.9f;
                deviceInsurance += 5 * cost;

            }
            
            return deviceInsurance;
        }




        static void OneDevice()
        {
            //User picks a category
            Console.WriteLine(GenerateMenu());
            int deviceCategory = Convert.ToInt32(Console.ReadLine());
            //User enters device name
            Console.WriteLine("\nPlease enter the name of the device:");
            string deviceName = Console.ReadLine();
            //User enters device cost
            Console.WriteLine("\nPlease enter the cost of the device:");
            float deviceCost = (float)Convert.ToDecimal(Console.ReadLine());
            //User enters how many devices they want insured
            Console.WriteLine("\nHow many devices do you want to insure?");
            int numOfDevice = Convert.ToInt32(Console.ReadLine());
            //Check how many devices are in the category
            if (deviceCategory.Equals (1))
            {
                catOneCounter += numOfDevice;
            }
            else if (deviceCategory.Equals (2))
            {
                catTwoCounter += numOfDevice;
            }
            else if (deviceCategory.Equals(3))
            {

            catThreeCounter += numOfDevice;
            }
            totalDeviceCounter = totalDeviceCounter + numOfDevice;
            float deviceInsurance = InsureDevice(numOfDevice, deviceCost);
            float valueLoss = deviceCost;

            Console.WriteLine($"Total insurance cost for {numOfDevice}x {deviceName} devices: ${deviceInsurance}");

            Console.WriteLine($"Month\tValue Loss");

            for (int month =0; month < 6; month++)
            {
                valueLoss = valueLoss * 0.95f;
                Console.WriteLine($"{month + 1}:\t{float.Round(valueLoss, 2)}");


            }
            Console.WriteLine($"Category: {deviceCategory}");

        }
        



        //Main process / When run...
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n    ____            _              ____                                          \r\n   / __ \\___ _   __(_)_______     /  _/___  _______  ___________ _____  ________ \r\n  / / / / _ \\ | / / / ___/ _ \\    / // __ \\/ ___/ / / / ___/ __ `/ __ \\/ ___/ _ \\\r\n / /_/ /  __/ |/ / / /__/  __/  _/ // / / (__  ) /_/ / /  / /_/ / / / / /__/  __/\r\n/_____/\\___/|___/_/\\___/\\___/  /___/_/ /_/____/\\____/_/   \\____/_/ /_/\\___/\\___/ \r\n                                                                                 \r\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to Insurance App!");
            
            string proceed = "";
            
            while (proceed.Equals (""))
            {
                OneDevice();
                proceed = checkProceed();

            }
            Console.WriteLine($"Total number of Desktops: {catOneCounter}");
            Console.WriteLine($"Total number of Laptops: {catThreeCounter}");
            Console.WriteLine($"Total number of Phones/drones: {catThreeCounter}");
            Console.WriteLine($"Total number of devices: {totalDeviceCounter}");
        }
    }
}
