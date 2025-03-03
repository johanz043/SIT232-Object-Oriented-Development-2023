using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2P
{
    class DepositTransaction
    {
        //Instance variables
        private Account _account;
        private decimal _amount;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;
        
        //Constructor
        public DepositTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void Print()
        {
            if (_success)
            {
                Console.WriteLine(_amount + " was Deposit to " + _account.Name() + "\'s account");
            }
        }

        public void Execute() //Deposits the amount into an account's balance
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class
            try
            {
                if (Executed)
                {
                    throw new InvalidOperationException("Transaction Already attempted");
                }
                else
                {
                    balance = balance + _amount;
                    _account.setBalace(balance); //Calls the setBalance function in the account class
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
                    balance = balance - _amount;
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

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }
    }
}
