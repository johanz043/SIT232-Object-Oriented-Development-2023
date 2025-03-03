using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repetition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            double average;

            Console.WriteLine("Enter upperbound: ");
            int upperbound = Convert.ToInt32(Console.ReadLine());


            // for (int number = 1; number <= upperbound; number++)
            //  {
            //     sum += number;
            // }


            //  int number = 1;
            //  while (number <= upperbound)
            // {
            //   sum += number;
            // number++;
            // }


            int number = 1;
            do
            {
                sum += number;
                number++;   
            }
            while (number <= upperbound);   



            average = (double)sum / upperbound;

            Console.WriteLine("The sum is: " + sum);

            Console.WriteLine("The average is: " + average);

            Console.ReadKey();
        }
    }
}
// The For loop executes a code repeatedly until a specified condition is no longer true. It is usually used for when the number of iterations is known beforehand
// The While loop executes a code as long as a specified condition is true. It is usually used when the number of iterations is uncertain.
// The Do...While loop executes a block of code before checking the loop condition, making sure the code is executed at least once, even if the condition is false
