using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Transactions
{
    public class DepositTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        public void Print()
        {
            Console.WriteLine($"Deposited {_amount:c}");
        }

        public void Execute()
        {
            //decimal balance = _account.Balance;
            //_success = _account.Deposit(balance);

            try
            {
                if (Executed)
                {
                    throw new InvalidOperationException("Transaction Already attempted");
                }
                _executed = true;
                _success = _account.Deposit(_amount);

                
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);

            }

        }

        public void Rollback()
        {
            decimal balance = _account.Balance;

            if (Executed)
            {
                throw new InvalidOperationException("Transaction has not been executed yet.");
            }

            if (Reversed)
            {
                throw new InvalidOperationException("Transaction has already been reversed.");
            }

            try
            {
                if (Success && !Reversed)
                {
                    balance = balance - _amount;
                    _success = _account.Deposit(balance);
                    _account.setBalace(balance);
                    _reversed = true;
                }
                else
                {
                    throw new InvalidOperationException("Cannot reverse a failed transaction.");
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
