using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Wolf : Animal
    {
        public Wolf(String name, String diet, String location, double weight, int age, String colour) : base(name, diet, location, weight, age, colour)
        {

        }

        public override void makeNoise()
        {
            Console.WriteLine("Howl");
        }

        public override void eat()
        {
            Console.WriteLine("The wolf can eat 10lbs of meat");
        }

        public override void sleep()
        {
            Console.WriteLine("The wolf can sleep for 10 hours");
        }

        public override void play()
        {
            Console.WriteLine("The wolf runs around");
        }

    }


}
