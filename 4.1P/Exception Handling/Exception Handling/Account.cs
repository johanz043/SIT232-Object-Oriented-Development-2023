using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_Handling
{
    class Account
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Balance { get; private set; }

        public Account(string firstName, string lastName, int balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient fund");
            }
            Balance = Balance - amount;
        }
    }


    class Program
    {
        public static void Main()
        {
            try
            {
                //InvalidOperationException
                Account account = new Account("Sergey", "P", 100);
                account.Withdraw(1000);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("InvalidOperationException");
            }

            //Does not work
            /**
            try
            {
                // NullReferenceException
                Account nullAccount = null;
                nullAccount.Withdraw(50);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("NullReferenceException");
            }
            **/

            try
            {
                //FormatException
                int invalidBalance = Convert.ToInt32("not_an_integer");
            }
            catch (FormatException)
            {
                Console.WriteLine("FormatException");
            }

            try
            {
                //DivideByZeroException
                //The program will display build errors and will not execute if I put zero
                int result = 10 / 1;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("DivideByZeroException");
            }

            try
            {
                //OverflowException
                int maxValue = int.MaxValue;
                int incrementedValue = checked(maxValue + 1);
            }
            catch (OverflowException)
            {
                Console.WriteLine("OverflowException");
            }


            //Does not work either
            try
            {
                //ArgumentException
                Account invalidAccount = null;
                invalidAccount = new Account("", "Hi", 100);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }

            try
            {
                // IndexOutOfRangeException
                int[] numbers = { 1, 2, 3 }; //Three numbers in the array
                int value = numbers[10]; // Accessing an index that is out of range (10)
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("IndexOutOfRangeException");
            }


            Console.ReadLine();
        }
    }
}
