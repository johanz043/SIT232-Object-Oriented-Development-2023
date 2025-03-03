using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TestAccount
{
    internal class Account
    {
        //Instance variables
        private decimal _balance;
        private string _name;

        //Constructors
        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        //Allows the user to deposit money into their account
        public void Deposit(decimal amount)
        {
            _balance += amount;
            Console.WriteLine($"Deposited {amount:C} from the account");
        }

        //Allows the user to deposit money from their account
        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawed {amount:C} from the account");
            }
            else
            {
                Console.WriteLine($"{amount:C} cannot be withdrawn. Insufficient balance.");
            }
        }

        //Prints the account name and balance
        public void Print()
        {
            string accountName = Name;
            Console.WriteLine($"Account Name: {accountName}");
            
            Console.WriteLine($"Account Balance: {_balance:C}"); // Display balance in currency format
        }

        //Gets the name of the account
        public string Name
        {
            get { return _name; }
        }

        
    }
}
