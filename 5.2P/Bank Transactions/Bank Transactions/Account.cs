using Bank_Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{

    public class Account
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
        public bool Deposit(decimal deposit)
        {

            // checking
            if (deposit < 0)
            {
                //Console.WriteLine("The deposit amount cannot be negative");
                return false;
            }
            _balance += deposit;
           // var depositTransaction = new DepositTransaction(account, deposit);
            return true;
        }


        //Allows the user to deposit money from their account
        public bool Withdraw(decimal withdraw)
        {

            if (withdraw < 0)
            {
               // Console.WriteLine("The withdraw amount cannot be negative");
                return false;
            }
            if (withdraw > this._balance)
            {
               // Console.WriteLine("You can not withdraw more than your balance!");
                return false;
            }
              _balance =- withdraw;
                return true;
        }



        //Prints the account name and balance
        public void Print()
        {
            string accountName = Name;
            Console.WriteLine($"Account Name: {accountName}");
            Console.WriteLine($"Account Balance: {_balance:C}"); // Display balance in currency format
            Console.WriteLine("\n");
        }


        //Gets the name of the account
        public string Name
        {
            get { return _name; }
        }


        public decimal Balance
        {
            get { return _balance; }
        }


        public void setBalace(decimal amount)
        {
            this._balance = amount;
        }

    }
}
