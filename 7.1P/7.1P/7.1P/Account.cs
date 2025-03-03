using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    class Account
    {
        //Instance Varibles
        private bool _depositFlag = false, _withdrawFlag = false;
        private decimal _balance;
        private string _name;

        //Constructor
        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        //Accessors
        public decimal getBalance() { return _balance; }
        public string GetName() { return _name; }

        //Mutators
        public void SetName(string input) { _name = input; }

        //Methods
        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _depositFlag = true;
                _balance += amount;
            }

            return _depositFlag;
        }
        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= _balance)
            {
                _withdrawFlag = true;
                _balance -= amount;
            }
            return _withdrawFlag;
        }
        public void Print()
        {
            Console.WriteLine("Account Name: " + _name
            + "\nAccount Balance: " + _balance.ToString("C")
            + "\n");
        }
    }

}

