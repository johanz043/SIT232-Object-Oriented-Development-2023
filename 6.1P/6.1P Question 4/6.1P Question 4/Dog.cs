using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1P_Question_4
{
    public class Dog : Animal
    {
        override public void Greeting()
        {
            Console.WriteLine("Dog: Woof!");
        }
        public void Greeting(Dog another)
        {
            Console.WriteLine("Dog: Woooooooooof!");
        }
    }
}
