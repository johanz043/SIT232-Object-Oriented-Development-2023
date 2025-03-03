using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    class DepositTransaction : Transaction
    {
        //Instance variables
        private Account _account;


        //Constructor
        public DepositTransaction(Account account, decimal amount) : base(amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public override void Print()
        {
            if (_success)
            {
                Console.WriteLine(_amount + " was Deposit to " + _account.Name() + "\'s account");
            }
        }

        public override void Execute() //Deposits the amount into an account's balance
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class
            
            base.Execute();


                    balance = balance + _amount;
                    _account.setBalace(balance); //Calls the setBalance function in the account class

                
            
        }
        public override void Rollback()
        {
            decimal balance = _account.Balance(); //The variable "balance" gets its value from the get method "Balance" in the Account class

                if (Success() && !Reversed)
                {
                    base.Rollback();
                    balance = balance - _amount;
                    _account.setBalace(balance);
                    
                }
                else
                {
                    throw new InvalidOperationException("Original transaction not finalized");
                }
            

        }

        public override bool Success()
        {
            return _success; 
        }

    }
}
