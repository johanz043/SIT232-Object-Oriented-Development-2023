using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public enum MenuOptions

{

    Deposit = 1,

    Withdraw = 2,

    Transfer = 3,

    Print = 4,

    Quit = 5

}

namespace _7._1P
{
    class BankSystem
    {
        //Constants
        enum MenuOption { Withdraw, Deposit, Transfer, Print, Create_Account, AccList, TransList, Quit };

        /* =====================================================================================================================================================================================
        Menu Method
        =====================================================================================================================================================================================*/
        static int ReadUserInput()
        {
            int userInputINT = 12, testflag = 3;
            string userInputSTRING;

            do
            {
                Console.Clear();
                Console.Write(
                "Welcome to the University Online Bank. \n\n"
                + "Choose from the following options: \n 1."
                + MenuOption.Withdraw + "\n 2."
                + MenuOption.Deposit + "\n 3."
                + MenuOption.Transfer + "\n 4."
                + MenuOption.Print + "\n 5."
                + MenuOption.Create_Account + "\n 6."
                + MenuOption.AccList + "\n 7."
                + MenuOption.TransList + "\n 8."
                + MenuOption.Quit + "\n");
                userInputSTRING = Console.ReadLine();


                testflag = InputStringCheck(userInputSTRING, 8, 1, true);
                if (testflag == 2)
                {
                    Console.WriteLine("You have entered: " + userInputSTRING + ". You must enter an INTEGER value between 1 & 8.");
                    Console.ReadKey();
                }
                else if (testflag == 1)
                {
                    userInputINT = Convert.ToInt32(userInputSTRING);
                    Console.WriteLine("You have entered: " + userInputINT + ". You must enter a number BETWEEN 1 & 8.");
                    Console.ReadKey();
                }
            } while (testflag > 0);

            userInputINT = Convert.ToInt32(userInputSTRING);
            return userInputINT;
        }


        /* =====================================================================================================================================================================================
        Validation Methods
        ===================================================================================================================================================================================*/

        //User input validation
        static int InputStringCheck(string inputString, int upperLimit, int lowerLimit, bool upperLimitFlag)
        {
            int inputINT, outputINT;

            if (Regex.IsMatch(inputString, @"^\d+$"))
            {
                inputINT = Convert.ToInt32(inputString);
                if (inputINT < lowerLimit || (inputINT > upperLimit && upperLimitFlag == true)) { outputINT = 1; }
                else { outputINT = 0; }
            }
            else { outputINT = 2; }
            return outputINT;
        }

        //Account validation
        static Account accCheck(string userInputSTRING, Account[] accountArray)
        {
            Account returnAccount = accountArray[0];
            bool loopFlag = false;
            int i = 0;
            do
            {
                if (accountArray[i].GetName() == userInputSTRING)
                {
                    returnAccount = accountArray[i];
                    loopFlag = true;
                }
                i++;
                if (i >= accountArray.Length) { loopFlag = true; }
            } while (!loopFlag);

            return returnAccount;
        }

        //Transaction ammount validation
        static bool amountCheck(string userInputSTRING)
        {
            int testFlag;
            float testFloat;

            if (float.TryParse(userInputSTRING, out testFloat)) { return true; }
            else
            {
                testFlag = InputStringCheck(userInputSTRING, 3, 10, false);
                if (testFlag >= 2) { return false; }
                else { return true; }
            }
        }

        private static Account FindAccount(Bank bank)
        {
            string account;

            Console.WriteLine("Enter Account Name: \n");
            account = Console.ReadLine();
            if (bank.GetAccount(account) == null)
            {
                Console.WriteLine("There is no account by that name.");
                return null;
            }
            else { return bank.GetAccount(account); }
        }


        /* =====================================================================================================================================================================================
        Banking Menu Methods
        =====================================================================================================================================================================================*/
        //Deposit
        static void DoDeposit(Bank acc)
        {
            Console.Clear();

            Account userAccount;
            bool checkFlag;
            decimal userAmount;
            string userInputSTRING;

            Console.WriteLine("Deposit:");
            userAccount = FindAccount(acc);
            try
            {
                if (userAccount == null) { throw new ArgumentException("Account does not exist"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                + "\nReturning to main menu.");
                Console.ReadKey();
                return;
            }

            Console.Write("How much do you want to deposit? \n$:");
            userInputSTRING = Console.ReadLine();
            checkFlag = amountCheck(userInputSTRING);

            if (checkFlag)
            {
                userAmount = Convert.ToDecimal(userInputSTRING);
                DepositTransaction transaction = new DepositTransaction(userAccount, userAmount);
                acc.ExecuteTransaction(transaction);
                transaction.Print();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nError:\nYou have not entered an acceptable value, returning to the main menu.");
                Console.ReadKey();
            }
        }

        //Withdraw
        static void DoWithdraw(Bank acc)
        {
            Console.Clear();

            Account userAccount;
            bool checkFlag;
            decimal userAmount;
            string userInputSTRING;

            Console.WriteLine("Withdrawal:");
            userAccount = FindAccount(acc);
            try
            {
                if (userAccount == null) { throw new ArgumentException("Account does not exist"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                + "\nReturning to main menu.");
                Console.ReadKey();
                return;
            }

            Console.Write("How much do you want to withdraw? \n$:");
            userInputSTRING = Console.ReadLine();
            checkFlag = amountCheck(userInputSTRING);

            if (checkFlag)
            {
                userAmount = Convert.ToDecimal(userInputSTRING);
                WithdrawTransaction transaction = new WithdrawTransaction(userAccount, userAmount);
                acc.ExecuteTransaction(transaction);
                transaction.Print();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nError:\nYou have not entered an acceptable value, returning to the main menu.");
                Console.ReadKey();
            }
        }

        //Transfer
        static void DoTransfer(Bank acc)
        {
            Console.Clear();

            Account userFromAccount, userToAccount;
            bool checkFlag;
            decimal userAmount;
            string userInputSTRING;

            Console.WriteLine("Which account do you wish to transfer from?");
            userFromAccount = FindAccount(acc);
            try
            {
                if (userFromAccount == null) { throw new ArgumentException("The account you are trying to transfer from does not exist"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                + "\nReturning to main menu.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Which account do you wish to transfer to?");
            userToAccount = FindAccount(acc);
            try
            {
                if (userToAccount == null) { throw new ArgumentException("The account you are trying to transfer to does not exist"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                + "\nReturning to main menu.");
                Console.ReadKey();
                return;
            }

            Console.Write("How much do you want to transfer? \n$:");
            userInputSTRING = Console.ReadLine();
            checkFlag = amountCheck(userInputSTRING);

            if (checkFlag)
            {
                userAmount = Convert.ToDecimal(userInputSTRING);
                TransferTransaction transaction = new TransferTransaction(userFromAccount, userToAccount, userAmount);
                acc.ExecuteTransaction(transaction);
                transaction.Print();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nError:\nYou have not entered an acceptable value, returning to the main menu.");
                Console.ReadKey();
            }
        }

        //Print
        static void DoPrint(Bank acc)
        {
            Console.Clear();
            Account userAccount;

            //Console.WriteLine("Which account details do you wish to see?\n");
            userAccount = FindAccount(acc);
            try
            {
                if (userAccount == null) { throw new ArgumentException("Account does not exist"); }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                + "\nReturning to main menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Here are you account details:\n");
            userAccount.Print();
            Console.ReadKey();
        }

        //Add Account
        static void DoAddAccount(Bank accList)
        {
            Console.Clear();

            bool checkFlag;
            decimal userAmount;
            string userInputSTRING, accName;

            Console.WriteLine("Enter the name of the new account: \n");
            Console.Write("Name:");
            accName = Console.ReadLine();

            Console.WriteLine("Enter starting balance: \n");
            Console.Write("$:");
            userInputSTRING = Console.ReadLine();
            checkFlag = amountCheck(userInputSTRING);
            if (checkFlag)
            {
                userAmount = Convert.ToDecimal(userInputSTRING);
                Account account = new Account(accName, userAmount);
                accList.AddAccount(account);
                Console.WriteLine("Account successfully created: \n");
                account.Print();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nError:\nYou have not entered an acceptable value, returning to the main menu.");
                Console.ReadKey();
            }
        }

        //Rollback Transaction
        static void DoRollback(Bank accList)
        {
            int testflag = 3, userInputINT = 0;
            string userInputSTRING;

            do
            {
                Console.Clear();
                accList.TransactionList();
                Console.WriteLine("Which transaction do you wish to rollback?\nTransaction No: ");
                userInputSTRING = Console.ReadLine();

                testflag = InputStringCheck(userInputSTRING, accList.GetTransactionList().Count, 1, true);
                if (testflag == 2)
                {
                    Console.WriteLine("You have entered: " + userInputSTRING + ". You must enter an INTEGER value between 1 & " + accList.GetTransactionList().Count);
                    Console.ReadKey();
                }
                else if (testflag == 1)
                {
                    userInputINT = Convert.ToInt32(userInputSTRING);
                    Console.WriteLine("You have entered: " + userInputINT + ". You must enter a number BETWEEN 1 & " + accList.GetTransactionList().Count);
                    Console.ReadKey();
                }
            } while (testflag > 0);

            userInputINT = Convert.ToInt32(userInputSTRING);
            accList.RollbackTransaction(accList.GetTransactionList()[userInputINT - 1]);

            Console.ReadKey();
        }

        //List accounts
        static void DoShowAccounts(Bank accList)
        {
            Console.Clear();
            accList.AccountList();
            Console.ReadKey();
        }

        //List transactions
        static void DoShowTransactions(Bank accList)
        {
            bool loopFlag = false;
            char choice = ' ';

            Console.Clear();
            accList.TransactionList();
            Console.WriteLine("Press anykey to continue ...");
            Console.ReadKey();

            while (!loopFlag)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nDo you want to rollback a transaction?\n(Y/N):");
                    choice = Console.ReadLine()[0];
                    if (choice != 'Y' && choice != 'y' && choice != 'N' && choice != 'n') { throw new ArgumentException("Invalid Choice"); }
                    loopFlag = true;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message
                    + "\nTry Again.");
                    Console.ReadKey();
                }
            }
            if (choice == 'n' || choice == 'N') { return; }
            if (choice == 'y' || choice == 'Y') { DoRollback(accList); }
            //Console.ReadKey();
        }


        /*************************************
        ********* Main Project **********
        ************************************/

        static void Main(string[] args)
        {
            //Varibles
            bool exitFlag = false;
            int menuChoice;

            Account[] accountArray = new Account[10];
            Bank newBank = new Bank();

            do
            {
                menuChoice = ReadUserInput();

                switch (menuChoice)
                {
                    case 1: DoWithdraw(newBank); break;
                    case 2: DoDeposit(newBank); break;
                    case 3: DoTransfer(newBank); break;
                    case 4: DoPrint(newBank); break;
                    case 5: DoAddAccount(newBank); break;
                    case 6: DoShowAccounts(newBank); break;
                    case 7: DoShowTransactions(newBank); break;
                    case 8: exitFlag = true; break;
                        //Does this need a default? Prehaps add another tag to the enum that is called noOption?
                }

            } while (exitFlag == false);

            Console.Clear();
            Console.WriteLine("Thankyou for banking with us. \nGoodbye.");
            Console.ReadKey();
        }

    }
}
