using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Prompts the user to enter the number of items 
            Console.WriteLine("Enter the number of items: ");
            int items = Convert.ToInt32(Console.ReadLine());

            //Prompts the user to input the heating time
            Console.WriteLine("Enter the heating time (using seconds): ");
            int heating_time = Convert.ToInt32(Console.ReadLine());


            if (items <= 0 || items > 3) //If the number of items inputted are not between 1-3, an error message will appear
            {
                Console.WriteLine("Error: Enter 1 to 3 items in the microwave");
            }
            else if (heating_time <= 0) //If the heating time is 0 and below an error message will appear
            {
                Console.WriteLine("Error: Enter a time over 0");
            }
            else //If all the inputs are correct, the program will perform the calculation
            {
                double Recommended_Heating_Time = Calculate_Recommended_Heating_Time(items, heating_time);
                Console.WriteLine("Recommended Heating Time: " + Recommended_Heating_Time + " seconds");
            }

            Console.ReadLine(); //This stops the program from closing after the calculation is displayed
        }

        //This function is declared to calculate the heating time according to the number of items inputted
        private static double Calculate_Recommended_Heating_Time(int number_of_items, int single_item_heating_time) 
        //'number_of_items' and 'single_item_heating_time' both have their values passed from 'items' and 'heating_time' when the function is called
        {
            if (number_of_items == 1) 
            //If there is 1 item inputted, the function will return the value of the single_item_heating_time
            {
                return single_item_heating_time;
            }
            //If there are 2 items, the function will multiply single_item_heating_time by 1.5 and return the value
            else if (number_of_items == 2)
            {
                return single_item_heating_time * 1.5;
            }
            //If there are 3 items, the function will multiply single_item_heating_time by 2 and return the value
            else
            {
                return single_item_heating_time * 2;
            }

        }
    }
}
