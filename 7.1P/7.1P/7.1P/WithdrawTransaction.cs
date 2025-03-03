using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
        class WithdrawTransaction : Transaction
        {
            //Varibles
            private Account _account;
            //private decimal _amount;
            private bool _executed, _reversed; //, _success;

            //Constructor
            public WithdrawTransaction(Account account, decimal amount)
            : base(amount)
            {
                try
                {
                    if (Convert.ToString(account.GetType()) != "Account.Account") { throw new ArgumentException("Invalid Account"); }
                    _account = account;
                }
                catch (ArgumentException ex) { Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message); }

                _amount = amount;
            }

            //Accessors
            //public bool Executed() {return _executed;
            public override bool Success() { return _success; }
            //public bool Reversed() { return _reversed; }


            //Mutators
            public override Account Acc() { return _account; }

            public override void Execute()
            {
                base.Execute();
                try
                {
                    if (_executed) { throw new InvalidOperationException("Transaction already executed."); }
                    if (_amount < 0) { throw new InvalidOperationException("Invalid Withdrawal Amount"); }
                    if (_amount > _account.getBalance()) { throw new InvalidOperationException("Insufficient funds"); }
                    if (_account.Withdraw(_amount) == true)
                    {
                        _success = true;
                        _executed = true;
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message);
                }


            }

            public override void Rollback()
            {
                try
                {
                    if (_reversed) { throw new InvalidOperationException("Transaction already reversed."); }
                    if (!_executed) { throw new InvalidOperationException("Transaction not yet executed."); }
                    if (_success && !_reversed)
                    {
                        _account.Deposit(_amount);
                        _reversed = true;
                        //Console.WriteLine("Rollback Successful");
                    }
                }
                catch (InvalidOperationException ex) { Console.WriteLine("\nThe following error detected: " + ex.GetType() + "\nwith message: " + ex.Message); }
                base.Execute();
            }

            //Other Methods
            public override void Print()
            {
                if (_reversed) { Console.WriteLine("Transaction has been reversed."); }
                if (_executed) { Console.Write("Transaction has been executed"); }
                else { Console.WriteLine("Transaction has not been executed."); }

                if (_success) { Console.Write(" successfully.\n"); }
                else { Console.WriteLine("Transaction has not been successful."); }

                _account.Print();
            }
        }
}
