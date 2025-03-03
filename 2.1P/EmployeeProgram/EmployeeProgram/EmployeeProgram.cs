using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    internal class EmployeeProgram
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("Johanz Te", 18000); //Creates an object based off the Employee class, where "Johanz Te' is the employeeName and 18000 is the currentSalary

            //Displays the employee name and salary before being raised by 20%
            Console.WriteLine("Employee name: " + emp.getName() + "\nEmployee salary: $" + emp.getSalary());

            emp.raiseSalary(20); //In this case, we raise the salary by 20%

            //Displays the employee name and salary after being raised by 20%
            Console.WriteLine("Raised by 20%" + "\nEmployee name: " + emp.getName() + "\nEmployee salary: $" + emp.getSalary());

            //Calls on the Tax() function in the Employee class
            double taxAmount = emp.Tax();
            Console.WriteLine("\nTax Deduction: $" + taxAmount.ToString());


            Console.ReadLine();
        }
    }
}
