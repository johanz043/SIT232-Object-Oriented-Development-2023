using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDate
{


    class MyDate
    {
        //Instance variables
        private int _year;
        private int _month;
        private int _day;

        //Constant variables
        private string[] MONTHS = { "", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        private string[] DAYS = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private int[] DAYS_IN_MONTH = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        //Constructor
        public MyDate(int day, int month, int year)
        {
            if (isValidDate(year, month, day))
            {
                _year = year;
                _month = month;
                _day = day;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid date");
            }
        }

        //Sets the day
        public void SetDay(int day)
        {
            //first checck if day is less then 1 then throw exception
            if (day < 1)
                throw new ArgumentOutOfRangeException("Invalid day");
            //check if current month is 2
            if (_month == 2)
            {
                //and if current year is leap year then day must be less than 29 and if its not leap year then day must be less than 28
                if ((IsLeapYear(_year) && day > 29) || (!IsLeapYear(_year) && day > 28))
                    throw new ArgumentOutOfRangeException("Invalid day");
                _day = day;
            }
            else
            {
                if (day > DAYS_IN_MONTH[_month])
                    throw new ArgumentOutOfRangeException("Invalid day");
                _day = day;
            }
        }
        //Sets the month
        public void SetMonth(int month)
        {
            if (month < 0 || month > 12)
            {
                throw new ArgumentOutOfRangeException("Invalid month");
            }
            _month = month;
        }
        //Sets the year
        public void SetYear(int year)
        {
            if (year < 1 || year > 9999)
            {
                throw new ArgumentOutOfRangeException("Invalid year");
            }
            _year = year;
        }
        //Get methods
        public int GetDay()
        {
            return _day;
        }

        public int GetMonth()
        {
            return _month;
        }
        public int GetYear()
        {
            return _year;
        }

        //Increases the day by 1 
        public MyDate NextDay()
        {
            if (_day == DAYS_IN_MONTH[_month]) //Checks if _day equals to the number of days in the month
            { //If true, _day will be set to 1 and the NextMonth() method will be called
                
                NextMonth();
                _day = 1;
            }
            else //If false, the day will just be incremented by 1
                _day++;
            return this;
        }

        //Increases the month by 1 
        public MyDate NextMonth()
        {
            if (_month == 12)
            {
                _month = 1;
                NextYear();
            }
            else
                _month++;
            return this;
        }

        //Increases the year by 1 
        public MyDate NextYear()
        {
            if (_year == 9999)
                throw new InvalidOperationException("Year out of range");
            _year++;
            if (_month == 2 && (_day == 28 || _day == 29))
            {
                if (IsLeapYear(_year))
                    _day = 29;
                else
                    _day = 28;
            }
            return this;
        }

        //Decreases the day by 1
        public MyDate PreviousDay()
        {
            if (_day == 1)
            {
                PreviousMonth();
                _day = DAYS_IN_MONTH[_month];
            }
            else
                _day--;
            return this;
        }

        //Decreases the month by 1
        public MyDate PreviousMonth()
        {
            if (_month == 1)
            {
                PreviousYear();
                _month = 12;
                
            }
            else
                _month--;
            if (_day > GetMaxDay(_month,_yesr))
            {
                DayOfWeek = GetMaxDay
            }
            return this;
        }

        //Decreases the year by 1
        public MyDate PreviousYear()
        {
            if (_year == 1)
                throw new InvalidOperationException("Year out of range");
            _year--;
            if (_month == 2 && (_day == 28 || _day == 29))
            {
                if (IsLeapYear(_year))
                    _day = 29;
                else
                    _day = 28;
            }
            return this;
        }

        //Returns a string in the main function representing the instances of myDate class
        public override string ToString()
        { 
            return DAYS[GetDayOfWeek(_day, _month, _year)] + " " + _day + " " + MONTHS[_month] + " " + _year;
        }

        //Calculates if a year is a leap year
        public static bool IsLeapYear(int year)
        {
            if (((year % 4 == 0) && ((year % 400 == 0) || (year % 100 != 0))))
                return true;
            return false;
        }

        //Calculates if a date is valid
        public static bool isValidDate(int year, int month, int day)
        {
            if (year < 0 || year > 9999 || month < 1 || month > 12 || day < 1 || day > 31)
                return false;
            if (month == 2 && (day > 29)) //Leap year
                return false;
            if (!IsLeapYear(year) && day > 28) //February has 28 days when not leap year
                return false;
            if (month == 4 || month == 6 || month == 9 || month == 11)
                if (day > 30) //Those months only have 30 days
                    return false;
            return true;
        }

        //Allows the program to display the day of the week
        public static int GetDayOfWeek(int day, int month, int year)
        {
            int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
            year -= (month < 3) ? 1 : 0; //If month < 3, then year is subtracted by 1, if not, year stays the same
            return (year + year / 4 - year / 100 + year / 400 + t[month - 1] + day) % 7;
        }
    }



}
