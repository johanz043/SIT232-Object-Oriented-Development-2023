using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class ZooPark
    {
        static void Main(string[] args)
        {
            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "White");
            Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 15, "Black", 180, "Harpy", 98.5);
            Lion leoLion = new Lion("Leo the Lion", "Meat", "Savannah", 120, 10, "Brownish Orange", "Panthera Leo");
            Penguin pennyPenguin = new Penguin("Penny the Penguin", "Fish", "Antartica", 35, 11, "Black and White", 76, "Emperor");

            tonyTiger.makeNoise();
            williamWolf.makeNoise();
            edgarEagle.makeNoise(); 
            leoLion.makeNoise();    

            Animal baseAnimal = new Animal("Animal Name", "Animal Diet", "Animal Location", 0.0, 0, "Animal Colour");
            baseAnimal.makeNoise();

            Console.WriteLine();

            tonyTiger.eat();
            williamWolf.eat();
            edgarEagle.eat();
            leoLion.eat();
            pennyPenguin.eat();
            baseAnimal.eat();

            Console.WriteLine();

            tonyTiger.sleep();
            williamWolf.sleep();    
            edgarEagle.sleep();
            leoLion.sleep();
            pennyPenguin.sleep();
            baseAnimal.sleep();

            Console.WriteLine();

            tonyTiger.play();
            williamWolf.play();
            edgarEagle.play(); 
            leoLion.play();
            pennyPenguin.play();
            baseAnimal.play();

            Console.WriteLine();

            edgarEagle.fly();
            pennyPenguin.fly();

            Console.WriteLine();

            edgarEagle.layEgg();



            Console.ReadLine();
        }

 
    }
}
