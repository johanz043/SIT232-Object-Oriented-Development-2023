using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2P
{
    internal class Bank
    {
        //Declares _accounts as a list of Accounts
        private List<Account> _accounts;
        
        //Creates a list of accounts
        public Bank()
        {
            _accounts = new List<Account>();
        }

        //Adds an account to the list
        public void AddAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException("Account cannot be null");
            }
            
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

        public void ExecuteTransaction(DepositTransaction transaction)
        {
            transaction.Execute(); //Calls the Execute function in DepositTransaction
            transaction.Print();
        }

        public void ExecuteTransaction(WithdrawTransaction transaction)
        {
            transaction.Execute(); //Calls the Execute function in WithdrawTransaction
            transaction.Print();
        }

        public void ExecuteTransaction(TransferTransaction transaction)
        {
            transaction.Execute(); //Calls the Execute function in TransferTransaction
            transaction.Print();
        }
    }
}
