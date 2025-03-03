using System;

namespace DuplicateCode
{
    class DuplicateCode
    {

        static void Main(string[] args)
        {
            string[] tasksIndividual = new string[0], tasksWork = new string[0], tasksFamilly = new string[0];

            while (true)
            {
                Console.Clear();
                int max = tasksIndividual.Length > tasksWork.Length ? tasksIndividual.Length : tasksWork.Length;
                max = max > tasksFamilly.Length ? max : tasksFamilly.Length;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(new string(' ', 12) + "CATEGORIES");
                Console.WriteLine(new string(' ', 10)+new string('-', 94));
                Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
                Console.WriteLine(new string(' ', 10) + new string('-', 94));
                for (int i = 0; i < max; i++)
                {
                    Console.Write("{0,10}|", i);
                    //Duplication because the if satatement is repeated for each array
                    if (tasksIndividual.Length > i)
                    {
                        Console.Write("{0,30}|", tasksIndividual[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (tasksWork.Length > i)
                    {
                        Console.Write("{0,30}|", tasksWork[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }

                    if (tasksFamilly.Length > i)
                    {
                        Console.Write("{0,30}|", tasksFamilly[i]);
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }
                    Console.WriteLine();
                }

                Console.ResetColor(); Console.WriteLine("\nWhich category do you want to place a new task? Type \'Personal\', \'Work\', or \'Family\'");
                Console.Write(">> "); string listName = Console.ReadLine().ToLower();
                Console.WriteLine("Describe your task below (max. 30 symbols)."); Console.Write(">> ");
                string task = Console.ReadLine(); 
                if (task.Length > 30) task = task.Substring(0, 30);

                string[] goalsIndividualNew = null;
                if (listName == "personal")

                {
                    //Duplication because it creates new arrays
                    // Create a new array with a length one greater than tasksIndividual.
                    goalsIndividualNew = new string[tasksIndividual.Length + 1];
                    // Copy the contents of tasksIndividual to the new array.
                    for (int j = 0; j < tasksIndividual.Length; j++)
                    goalsIndividualNew[j] = tasksIndividual[j];
                    // Add the new task to the end of the new array.
                    goalsIndividualNew[goalsIndividualNew.Length - 1] = task;
                    // Update the reference of tasksIndividual to point to the new array.
                    tasksIndividual = goalsIndividualNew;
                }
                else if (listName == "work") {
                    string[] goalsWorkNew = new string[tasksWork.Length + 1];
                    for (int j = 0; j < tasksWork.Length; j++) { goalsWorkNew[j] = tasksWork[j]; }
                    goalsWorkNew[goalsWorkNew.Length - 1] = task; tasksWork = goalsWorkNew;
                } else if (listName == "family")
                {
                    string[] goalsFamillyNew = new string[tasksFamilly.Length + 1];
                    for (int j = 0; j < tasksFamilly.Length; j++)
                    {
                        goalsFamillyNew[j] = tasksFamilly[j];
                    } goalsFamillyNew[goalsFamillyNew.Length - 1] = task;
                    tasksFamilly = goalsFamillyNew;


                    
                }
            }
            
        }
        
    }
   
}

