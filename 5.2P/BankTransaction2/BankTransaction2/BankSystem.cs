using Bank_Transactions;
using BankTransaction2;
using System;

namespace BankSystem
{
    public class BankSystem
    {
        private enum MenuOption
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
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("0. Withdraw");
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Transfer");
                    Console.WriteLine("3. Print");
                    Console.WriteLine("4. Quit");

                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice < 0 || choice > 4)
                    {
                        Console.WriteLine("Invalid choice. Please choose a valid option.");
                    }
                    else
                    {
                        return (MenuOption)choice;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input: Input numbers between 0 and 3");
                }
            } while (choice != 5);

            return MenuOption.Quit;
        }

        public static void DoDeposit(Account account)
        {
            Console.Write("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            account.Deposit(account, depositAmount);
            DoPrint(account);
        }

        public static void DoWithdraw(Account account)
        {
            Console.Write("Enter amount to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            account.Withdraw(account, withdrawAmount);
            DoPrint(account);
        }

        public static void DoTransfer(Account account1, Account account2)
        {
            Console.Write("Enter amount to transfer: ");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());

            TransferTransaction transferTransaction = new TransferTransaction(account1, account2, transferAmount);

            try
            {
                transferTransaction.Execute(transferAmount);
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public static void DoPrint(Account account)
        {
            account.Print();
        }

        public static void Main(string[] args)
        {
            Account myAccount = new Account("John", 1000);
            Account myAccount2 = new Account("Jenny", 2000);

            myAccount.Print();
            myAccount2.Print();

            while (true)
            {
                MenuOption option = ReadUserOption();

                switch (option)
                {
                    case MenuOption.Withdraw:
                        DoWithdraw(myAccount);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(myAccount);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(myAccount, myAccount2);
                        break;
                    case MenuOption.Print:
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