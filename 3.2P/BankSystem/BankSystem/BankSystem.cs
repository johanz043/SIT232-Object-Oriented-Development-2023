using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankSystem
{

    internal class BankSystem
    {

        private enum MenuOption //Enum
        {
            Withdraw = 0,
            Deposit = 1,
            Print = 2,
            Quit = 3
        }

        private static MenuOption ReadUserOption()
        {
            int choice = -1;

            do
            {
                try
                {
                    //Allows the user to select a choice
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("0. Withdraw");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Print");
                    Console.WriteLine("3. Quit");

                    choice = Convert.ToInt32(Console.ReadLine()); //Reads the user's inputted choice

                    if (choice < 0 || choice > 3) //Input validation
                    {
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                    }
                    else
                    {
                        return (MenuOption)choice; //If user inputs a valid option, the program will return choice
                    }
                }
                catch (FormatException) //Used to validate inputs, such as letters
                {
                    Console.WriteLine("Invalid input: Input numbers between 0 and 3");
                }

            } while (choice != 3); //The do..while loop will continue until 3 is selected
            return MenuOption.Quit;
        }

        private static void DoDeposit(Account account) //Allows the user to deposit a certain amount
        {
            Console.Write("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            Boolean result = account.Deposit(depositAmount);
            if (result == true)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("");
            }
            
        }

        private static void DoWithdraw(Account account) //Allows the user to withdraw a certain amount
        {
            Console.Write("Enter amount to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(withdrawAmount);
        }

        private static void DoPrint(Account account)
        {
            account.Print(); //Prints the user details
        }


        static void Main(string[] args)
        {
            Account myAccount = new Account("Johanz Te", 1000);

            myAccount.Print();

            while (true)
            {
                MenuOption option = ReadUserOption(); //The option selected in the followinbg switch case depends on the value ReadUserOption() returns

                switch (option)
                {
                    case MenuOption.Withdraw: //If 0 is selected, the program will call on the Withdraw function
                        DoWithdraw(myAccount);
                        break;

                    case MenuOption.Deposit: //If 1 is selected, the program will call on the Deposit function
                        DoDeposit(myAccount);
                        break;

                    case MenuOption.Print: //If 2 is selected, the program will call on the Print function
                        DoPrint(myAccount);
                        break;

                    case MenuOption.Quit:
                        Console.WriteLine("Goodbye!");
                        return;
                }
                Console.ReadLine();
            }
        }
    }
}
