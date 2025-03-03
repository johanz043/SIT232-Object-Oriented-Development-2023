using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    class BankSystem
    {
        //Enum defining menu options
        public enum MenuOption
        {
            AddAccount = 0,
            Deposit = 1,
            Withdraw = 2,
            Transfer = 3,
            Print = 4,
            Transactions = 5,
            Quit = 6
        }

        //Displays the options
        private static MenuOption ReadUserOption()
        {
            //Declares choice as integer (-1 is arbitrary because without it the program will display errors)
            int choice = -1;

            do
            {
                try
                {
                    //Allows the user to select a choice
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("0. Add account");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Transfer");
                    Console.WriteLine("4. Print");
                    Console.WriteLine("5. Transaction history");
                    Console.WriteLine("6. Quit");

                    Console.Write("Select an option: ");

                    choice = Convert.ToInt32(Console.ReadLine()); //Reads the user's inputted choice

                    if (choice < 0 || choice > 5) //Input validation
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

            } while (choice != 4); //The do..while loop will continue until 3 is selected
            return MenuOption.Quit;
        }



        static void Main(string[] args)
        {
            string name;
            decimal balance;
            Bank bank = new Bank();

            while (true)
            {

                MenuOption option = ReadUserOption();

                switch (option)
                {
                    //this menu option will ask user to add the name of the bank account and its starting balance.
                    case MenuOption.AddAccount:
                        {
                            Console.WriteLine("Add Account");
                            Console.Write("Enter Name: "); //Prompts for name
                            name = Console.ReadLine();
                            Console.Write("Enter the starting balance: "); //Prompts for starting balance
                            balance = Convert.ToDecimal(Console.ReadLine());
                            bank.AddAccount(new Account(name, balance)); //Adds new account to the bank
                            Console.WriteLine($"Account with name {name} is added with {balance} the bank.");
                            Console.WriteLine();
                            break;
                        }
                    case MenuOption.Deposit:
                        {
                            Console.WriteLine("Deposit");
                            DoDeposit(bank); //Calls on the DoDeposit method
                            break;
                        }
                    case MenuOption.Withdraw:
                        {
                            Console.WriteLine("Withdraw");
                            DoWithdraw(bank); //Calls on the DoWithdraw method
                            break;
                        }
                    case MenuOption.Transfer:
                        {
                            Console.WriteLine("Transfer");
                            DoTransfer(bank); //Calls on the DoTransfer method
                            break;
                        }
                    case MenuOption.Print:
                        {
                            Console.WriteLine("Print");
                            DoPrint(bank); //Calls on the DoPrint function
                            break;
                        }
                    case MenuOption.Transactions:
                        {
                            Console.WriteLine("Print Transaction History");
                            bank.PrintTransactionHistory();
                            DoRollback(bank);
                            break;
                        }
                    case MenuOption.Quit:
                        {
                            Console.WriteLine("Goodbye");
                            return; //Exits the program
                        }
                    default: //Input validation
                        {
                            Console.WriteLine("Unknown option, try again!");
                            break;
                        }

                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }


        static void DoDeposit(Bank bank)
        {
            Account accDeposit = findAccount(bank); //Prompts the user to input an existing account
            if (accDeposit == null) //If the account is non-existent, the method won't return anything
            {
                return;
            }
            Console.WriteLine("Input amount"); //Else, the program will prompt the user to input an amount to deposit
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0) //Data validation so the user won't input a value below 0
            {
                Console.WriteLine("The deposit ammount cannot be negative");
                return;
            }
            DepositTransaction deposit = new DepositTransaction(accDeposit, amount);
            bank.ExecuteTransaction(deposit); //Executes ExecuteTransaction(DepositTransaction transaction) in the bank class
        }


        static void DoWithdraw(Bank bank)
        {
            Account accWithdraw = findAccount(bank);
            if (accWithdraw == null)
            {
                return;
            }

            Console.WriteLine("Input amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0)
            {
                Console.WriteLine("The withdraw ammount cannot be negative");
                return;
            }
            WithdrawTransaction withdraw = new WithdrawTransaction(accWithdraw, amount);
            bank.ExecuteTransaction(withdraw); //Executes ExecuteTransaction(WithdrawTransaction transaction) in the bank class
        }

        static void DoTransfer(Bank bank)
        {
            Console.WriteLine("From Account.");
            Account fromAccount = findAccount(bank);
            if (fromAccount == null)
            {
                return;
            }

            Console.WriteLine("To Account.");
            Account toAccount = findAccount(bank);
            if (toAccount == null)
            {
                return;
            }
            Console.WriteLine("Input amount");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            if (amount < 0)
            {
                Console.WriteLine("The Transfer ammount cannot be negative");
                return;
            }
            TransferTransaction transfer = new TransferTransaction(fromAccount, toAccount, amount);
            bank.ExecuteTransaction(transfer); //Executes ExecuteTransaction(TransferTransaction transaction) in the bank class
        }

        static void DoPrint(Bank bank) //Prints the details of a particular account
        {
            Account account = findAccount(bank);
            if (account != null)
            {
                account.Print();
            }
        }

        static void DoRollback(Bank bank) //Prompts the user to choose an item in the transaction history to rollback
        {
            Console.Write("Enter the index of the transaction to rollback (0 to cancel): ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1; 

            if (index >= 0 && index < bank.Transactions.Count)
            {
                Transaction transaction = bank.Transactions[index];
                bank.RollbackTransaction(transaction); //Calls the rollback function
                Console.WriteLine($"Successfully rollbacked transaction {index + 1}");
            }
            else if (index != -1)
            {
                Console.WriteLine("Invalid transaction index.");
            }
        }

            private static Account findAccount(Bank bank) //Looks for an account
        {
            string name;
            Console.WriteLine("Enter the name of the account: "); //Prompts the user in input a name of an existing account
            name = Console.ReadLine();
            Account account = bank.GetAccount(name); //Calls the GetAccount method
            if (account == null) //If no account is returned, the program will display the message below
            {
                Console.WriteLine("Account with name " + name + " is not found.");
            }
            return account; //If an account is returned by GetAccount, then this method will also return the account name
        }


    }
}
