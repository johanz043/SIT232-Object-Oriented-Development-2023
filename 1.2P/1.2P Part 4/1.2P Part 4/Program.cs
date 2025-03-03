using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2P_Part_4
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int sum = 0;
            for (int j = -5; sum <= 350; j += 5)
            {
                sum += j;
            }

            Console.WriteLine("sum: " + sum);
            

            Console.ReadLine();       
        }
    }
}
