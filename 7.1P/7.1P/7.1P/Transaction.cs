using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    abstract class Transaction
    {
        //Varibles
        protected decimal _amount;
        protected bool _success;

        private bool _executed, _reversed;
        private DateTime _dateStamp;

        //Constructor
        public Transaction(decimal amount) 
        { 
            _amount = amount; 
        }

        //Accessors
        abstract public bool Success(); //Itallics denotes abstract
        public bool Executed() { return _executed; }
        public bool Reversed() { return _reversed; }

        public DateTime DateStamp() { return _dateStamp; }

        public decimal getAmount() { return _amount; }
        abstract public Account Acc();

        //Methods
        abstract public void Print();
        public virtual void Execute() { _dateStamp = DateTime.Now; }
        public virtual void Rollback() { _dateStamp = DateTime.Now; }

    }
}
