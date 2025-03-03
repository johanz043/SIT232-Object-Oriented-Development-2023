using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    internal class WithdrawTransaction : Transaction
    {
        private Account _account;


        public WithdrawTransaction(Account account, decimal amount) : base(amount)
        {
            //"this." points to the instance variables
            this._account = account;
            this._amount = amount;
        }

        public override void Print() //Prints a text
        {
            if (_success)
            {
                Console.WriteLine(_amount + " was withdrawn from " + _account.Name() + "\'s account");
            }
        }
        public override void Execute()
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
                    base.Execute();
                    balance = balance - _amount;
                    _account.setBalace(balance);
                    
                    
                }

            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);

            }

        }
        public override void Rollback()
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class
            try
            {
                if (Success() && !Reversed)
                {
                    balance = balance + _amount;
                    _account.setBalace(balance);
                    
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


        public override bool Success() //returns _success
        {
            { return _success; }
        }


    }
}
