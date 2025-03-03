using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    class TransferTransaction : Transaction
    {
        private Account _fromaccount;
        private Account _toaccount;
        private DepositTransaction _deposit;
        private WithdrawTransaction _withdraw;

        public TransferTransaction(Account frmaccount, Account toaccount, decimal amount) : base(amount)
        {
            this._fromaccount = frmaccount;
            this._toaccount = toaccount;
            this._amount = amount;
            _deposit = new DepositTransaction(toaccount, amount);
            _withdraw = new WithdrawTransaction(frmaccount, amount);
        }


        public override void Print()
        {
            Console.WriteLine("Transferred " + _amount + " from " + _fromaccount.Name() + "\'s account To " + _toaccount.Name() + "\'s account");
        }

        public override void Execute()
        {
            _withdraw.Execute();
            _deposit.Execute();

            if (_withdraw.Success() && _deposit.Success())
            {
                base.Execute();
                _success = true; 
            }
            else
            {
                Rollback(); //If the transfer is unsuccessful, Rollback() is used to reverse the calculations
            }
        }
        public override void Rollback()
        {
            try
            {
                if (Success() && !Reversed)
                {
                    _deposit.Rollback();
                    _withdraw.Rollback();
                    
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public override bool Success()
        {
            { return _success; }
        }


    }
}
