using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProgram
{
    public class Car
    {
        //Constructor
        private const double CostPerLitre = 1.385; //Constant
        private double fuelEfficiency;
        private double fuelInTank;
        private double totalMilesDriven;

        public Car(double fuelEfficiency)
        {
            this.fuelEfficiency = fuelEfficiency;
            fuelInTank = 0;
            totalMilesDriven = 0;
        }

        public double GetFuel() //Displays the amount of fuel left in the tank
        {
            return fuelInTank;
        }

        public double GetTotalMiles() //Displays the total amount of miles driven
        {
            return totalMilesDriven;
        }

        public void SetTotalMiles(double miles) //Updates total miles driven
        {
            totalMilesDriven += miles;
        }

        public void PrintFuelCost() //Prints fuel cost
        {
            Console.WriteLine($"Cost of fuel per litre: $" + CostPerLitre);
        }

        public void AddFuel(double gallons) //This function adds gallons of fuel to the car
        {
            double AddLitres = ConvertToLitres(gallons);
            fuelInTank += AddLitres;
            double cost = CalcCost(AddLitres);
            Console.WriteLine($"Added {gallons} gallons of fuel (cost: ${cost})");
        }

        private double CalcCost(double litres) //Calculates the cost of fuel
        {
            return litres * CostPerLitre;
        }

        private double ConvertToLitres(double gallons) //Converts gallon to litres
        {
            return gallons * 4.546;
        }

        public void Drive(double miles) //This function simulates driving the car for a certain number of miles
        {
            SetTotalMiles(miles);
            double gallonsUsed = miles / fuelEfficiency;
            double litresUsed = ConvertToLitres(gallonsUsed);
            fuelInTank = fuelInTank - litresUsed;
            double cost = CalcCost(litresUsed);
            Console.WriteLine($"You drove {miles} miles. Fuel used: {gallonsUsed:F2} gallons ({litresUsed:F2} litres). Cost: ${cost:F2}");
            //We put $ in front of the double quote to allow for a mix between text and variables
        }
    }
}
