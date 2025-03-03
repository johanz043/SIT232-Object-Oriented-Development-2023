using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProgram
{
    class CarProgram
    {
        static void Main(string[] args)
        {
            Car car = new Car(30); //30 is the fuel efficiency measured by miles per gallon

            // Test the methods
            car.PrintFuelCost();
            car.AddFuel(10); // Add gallons of fuel
            car.Drive(150); // Drive for a certain number of miles
            car.AddFuel(5); 
            car.Drive(100); 

            // Display final stats
            Console.WriteLine($"Current fuel level: {car.GetFuel():F2} litres");
            Console.WriteLine($"Total miles driven: {car.GetTotalMiles():F2} miles");
            //The "F2" function rounds double values to 2 decimal places

            Console.ReadLine();
        }
    }
}
