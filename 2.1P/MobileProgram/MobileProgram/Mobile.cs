﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileProgram
{
    class Mobile
    {
        //Instance variable
        private String accType, device, number;
        private double balance;

        //Variables
        private const double CALL_COST = 0.245;
        private const double TEXT_COST = 0.078;

        public Mobile(string accType, string device, string number)
        {
            this.accType = accType;
            this.device = device;
            this.number = number;
            this.balance = 0.0;
        }

        //Accessor Methods
        public String getAccType()
        {
            return this.accType;
        }
        public String getDevice()
        {
            return this.device; 
        }
        public String getNumber()
        {
            return this.number;
        }
        public String getBalance()
        {
            return this.balance.ToString("C");
        }


        //Mutator Methods
        public void setAccType(String accType)
        {
            this.accType = accType;
        }
        public void setDevice(String device)
        {
            this.device = device;
        }
        public void setNumber(String number)
        {
            this.number = number;
        }
        public void setBalance(double balance)
        { 
            this.balance = balance;
        }


        //Methods
        public void addCredit(double amount)
        {
            this.balance += amount;
            Console.WriteLine("Credit added successfully. New balance " + getBalance());
        }
        public void makeCall(int minutes)
        {
            double cost = minutes * CALL_COST;
            this.balance -= cost;
            Console.WriteLine("Call made. New balance " + getBalance());
        }
        public void sendText(int numTexts)
        {
            double cost = numTexts * TEXT_COST;
            this.balance -= cost;
            Console.WriteLine("Text Sent. New balance " + getBalance());
        }


    }

    


}

