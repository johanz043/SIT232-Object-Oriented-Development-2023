using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._1P_Question_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using the subclasses
            Cat cat1 = new Cat();
            cat1.Greeting(); // Error 1: Method name should start with an uppercase 'G'

            Dog dog1 = new Dog();
            dog1.Greeting(); // Error 2: Method name should start with an uppercase 'G'

            BigDog bigDog1 = new BigDog();
            bigDog1.Greeting(); // Error 3: Method name should start with an uppercase 'G'

            // Using Polymorphism
            Animal animal1 = new Cat();
            animal1.Greeting();

            Animal animal2 = new Dog();
            animal2.Greeting();

            Animal animal3 = new BigDog();
            animal3.Greeting();

            // Error 4: Cannot create an instance of an abstract class 'Animal'
            // Animal animal4 = new Animal();

            // Downcast
            Dog dog2 = (Dog)animal2;
            BigDog bigDog2 = (BigDog)animal3;

            // Error 5: animal3 is of type BigDog, cannot cast directly to Dog
            // Dog dog3 = (Dog)animal3;

            // Error 6: animal2 is of type Dog, cannot cast directly to Cat
            // Cat cat2 = (Cat)animal2;

           // dog2.Greeting(dog2); // Error 7: No such method 'Greeting(Dog)' in Dog class

            dog2.Greeting(dog2);
            bigDog2.Greeting(bigDog2);
            bigDog1.Greeting(bigDog1);

            

            Console.ReadLine(); 
        }
    }
}
