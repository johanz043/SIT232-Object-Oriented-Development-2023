using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expressions_and_Generics
{
    class Tester
    {
        static void Main(string[] args)
        {
            MyStack<Account> accountStack = new MyStack<Account>(5);

            // Populate the stack with some accounts
            accountStack.Push(new Account("Johan", 20000));
            accountStack.Push(new Account("Adam", 6000));
            accountStack.Push(new Account("James", 1000));
            accountStack.Push(new Account("Josh", 400));
            accountStack.Push(new Account("Mason", 850));


            // Test Find
            Account foundAccount = accountStack.Find(acc => acc.Balance > 1000);
            if (foundAccount != null)
            {
                Console.WriteLine($"Found account with balance > 1000: {foundAccount.Name}");
            }
            else
            {
                Console.WriteLine("No account found.");
            }

            // Test FindAll
            Account[] highBalanceAccounts = accountStack.FindAll(acc => acc.Balance > 1000);
            if (highBalanceAccounts.Length > 0)
            {
                Console.WriteLine("High balance accounts:");
                foreach (var acc in highBalanceAccounts)
                {
                    Console.WriteLine($"{acc.Name}: {acc.Balance:C}");
                }
            }
            else
            {
                Console.WriteLine("No high balance accounts found.");
            }

            // Test RemoveAll
            int removedCount = accountStack.RemoveAll(acc => acc.Balance < 1000);
            Console.WriteLine($"Removed {removedCount} accounts with balance < 1000.");

            // Test Min and Max
            Account minBalanceAccount = accountStack.Min();
            Account maxBalanceAccount = accountStack.Max();

            Console.WriteLine($"Account with minimum balance: {minBalanceAccount.Name}");
            Console.WriteLine($"Account with maximum balance: {maxBalanceAccount.Name}");

            Console.ReadLine();
        }
    }
}
