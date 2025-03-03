using BankTransaction2;
using System;

namespace Bank_Transactions
{
    public class DepositTransaction
    {
        // Instance variables
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        // Constructor
        public DepositTransaction(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }

        // Print transaction details
        public void Print()
        {
            if (_success)
            {
                Console.WriteLine($"{_amount:c} was deposited to {_account.Name}'s account");
            }
        }

        // Execute deposit
        public void Execute()
        {
            decimal balance = _account.Balance;

            try
            {
                if (_executed)
                {
                    throw new InvalidOperationException("Transaction Already attempted");
                }
                if (_amount < 0)
                {
                    _success = false;
                    throw new InvalidOperationException("Sorry, you cannot deposit less than zero!");
                }
                else
                {
                    balance = balance + _amount;
                    _success = true;
                    _account.setBalace(balance);
                }
                _executed = true;
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);
            }
        }

        // Rollback deposit
        public void Rollback()
        {
            decimal balance = _account.Balance;

            if (!_executed)
            {
                throw new InvalidOperationException("Transaction has not been executed yet.");
            }

            if (_reversed)
            {
                throw new InvalidOperationException("Transaction has already been reversed.");
            }

            if (_success)
            {
                balance = balance - _amount;
                _success = _account.Deposit(_account, balance);
                _account.setBalace(balance);
                _reversed = true;
            }
            else
            {
                throw new InvalidOperationException("Cannot reverse a failed transaction.");
            }
        }

        // Properties
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