using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda_Expressions_and_Generics
{
    public class Account : IComparable<Account>
    {
        private decimal _balance;
        private string _name;

        public Account(string name, decimal balance)
        {
            _name = name;
            _balance = balance;
        }

        public bool Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                return true;
            }
            else
            {
                Console.WriteLine("You must deposit a positive number");
                return false;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine($"{amount:C} cannot be withdrawn. Insufficient balance.");
                return false;
            }
        }

        public void Print()
        {
            string accountName = Name;
            Console.WriteLine($"Account Name: {accountName}");
            Console.WriteLine($"Account Balance: {_balance:C}");
        }

        public string Name
        {
            get { return _name; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        public int CompareTo(Account other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return _balance.CompareTo(other._balance);
        }
    }
}
