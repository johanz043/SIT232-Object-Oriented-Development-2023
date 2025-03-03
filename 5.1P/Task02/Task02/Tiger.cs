using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Tiger : Feline
    {
        private String colourStripes;

        public Tiger(String name, String diet, String location, double weight, int age, String colour, String species, String colourStripes) : base(name, diet, location, weight, age, colour, species)
        {
            this.colourStripes = colourStripes;
        }

        public override void makeNoise()
        {
            Console.WriteLine("Growl");
        }

        public override void eat()
        {
            Console.WriteLine("The tiger can eat 20lbs of meat");
        }

        /**
        public override void sleep()
        {
            Console.WriteLine("The tiger can sleep for 12 hours");
        }
        **/

        public override void play()
        {
            Console.WriteLine("The tiger climbs a tree");
        }
    }

}
