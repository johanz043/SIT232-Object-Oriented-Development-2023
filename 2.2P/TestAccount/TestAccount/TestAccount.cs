using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAccount
{
    internal class TestAccount
    {
        static void Main(string[] args)
        {
            //Object
            Account myAccount = new Account("Johanz Te", 1000);

            myAccount.Print(); // Print initial details

            myAccount.Deposit(500); //Deposit 
            myAccount.Print();

            myAccount.Withdraw(200); //Withdraw
            myAccount.Print();

            myAccount.Withdraw(2000); 
            myAccount.Print();


            Console.ReadLine();
        }
    }
}
