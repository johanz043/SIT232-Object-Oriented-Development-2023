    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisedCode
{
    internal class RevisedCode
    {

            static void Main(string[] args)
            {
                //Declares arrays
                string[] tasksIndividual = new string[0];
                string[] tasksWork = new string[0];
                string[] tasksFamily = new string[0];

                //Creates infinite loop
                while (true)
                {
                    Console.Clear(); // Clears terminal screen after each user input

                    //Determines the maximum number of tasks out of tasksIndividual, tasksWork and tasksFamily
                    //If tasksIndividual.Length is larger than tasksWork.Lenght then tasksIndividual.Length is assigned to max, else tasksWorth is assigned to max
                    int max = tasksIndividual.Length > tasksWork.Length ? tasksIndividual.Length : tasksWork.Length; 
                    //If max is larger than tasksFamily.Lenght then the value of max stays the same, else tasksFamily.Lenght is assigned to max
                    max = max > tasksFamily.Length ? max : tasksFamily.Length;

                    Console.ForegroundColor = ConsoleColor.Blue; //Sets console screen colour to blue
                    
                    //Displays headers
                    Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                    Console.WriteLine(new string(' ', 10) + new string('-', 94));
                    Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
                    Console.WriteLine(new string(' ', 10) + new string('-', 94));

                    //Loop which allows the program to display tasks
                    for (int i = 0; i < max; i++) //For each i < max, i + 1, for example when the max length increases, i is incremented to display inputs for an index
                    {
                        Console.Write("{0,10}|", i); //i represents the max length
                        DisplayTask(tasksIndividual, i);
                        DisplayTask(tasksWork, i);
                        DisplayTask(tasksFamily, i);
                        Console.WriteLine();
                    }

                    Console.ResetColor(); //Resets the console screen colour

                    Console.WriteLine("\nWhich category do you want to place a new task? Type 'Personal', 'Work', or 'Family'");
                    Console.Write(">> ");
                    string listName = Console.ReadLine().ToLower(); //All inputs are converted to lowercase letters so that the program can read it easier

                    Console.WriteLine("Describe your task below (max. 30 symbols).");
                    Console.Write(">> ");
                    string task = Console.ReadLine(); //the task variable is a string read from the user input

                    if (task.Length > 30) //Ensures that the maximum characters inputted is 30
                    {
                         task = task.Substring(0, 30);
                    }       

                    if (listName == "personal")
                    {   //taskIndividula is the array and task is the new value to be added
                        tasksIndividual = AddTask(tasksIndividual, task);
                    }
                    else if (listName == "work")
                    {
                        tasksWork = AddTask(tasksWork, task);
                    }
                    else if (listName == "family")
                    {
                        tasksFamily = AddTask(tasksFamily, task);
                    }
                    else
                    {
                        //Data validation
                        Console.WriteLine("Invalid category. Please choose 'Personal', 'Work', or 'Family'.");
                    }

                    Console.ReadLine();
                }
            }

            //Displays an inputted task at a specific index
            static void DisplayTask(string[] tasks, int index)
            {
                if (tasks.Length > index)
                {
                    Console.Write("{0,30}|", tasks[index]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }
            }
            
            //Adds a task to a category's array
            static string[] AddTask(string[] tasks, string task)
            {
                //Pass by reference
                Array.Resize(ref tasks, tasks.Length + 1); //Increases the array length by 1 to input a new task
                tasks[tasks.Length - 1]  = task; //Adds the task to the end of the array
                return tasks; //Returns the array
            }
        }


    }

