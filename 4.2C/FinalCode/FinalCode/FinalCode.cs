using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    public class Task //Constructor
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsImportant { get; set; }
    }

    public class Category //Constructor
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; } = new List<Task>();
    }

    class Program
    {
        static List<Category> categories = new List<Category>();

        static void Main(string[] args)
        {
            while (true)
            {

                Console.Clear(); //Clears console screen
                DisplayTasks(); //Displays tasks
                Console.WriteLine("\n");
                DisplayMenu(); //Displays the menu and prompts the user to choose an option
                string option = Console.ReadLine(); //Reads the user input

                switch (option) //Executes a function depending on user input
                {
                    case "1":
                        AddCategory();
                        break;
                    case "2":
                        DeleteCategory();
                        break;
                    case "3":
                        AddTask();
                        break;
                    case "4":
                        DeleteTask();
                        break;
                    case "5":
                        PrioritizeTask();
                        break;
                    case "6":
                        MoveTask();
                        break;
                    case "7":
                        HighlightTask();
                        break;
                    case "8":
                        Console.WriteLine("Goodbye");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("Press Enter to continue..."); //Since the program won't continue without user input
                Console.ReadLine();
            }
        }

        static void DisplayMenu() //Displays user options
        {
            Console.WriteLine("Task Planner Menu");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Delete Category");
            Console.WriteLine("3. Add Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Prioritize Task");
            Console.WriteLine("6. Move Task");
            Console.WriteLine("7. Highlight Task");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");
        }

        static void AddCategory() //Adds a category
        {
            Console.Write("Enter the category name: "); //Prompts the user to enter a catagory name
            string categoryName = Console.ReadLine(); //Reads the user input

            if (!categories.Any(catagory => catagory.Name == categoryName)) //Checks if the category name already exists
            {   //"!" ensures that if there is no pre-existing name, the following code will be executed
                categories.Add(new Category { Name = categoryName });
                Console.WriteLine($"Category '{categoryName}' added successfully.");
            }
            else //If the name already exists, then the program will say so
            {
                Console.WriteLine($"Category '{categoryName}' already exists.");
            }
        }

        static void DeleteCategory() //Deletes a category
        {
            Console.Write("Enter the category name to delete: ");
            string categoryName = Console.ReadLine();
            //FirstOrDefault is used to retreive the first element from a sequence
            Category categoryToRemove = categories.FirstOrDefault(catagory => catagory.Name == categoryName); //Finds category to remove

            if (categoryToRemove != null) //Checks if category exists
            {   //The following code is executed if it exists
                categories.Remove(categoryToRemove);
                Console.WriteLine($"Category '{categoryName}' and its tasks have been deleted.");
            }
            else
            {
                Console.WriteLine($"Category '{categoryName}' not found.");
            }
        }

        static void AddTask() //Adds a task within a category
        {
            Console.Write("Enter the category name to add the task: "); //Prompts the user to input a category name for the new task to be placed in
            string categoryName = Console.ReadLine();

            Category category = categories.FirstOrDefault(catagory => catagory.Name == categoryName); //Finds the category
            if (category != null) //Checks if the category exists
            {
                Console.Write("Enter the task name: "); //Prompts the user to name the task
                string taskName = Console.ReadLine();
                Console.Write("Enter the due date (yyyy-mm-dd): "); //Prompts the user to set the due date (It be set in American units)
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate)) //Converts to date/time units
                {
                    Console.Write("Is this task important? (yes/no): "); //Prompts the user to select if the task is important
                    bool Important = Console.ReadLine().ToLower() == "yes"; //Important is boolean

                    category.Tasks.Add(new Task
                    {
                        Name = taskName,
                        DueDate = dueDate,
                        IsImportant = Important
                    });

                    Console.WriteLine("Task added successfully.");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Task not added.");
                }
            }
            else
            {
                Console.WriteLine($"Category '{categoryName}' not found.");
            }
        }

        static void DeleteTask() //Deletes a task within a category
        {
            Console.Write("Enter the category name to delete a task from: "); //Prompts the user to enter an existing category name
            string categoryName = Console.ReadLine();
            Category category = categories.FirstOrDefault(catagory => catagory.Name == categoryName); //Finds the catagory
            if (category != null) //Checks if it exists
            {
                Console.Write("Enter the task name to delete: "); //Prompts the user to input an existing task
                string taskName = Console.ReadLine();
                Task taskToRemove = category.Tasks.FirstOrDefault(task => task.Name == taskName); //Finds the task
                if (taskToRemove != null) //Checks if it exists
                {
                    category.Tasks.Remove(taskToRemove); //Removes task in a category
                    Console.WriteLine($"Task '{taskName}' deleted.");
                }
                else
                {
                    Console.WriteLine($"Task '{taskName}' not found.");
                }
            }
            else
            {
                Console.WriteLine($"Category '{categoryName}' not found.");
            }
        }

        static void PrioritizeTask() //Prioritizes a task in a category (switches the tasks around)
        {
            Console.Write("Enter the category name to prioritize a task in: "); //Prompts user to enter a category name
            string categoryName = Console.ReadLine();
            Category category = categories.FirstOrDefault(catagory => catagory.Name == categoryName); //Finds catagory
            if (category != null) //Checks if it exists
            {
                Console.Write("Enter the task name to prioritize: ");
                string taskName = Console.ReadLine();
                Task taskToPrioritize = category.Tasks.FirstOrDefault(task => task.Name == taskName); //Checks if task exists
                if (taskToPrioritize != null)
                {
                    Console.Write("Enter the new priority (integer): "); //Prompts the user to choose an existing integer within the catagory where he wants the selected task to go
                    if (int.TryParse(Console.ReadLine(), out int newPriority)) //Reads user input and converts it to int
                    {
                        category.Tasks.Remove(taskToPrioritize);
                        category.Tasks.Insert(newPriority, taskToPrioritize);
                        Console.WriteLine($"Task '{taskName}' prioritized.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid priority format.");
                    }
                }
                else
                {
                    Console.WriteLine($"Task '{taskName}' not found.");
                }
            }
            else
            {
                Console.WriteLine($"Category '{categoryName}' not found.");
            }
        }

        static void MoveTask() //Moves tasks between categories
        {
            Console.Write("Enter the current category name of the task: ");
            string currentCategoryName = Console.ReadLine();
            Category currentCategory = categories.FirstOrDefault(catagory => catagory.Name == currentCategoryName); //Finds
            if (currentCategory != null) //Checks
            {
                Console.Write("Enter the task name to move: ");
                string taskName = Console.ReadLine();
                Task taskToMove = currentCategory.Tasks.FirstOrDefault(task => task.Name == taskName); //Finds
                if (taskToMove != null) //Checks
                {
                    Console.Write("Enter the new category name: ");
                    string newCategoryName = Console.ReadLine();
                    Category newCategory = categories.FirstOrDefault(catagory => catagory.Name == newCategoryName); //Finds
                    if (newCategory != null) //Checks
                    {
                        //Moves
                        currentCategory.Tasks.Remove(taskToMove);
                        newCategory.Tasks.Add(taskToMove);
                        Console.WriteLine($"Task '{taskName}' moved to '{newCategoryName}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Category '{newCategoryName}' not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"Task '{taskName}' not found in '{currentCategoryName}'.");
                }
            }
            else
            {
                Console.WriteLine($"Category '{currentCategoryName}' not found.");
            }
        }

        static void HighlightTask() //Highlights a task (highlights it red)
        {
            Console.Write("Enter the category name to highlight a task in: ");
            string categoryName = Console.ReadLine();
            Category category = categories.FirstOrDefault(catagory => catagory.Name == categoryName);
            if (category != null)
            {
                Console.Write("Enter the task name to highlight: ");
                string taskName = Console.ReadLine();
                Task taskToHighlight = category.Tasks.FirstOrDefault(task => task.Name == taskName);
                if (taskToHighlight != null)
                {
                    taskToHighlight.IsImportant = true;
                    Console.WriteLine($"Task '{taskName}' is now highlighted.");
                    //This function is not responsible for turning the text red
                    //It is responsible for passing taskToHighlight.IsImportant = true
                    //DisplayTasks() is responsible for highlighting
                }
                else
                {
                    Console.WriteLine($"Task '{taskName}' not found.");
                }
            }
            else
            {
                Console.WriteLine($"Category '{categoryName}' not found.");
            }
        }

        static void DisplayTasks() //Displays every category and task
        {
            Console.WriteLine("Category-wise Task List:");
            foreach (var category in categories)
            {
                //Displays each category
                Console.WriteLine();
                Console.WriteLine(new string('-', 70));
                Console.WriteLine($"{category.Name} Category:");
                Console.WriteLine(new string('-', 70));

                if (category.Tasks.Count == 0) //Checks if each category has tasks
                {
                    Console.WriteLine("No tasks in this category.");
                }
                else
                {   //The terminal will display each category's tasks
                    for (int i = 0; i < category.Tasks.Count; i++)
                    {
                        string priority = i.ToString();
                        string importance = category.Tasks[i].IsImportant ? " (Important)" : "";
                        string taskName = category.Tasks[i].Name;
                        DateTime dueDate = category.Tasks[i].DueDate;

                        // Set text color to red for important tasks
                        if (category.Tasks[i].IsImportant)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //Hoghlights the text red
                        }

                        Console.WriteLine($"{priority}. {taskName}{importance}, Due: {dueDate:yyyy-MM-dd}");

                        // Reset text color to default
                        Console.ResetColor();
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
