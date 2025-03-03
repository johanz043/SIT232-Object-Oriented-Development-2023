using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = 0; //The number is initially set to 0 (out of the 1-10 range) so the subsequent 'while' statement will be implemented

            while (number < 1 || number > 10) //If the number inputted is not within the 1-10 range, the program will keep prompting the user
            {
                try
                {
                    Console.WriteLine("Select a number between 1 and 10"); //Prompts the user to select a number
                    number = Convert.ToInt32(Console.ReadLine()); //The program reads the user input and assigns it to the 'number' variable

                    if (number < 1 || number > 10) //If the number inputted is less than 1 or more than 10 the program will prompt the user to input a number again
                    {
                        Console.WriteLine("Try again"); 
                    }
                    else
                    {
                        Console.WriteLine(number + " is selected"); //If the input is valid, the program will display a message confirming the number's selection
                    }
                }
                catch (FormatException) //Used to validate inputs, such as letters
                {
                    Console.WriteLine("Invalid input: Input numbers between 1 and 10");
                }
            }
            


            int guess = 0; //guess is initially set to 0 (out of the 1-10 range) so that the subsequent 'while' statement will not be triggered

            while (guess != number) //As long as the guess is not the same as the selected number, the 'while' statement will keep repeating
            {
                try
                {
                    Console.WriteLine("Guess a number between 1 and 10"); //Prompts the user to guess the number
                    guess = Convert.ToInt32(Console.ReadLine()); //The program reads the user input and assigns it to the 'guess' variable

                    if (guess > 10 || guess < 1) //The program will only allow inputs of between 1-10
                    {
                        Console.WriteLine("Invalid input. Try again");
                    }
                    else if (guess > number) //If the guess is lower than the number, the program will tell the user to 'guess lower'
                    {
                        Console.WriteLine("Guess lower");
                    }
                    else if (guess < number) //If the guess is higher than the number, the program will tell the user to 'guess higher'
                    {
                        Console.WriteLine("Guess higher");
                    }
                    else if (guess == number) //If the guess mathces the number, the program will display 'correct' and the while loop will end
                    {
                        Console.WriteLine("Correct");
                    }
                }
                catch (FormatException) //Used to validate inputs, such as letters
                {
                    Console.WriteLine("Invalid input: Input numbers between 1 and 10");
                }

            }
            

            Console.ReadLine();
        }
    }
}
