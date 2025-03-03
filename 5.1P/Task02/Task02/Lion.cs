using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class Lion : Feline
    {
        public Lion(string name, string diet, string location, double weight, int age, string colour, string species) : base(name, diet, location, weight, age, colour, species)
        {

        }

        public override void makeNoise()
        {
            Console.WriteLine("Roar");
        }

        public override void eat()
        {
            Console.WriteLine("The lion can eat 25lbs of meat");
        }

        /**
        public override void sleep()
        {
            Console.WriteLine("The lion can sleep for 12 hours");
        }
        **/

        public override void play()
        {
            Console.WriteLine("The lion rolls around");
        }

    }
}
