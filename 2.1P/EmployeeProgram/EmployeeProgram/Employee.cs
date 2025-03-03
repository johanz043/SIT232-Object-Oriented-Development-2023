using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeProgram
{
    class Employee
    {
        //Instance variables
        private string name;
        private double salary;

        //Constructors
        public Employee(string employeeName, double currentSalary)
        {
            name = employeeName;
            salary = currentSalary;
        }

        public string getName() //Accessor methods
        {
            return name;
        }
        public string getSalary()
        {
            return salary.ToString();
        }
        //Raises salary based on a percentage
        public void raiseSalary(double percentage)
        {
            double raiseAmount = salary * (percentage / 100);
            salary += raiseAmount;
        }


        //Calculates tax deduction
        public double Tax()
        {
            double taxAmount = 0.0;

            if (salary <= 18200)
            {
                taxAmount = 0;
            }
            else if (salary <= 37000)
            {
                //19c for each $1 over 18,200, therefore we misus the salary by 18,200 before calculating the percentage of 19%
                taxAmount = (salary - 18200) * 0.19;
            }
            else if (salary <= 90000)
            {
                taxAmount = 3572 + (salary - 37000) * 0.325;
            }
            else if (salary <= 180000)
            {
                taxAmount = 20797 + (salary - 90000) * 0.37;
            }
            else
            {
                taxAmount = 54096 + (salary - 180000) * 0.45;
            }

            return taxAmount;
        }


    }
}
