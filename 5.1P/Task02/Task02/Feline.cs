using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class Feline : Animal
    {
        private String species;

        public Feline(String name, String diet, String location, double weight, int age, String colour, String species) : base(name, diet, location, weight, age, colour)
        {
            this.species = species;
        }

        public override void sleep()
        {
            Console.WriteLine("The feline can sleep for 12 hours");
        }
    }
}
