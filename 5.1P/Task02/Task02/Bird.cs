using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class Bird : Animal
    {
        private double wingspan;
        private String species;

        public Bird(string name, string diet, string location, double weight, int age, string colour, double wingspan, string species) : base(name, diet, location, weight, age, colour)
        {
            this.wingspan = wingspan;
            this.species = species;
        }

        public virtual void fly()
        {
            Console.WriteLine("The bird flies");
        }


    }
}
