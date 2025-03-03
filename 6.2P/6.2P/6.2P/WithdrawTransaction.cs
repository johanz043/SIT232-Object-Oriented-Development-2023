using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2P
{
    internal class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;
     
        public WithdrawTransaction(Account account, decimal amount)
        {
            //"this." points to the instance variables
            this._account = account;
            this._amount = amount;
        }
        public void Print() //Prints a text
        {
            if (_success)
            {
                Console.WriteLine(_amount + " was withdrawn from " + _account.Name() + "\'s account");
            }
        }
        public void Execute()
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class
            try
            {
                if (Executed)
                {
                    throw new InvalidOperationException("Transaction Already attempted");
                }
                if (_amount > balance)
                {
                    _success = false;
                    throw new InvalidOperationException("Sorry You can not withdraw more than your balance!");

                }
                else
                {
                    balance = balance - _amount;
                    _account.setBalace(balance);
                    _success = true;
                    _executed = true;
                }

            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);

            }

        }
        public void Rollback()
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class
            try
            {
                if (Success && !Reversed)
                {
                    balance = balance + _amount;
                    _account.setBalace(balance);
                    _reversed = true;
                }
                else
                {
                    throw new InvalidOperationException("Original transaction not finalized");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);

            }
        }

        public bool Executed //returns _executed
        {
            get { return _executed; }
        }

        public bool Success //returns _success
        {
            get { return _success; }
        }

        public bool Reversed //return _reversed
        {
            get { return _reversed; }

        }
    }
}
