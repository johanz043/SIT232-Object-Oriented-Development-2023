using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overloading
{
    internal class Overloading
    {
        static void Main(string[] args)
        {
            methodToBeOverloaded("John");

            Console.WriteLine();

            methodToBeOverloaded("John", 10);

            Console.ReadLine();
        }

        public static void methodToBeOverloaded(String name)
        {
            Console.WriteLine("Name: " + name);
        }

        public static void methodToBeOverloaded(String name, int age)
        {
            Console.WriteLine("Name: " + name + "\nAge: " + age);
        }


    }
}
