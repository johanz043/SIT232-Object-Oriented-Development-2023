using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SwitchStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number (as an integer): ");
            string input = Console.ReadLine();

            try
            {
                int number = Convert.ToInt32(input);

                switch (number)
                {
                    case 1: Console.WriteLine("One"); break;
                    //We use breaks so that the program won't continue to execute the subsequent cases
                    case 2: Console.WriteLine("Two"); break;
                    case 3: Console.WriteLine("Three"); break;
                    case 4: Console.WriteLine("Four"); break;
                    case 5: Console.WriteLine("Five"); break;
                    case 6: Console.WriteLine("Six"); break;
                    case 7: Console.WriteLine("Seven"); break;
                    case 8: Console.WriteLine("Eight"); break;
                    case 9: Console.WriteLine("Nine"); break;

                    default: Console.WriteLine("Error: you must enter an integer between 1 and 9"); break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Error: You must enter a number between 1 and 9");
            }

            Console.ReadLine();
        }
    }
}
