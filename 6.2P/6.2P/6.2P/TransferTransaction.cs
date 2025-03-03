using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2P
{
    internal class TransferTransaction
    {
        private Account _fromaccount;
        private Account _toaccount;
        private decimal _amount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private Boolean _executed;
        private Boolean _success;
        private Boolean _reversed;

        public TransferTransaction(Account frmaccount, Account toaccount, decimal amount)
        {
            this._fromaccount = frmaccount;
            this._toaccount = toaccount;
            this._amount = amount;
            _deposit = new DepositTransaction(toaccount, amount);
            _withdraw = new WithdrawTransaction(frmaccount, amount);
        }

        public void Print()
        {
            Console.WriteLine("Transferred " + _amount + " from " + _fromaccount.Name() + "\'s account To " + _toaccount.Name() + "\'s account");
        }
        public void Execute()
        {
             _withdraw.Execute();
             _deposit.Execute();

            if (_withdraw.Success && _deposit.Success)
            {
               
                _success = true;
                _executed = true;
            }
            else
            {
                Rollback(); //If the transfer is unsuccessful, Rollback() is used to reverse the calculations
            }
        }
        public void Rollback()
        {
            try
            {
                if (Success && !Reversed)
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
