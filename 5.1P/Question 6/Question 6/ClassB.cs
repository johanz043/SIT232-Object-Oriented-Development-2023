using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_6
{
    public class ClassB : ClassA
    {
        public override double Division(int j)
        {
            return (double)i / j;
        }

        public void PrintResults(int j)
        {
            Console.WriteLine("i: {0}", i);
            Console.WriteLine("Sum(j): {0}", Sum(j));
            Console.WriteLine("Product(j): {0}", Product(j));
            Console.WriteLine("Division(j): {0}", Division(j));
        }
    }
}
