using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDate
{
    class TestMyDate
    {
        static void Main(string[] args)
        {

            MyDate date = new MyDate(25, 12, 2023);
            Console.WriteLine(date);

            
            Console.WriteLine("Today's Day: " + date.GetDay());
            Console.WriteLine("Today's Month: " + date.GetMonth());
            Console.WriteLine("Today's Year: " + date.GetYear());
            Console.WriteLine();



            date.SetDay(25);
            date.SetMonth(12);
            date.SetYear(2023);
            Console.WriteLine($"Updated date is: {date.ToString()} \n");


            date.NextDay();
            Console.WriteLine($"Next day: {date.ToString()} \n");


            date.NextMonth();
            Console.WriteLine($"Next month: {date.ToString()} \n");

            
            date.NextYear();
            Console.WriteLine($"Next year: {date.ToString()} \n");

            
            
            date.PreviousDay();
            Console.WriteLine($"Previous day: {date.ToString()} \n");

            
            date.PreviousMonth();
            Console.WriteLine($"Previous month: {date.ToString()} \n");

            
            date.PreviousYear();
            Console.WriteLine($"Previous year: {date.ToString()} \n");

            //Validating invalid dates
            Console.WriteLine("Setting an invalid date.");
            try
            {
                date.SetDay(111);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                date.SetMonth(111);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            try
            {
                date.SetYear(1111111);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }
    }
}
