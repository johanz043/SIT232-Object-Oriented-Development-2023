using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class Penguin : Bird
    {
        public Penguin(string name, string diet, string location, double weight, int age, string colour, double wingspan, string species) : base(name, diet, location, weight, age, colour, wingspan, species)
        {

        }

        public override void makeNoise()
        {
            Console.WriteLine("Toot toot");
        }

        public override void eat()
        {
            Console.WriteLine("The penguin can eat 10lb of fish");
        }

        public override void sleep()
        {
            Console.WriteLine("The penguin can sleep for 12 hours");
        }

        public override void play()
        {
            Console.WriteLine("The penguin dives in the water");
        }

        public override void fly()
        {
            Console.WriteLine("The penguin can't fly");
        }


    }
}
