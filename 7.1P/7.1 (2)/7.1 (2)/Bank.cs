using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _7._1__2_
{
    internal class Bank
    {
        //Declares _accounts as a list of Accounts
        private List<Account> _accounts;
        private List<Transaction> _transactions;

        //Creates a list of accounts
        public Bank()
        {
            _accounts = new List<Account>();
            _transactions = new List<Transaction>();
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
        }

        //Adds an account to the list
        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public Account GetAccount(String name)
        {
            for (int i = 0; i < _accounts.Count; i++) //Checks the whole list of accounts
            {
                if (name == _accounts[i].Name()) //If the inputted name matches a name in the list, the name will be returned
                    return _accounts[i];
            }
            return null;
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute(); // Call the Execute method on the provided transaction
            transaction.Print();

            _transactions.Add(transaction); // Add the transaction to the list of transactions
        }

        public void RollbackTransaction(Transaction transaction)
        {
            transaction.Rollback();
            _transactions.Add(transaction);
        }

        public void PrintTransactionHistory()
        {
            for (int i = 0; i < _transactions.Count; i++) //Lists all the transactions
            { //Datestamp returns the time in which a transaction has occurred
                _transactions[i].Print();
                //Console.WriteLine($"Transaction {i + 1} - Status: {(_transactions[i].Print() ? "Success" : "Failed")}, Timestamp: {_transactions[i].DateStamp}");
            }
        }
    }
}
