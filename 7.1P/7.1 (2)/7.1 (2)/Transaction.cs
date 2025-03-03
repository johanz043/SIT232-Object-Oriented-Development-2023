using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    abstract class Transaction
    {
        protected decimal _amount;
        protected bool _success;

        private bool _executed;
        private bool _reversed;

        DateTime _dateStamp;

        public Transaction(decimal amount)
        {
            _amount = amount;
        }

        abstract public bool Success();

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public DateTime DateStamp
        {
            get { return _dateStamp; }
        }



        abstract public void Print();
  

        public virtual void Execute()
        {
            
            if (Executed)
            {
                throw new InvalidOperationException("Transaction Already attempted");
            }

            _dateStamp = DateTime.Now;
            _executed = true;
            _success = true;
        }

        public virtual void Rollback()
        {
            if (Reversed)
            {
                throw new InvalidOperationException("Transaction Already attempted");
            }

             _dateStamp = DateTime.Now;
            _reversed = true;
        }
    }
}
 