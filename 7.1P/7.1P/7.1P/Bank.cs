using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._1P
{
    internal class Bank
    {
        //Varibles
        private List<Account> _accounts = new List<Account>();
        private List<Transaction> _transactions = new List<Transaction>();

        //Constructor
        public Bank() 
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        //Accessors
        public List<Transaction> GetTransactionList() { return _transactions; }
        public void AccountList()
        {
            Console.WriteLine("LIST OF ACCOUNTS: ");
            for (int i = 0; i < _accounts.Count; i++)
            {
                Console.WriteLine(_accounts[i].GetName().ToString()
                + "\t\t\t" + _accounts[i].getBalance().ToString("c"));
            }
        }
        public void TransactionList()
        {
            Console.WriteLine("LIST OF TRANSACTIONS: ");
            string status = "", type = "";

            for (int i = 0; i < _transactions.Count; i++)
            {
                status = "Unsuccessful";
                if (_transactions[i].Success()) status = "Successfull";
                int j = _transactions[i].GetType().ToString().IndexOf(".");
                type = _transactions[i].GetType().ToString().Substring(j + 1);

                Console.WriteLine(i + 1
                + ". " + _transactions[i].DateStamp().ToString()
                + "\t\t" + _transactions[i].Acc().GetName()
                + "\t\t" + _transactions[i].getAmount().ToString("c")
                + "\t\t" + type
                + "\t\t" + status);
            }
        }
        public Account GetAccount(string name)
        {
            for (int i = 0; i < _accounts.Count; i++)
            {
                if (_accounts[i].GetName() == name) return _accounts[i];
            }
            return null;
        }
        public Account FindAccount(Bank bank)
        {
            string account;

            Console.WriteLine("Enter Account Name: \n");
            account = Console.ReadLine();
            if (bank.GetAccount(account) == null)
            {
                Console.WriteLine("There is no account by that name.");
                return null;
            }
            else return bank.GetAccount(account);
        }

        //Mutators
        public void AddAccount(Account account) { _accounts.Add(account); }
        public void ExecuteTransaction(Transaction transaction)
        {
           
            transaction.Execute();
            _transactions.Add(transaction);

        }
        public void RollbackTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            transaction.Rollback();
        }
        public void PrintTransactionHistory() { }
    }
}
