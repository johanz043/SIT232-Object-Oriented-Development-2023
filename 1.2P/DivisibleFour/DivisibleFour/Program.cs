using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivisibleFour
{
    internal class Program
    {

        //We are introduced to the use of '%', which is used to calculate the remainder of division operations
        //For example:
        //10 % 3 will result in 1, because 10/3 has a remainder of 1
        //In this example, i % 4 == 0 has a remainder of 0, meaning it is divisible by 4

        static void Main(string[] args)
        {
            Console.Write("Enter a value for n: "); //Prompts the user to choose a number
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Numbers between 1 and " + n + " that are divisible by 4 but not 5 are: ");
            for (int i = 1; i <= n; i++) //The for loop will keep repeating until i = n
        //For each repetition, 'i' is incremented by 1
            {
                if (i % 4 == 0 && i % 5 != 0) 
        //For each repetition, the program check if any of the numbers fulfill both the criteria in the if statement
                {
                    Console.WriteLine(i); //If any of the numbers fit the criteria, the program lists it
                }
            }

            Console.ReadLine();
        }
    }
}
