using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number (as an integer)");
            int number = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (number == 1)
                {
                    Console.WriteLine("ONE");
                }
                else if (number == 2)
                {
                    Console.WriteLine("TWO");
                }
                else if (number == 3)
                {
                    Console.WriteLine("THREE");
                }
                else if (number == 4)
                {
                    Console.WriteLine("FOUR");
                }
                else if (number == 5)
                {
                    Console.WriteLine("FIVE");
                }
                else if (number == 6)
                {
                    Console.WriteLine("SIX");
                }
                else if (number == 7)
                {
                    Console.WriteLine("SEVEN");
                }
                else if (number == 8)
                {
                    Console.WriteLine("EIGTH");
                }
                else if (number == 9)
                {
                    Console.WriteLine("NINE");
                }
                else
                {
                    Console.WriteLine("Enter a number between 1 and 9");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: You must enter a number between 1 and 9");
            }



            Console.ReadLine();
        }
    }
}
