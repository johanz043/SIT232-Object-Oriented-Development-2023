using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProgram
{
    internal class MobileProgram
    {
        static void Main(string[] args)
        {
            //New input
            Mobile jimMobile = new Mobile("Monthly", "Samsung Galaxy S6", "07712223344");
            Console.WriteLine("Account Type: " + jimMobile.getAccType() + "\nMobile Number: " + jimMobile.getNumber() + "\nDevice: " + jimMobile.getDevice() + "\nBalance: " + jimMobile.getBalance());


            jimMobile.setAccType("PAYG");
            jimMobile.setDevice("iPhone 65");
            jimMobile.setNumber("07713334466");
            jimMobile.setBalance(15.50);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Account Type: " + jimMobile.getAccType() + "\nMobile Number: " + jimMobile.getNumber() + "\nDevice: " + jimMobile.getDevice() + "\nBalance: " + jimMobile.getBalance());

            Console.WriteLine();
            jimMobile.addCredit(10.0);
            jimMobile.makeCall(5);
            jimMobile.sendText(2);


            Console.WriteLine();
            Console.WriteLine();
            //New input
            Mobile secMobile = new Mobile("Monthly", "iPhone SE", "0463456545");
            Console.WriteLine("Account Type: " + secMobile.getAccType() + "\nMobile Number: " + secMobile.getNumber() + "\nDevice: " + secMobile.getDevice() + "\nBalance: " + secMobile.getBalance());

            Console.WriteLine();
            secMobile.addCredit(20.0);
            secMobile.makeCall(10);
            secMobile.sendText(10);

            Console.ReadLine();
        }
    }
}
