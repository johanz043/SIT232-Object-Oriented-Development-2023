using Bank_Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankSystem
{

    public class BankSystem
    {

        private enum MenuOption //Enum
        {
            Withdraw = 0,
            Deposit = 1,
            Transfer = 2,
            Print = 3,
            Quit = 4
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
                    Console.WriteLine("2. Transfer");
                    Console.WriteLine("3. Print");
                    Console.WriteLine("4. Quit");

                    choice = Convert.ToInt32(Console.ReadLine()); //Reads the user's inputted choice

                    if (choice < 0 || choice > 4) //Input validation
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

            } while (choice != 5); //The do..while loop will continue until 3 is selected
            return MenuOption.Quit;
        }


        public static void DoDeposit(DepositTransaction deposit) //Allows the user to deposit a certain amount
        {
            Console.Write("Enter amount to deposit: "); //Prompts the user to enter a deposit amount
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine()); 
            deposit.Execute();

        }

        public static void DoWithdraw(Account account) //Allows the user to withdraw a certain amount
        {
            Console.Write("Enter amount to withdraw: "); //Prompts the user to enter a withdraw amount
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(withdrawAmount); //Calls the withdraw method from the account class

            DoPrint(account);

        }

        public static void DoTransfer(Account account1, Account account2) //Allows the user to transfer money from account1 to account2
        {
            Console.Write("Enter amount to transfer: "); //Prompts the user to enter the amount to transfer
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

            TransferTransaction transferTransaction = new TransferTransaction(account1, account2, transferAmount);

            transferTransaction.Execute(transferAmount); //Calls on the Execute function in the TransferTransaction class
        }

        //Im not sure how to properly implement the rollback function (we weren't told to create this function but I don't know how else to use rollback)
        //This doesnt work
        public static void Rollback(Account myAccount, DepositTransaction deposit, WithdrawTransaction withdraw, TransferTransaction transfer)
        {
            deposit.Rollback();
            withdraw.Rollback();
            transfer.Rollback();
        }

        public static void DoPrint(Account account)
        {
            account.Print(); //Prints the user details
        }


        public static void Main(string[] args)
        {
            //Creates two accounts, in this program we will primarily work with myAccount (John's account), we will only use myAccount2 for transferring
            Account myAccount = new Account("John", 1000);
            Account myAccount2 = new Account("Jenny", 2000);

            myAccount.Print();
            myAccount2.Print();

            while (true)
            {
                MenuOption option = ReadUserOption(); //The option selected in the followinbg switch case depends on the value ReadUserOption() returns

                switch (option)
                {
                    case MenuOption.Withdraw: //If 0 is selected, the program will call on the Withdraw function
                        DoWithdraw(myAccount);
                        break;
                    case MenuOption.Deposit: //If 1 is selected, the program will call on the Deposit function
                        //DoDeposit(myAccount);
                        break;
                    case MenuOption.Transfer: //If 2 is seleceted, the program will call on the Transfer function
                         DoTransfer(myAccount, myAccount2);
                        break;
                    case MenuOption.Print: //If 4 is selected, the program will call on the Print function
                        DoPrint(myAccount);
                        DoPrint(myAccount2);
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
