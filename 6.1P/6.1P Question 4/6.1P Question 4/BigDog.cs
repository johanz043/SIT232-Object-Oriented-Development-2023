using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1P_Question_4
{
    public class BigDog : Dog
    {
        override public void Greeting()
        {
            Console.WriteLine("BigDog: Woow!");
        }
        new public void Greeting(Dog another)
        {
            Console.WriteLine("Woooooowwwww!");
        }
    }
}
