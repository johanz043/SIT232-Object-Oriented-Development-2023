using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ZooPark
{
    internal class ZooPark
    {
        static void Main(string[] args)
        {
            Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 11, 6, "Orange and White");
            Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black");
        }

        public void eat()
        {

        }

        public void sleep()
        {

        }

        public void makeNoise()
        {

        }
    }
}
