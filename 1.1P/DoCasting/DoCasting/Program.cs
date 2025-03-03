using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoCasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 17;
            int count = 5;

            int intAverage = sum / count;
            Console.WriteLine("Integer Average (intAverage): " + intAverage);

            //Although doubleAverage is declared as a double, both sum and count are integers
            //Therefore it will return the integer 3 as a result
            double doubleAverage = sum / count;
            Console.WriteLine("Incorrect Double Average (doubleAverage): " + doubleAverage);

            //DoubleAverage has already been declared as a double, so we don't have to declare it again
            //Since sum is declared as a double, the program will calculate 17.0 / 5
            //This means the program will return the double 3.4
            doubleAverage = (double)sum / count;
            Console.WriteLine("Correct Double Average (doubleAverage): " + doubleAverage);

            Console.ReadLine();
        }
    }

    //IN ORDER TO CALCULATE A DOUBLE, AT LEAST ONE OF THE INPUTS HAS TO BE A DOUBLE AS WELL
}
