using BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bank_Transactions
{
    public class WithdrawTransaction
    {
        private Account _account;
        private decimal _amount;
        private bool _executed;
        private bool _success;
        private bool _reversed;

        public WithdrawTransaction(Account account, decimal amount)
        {
            _account = account; 
            _amount = amount;
        }

        public void Print()
        {
            Console.WriteLine($"Withdrew {_amount:c} from {_account.Name}'s account");
        }

        public void Execute()
        {
            decimal balance = _account.Balance;
           // _success = _account.Withdraw(_account, balance);

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
                    _success = _account.Withdraw(_amount);
                    _account.setBalace(balance);
                }
                _executed = true;
            }
            catch (InvalidOperationException exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Rollback()
        {
            decimal balance = _account.Balance;

            try
            {
                if (Success && !Executed)
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
