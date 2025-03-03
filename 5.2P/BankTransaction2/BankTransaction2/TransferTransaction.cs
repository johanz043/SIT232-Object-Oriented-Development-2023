using BankTransaction2;
using System;

namespace Bank_Transactions
{
    public class TransferTransaction
    {
        public Account _fromAccount;
        public Account _toAccount;
        public decimal _amount;
        public DepositTransaction _deposit;
        public WithdrawTransaction _withdraw;
        public bool _executed;
        public bool _reversed;
        public bool _success;

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

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;

            _withdraw = new WithdrawTransaction(_fromAccount, amount);
            _deposit = new DepositTransaction(_toAccount, amount);
        }

        public void Print()
        {
            Console.WriteLine($"Transferred {_amount:c} from {_fromAccount.Name} to {_toAccount.Name}");
        }

        public void Execute(decimal amount)
        {
            _amount = amount;

            if (_executed)
            {
                throw new InvalidOperationException("Transaction has already been executed.");
            }

            if (_amount > 0)
            {
                _executed = true;
                _success = true;

                _withdraw.Execute();
                _deposit.Execute();

                Print();
            }
            else
            {
                throw new InvalidOperationException("Insufficient funds for withdrawal.");
            }
        }

        public void Rollback()
        {
            try
            {
                if (!Success && Reversed)
                {
                    _deposit.Rollback();
                    _withdraw.Rollback();
                    _reversed = true;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
