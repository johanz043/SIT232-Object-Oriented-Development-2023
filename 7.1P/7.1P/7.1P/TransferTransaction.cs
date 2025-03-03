using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    class TransferTransaction : Transaction
    {
        //Varibles
        private Account _fromAccount;
        private Account _toAccount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _executed, _reversed;

        //Constructor
        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount) : base(amount)
        {
            _amount = amount;
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _deposit = new DepositTransaction(toAccount, _amount);
            _withdraw = new WithdrawTransaction(fromAccount, _amount);
        }

        //Accessors

        //public Boolean Executed() {return _executed;}

        public override bool Success()
        {
            if (_withdraw.Success() && _deposit.Success()) return true;
            else return false;

        }

        //public bool Reversed() { return _reversed; }
        public override Account Acc() { return _fromAccount; }

        //Mutators
        public override void Execute()
        {
            base.Execute();
            try
            {
                if (_executed) { throw new InvalidOperationException("Transaction already executed."); }
                if (_amount < 0) { throw new InvalidOperationException("Invalid Withdrawal Amount"); }
                if (_amount > _fromAccount.getBalance()) { throw new InvalidOperationException("Insufficient funds"); }

                _withdraw.Execute();

                if (_withdraw.Success())
                {
                    _deposit.Execute();
                    if (!_deposit.Success()) { Rollback(); }
                }
            }
            catch (InvalidOperationException ex) { Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message); }
        }

        public override void Rollback()
        {
            try
            {
                if (!Success()) { throw new InvalidOperationException("Transaction has not executed successfully."); }
                if (Reversed()) { throw new InvalidOperationException("Transaction has already been reversed."); }
                if (_amount > _toAccount.getBalance()) { throw new InvalidOperationException("Insufficient funds"); }
                _withdraw.Rollback();
                _deposit.Rollback();
                Console.WriteLine("Rollback Successful");
            }
            catch (InvalidOperationException ex) { Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message); }
            base.Execute();
        }

        //Other Methods
        public override void Print()
        {
            if (Success())
            {
                Console.WriteLine("Transferred {0} from {1}'s account to {2}'s account",
                _amount.ToString("C"),
                _fromAccount.GetName(),
                _toAccount.GetName());
            }
            _fromAccount.Print();
            _toAccount.Print();
        }
    }
}
