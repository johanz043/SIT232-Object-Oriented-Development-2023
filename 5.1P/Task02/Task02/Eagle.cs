using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Eagle : Bird
    {
        private String species;
        private double flightAltitude;


        public Eagle(String name, String diet, String location, double weight, int age, String colour, double wingspan, String species, double flightAltitude) : base(name, diet, location, weight, age, colour, wingspan, species)
        {
            this.species = species;
            this.flightAltitude = flightAltitude;   
        }
        
        public void layEgg()
        {
            Console.WriteLine("The eagle lays an egg");
        }

        public override void fly()
        {
            Console.WriteLine("The eagle flies");
        }

        public override void makeNoise()
        {
            Console.WriteLine("Whistle");
        }

        public override void eat()
        {
            Console.WriteLine("The eagle can eat 1lb of fish");
        }

        public override void sleep()
        {
            Console.WriteLine("The eagle can sleep for 11 hours");
        }

        public override void play()
        {
            Console.WriteLine("The eagle somersaults in the air");
        }

    }
}
