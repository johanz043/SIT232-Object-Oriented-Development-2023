using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
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
        public bool Deposit(decimal amount)
        {
           if (amount > 0)
            {
                _balance += amount;
                //Console.WriteLine($"Deposited {amount:C} from the account");
                Print();
                return true;
            }
            else
            {
                Console.WriteLine("You must deposit a positive number"); //Input validation
                return false;
            }
            
        }

        //Allows the user to deposit money from their account
        public bool Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                //Console.WriteLine($"Withdrawed {amount:C} from the account");
                Print();
                return true;
            }
            else
            {
                Console.WriteLine($"{amount:C} cannot be withdrawn. Insufficient balance."); //Input validation
                return false;
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
