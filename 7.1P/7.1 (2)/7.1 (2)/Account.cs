using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    class Account
    {
        //Instance variables
        private decimal _balance;
        private String _name;

        //Constructor
        public Account(String name, decimal balance)
        {
            this._balance = balance;
            this._name = name;
        }

        //Prints a single account when it is called
        public void Print()
        {
            Console.WriteLine("Account name: " + this._name);
            Console.WriteLine("Available balance: " + this._balance);
        }

        //Get method
        public String Name()
        {
            return this._name;
        }

        //Get method
        public Decimal Balance()
        {
            return this._balance;
        }

        //Set method
        public void setBalace(decimal amount) //Sets "amount" as an account's balance
        {
            this._balance = amount;
        }

    }
}
