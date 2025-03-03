using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_and_lists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double[] myArray = new double[10];

            /**
            myArray[0] = 1.0;
            myArray[1] = 1.1;
            myArray[2] = 1.2;
            myArray[3] = 1.3;
            myArray[4] = 1.4;
            myArray[5] = 1.5;
            myArray[6] = 1.6;
            myArray[7] = 1.7;
            myArray[8] = 1.8;
            myArray[9] = 1.9;

            Console.WriteLine("The element at index 0 is " + myArray[0]);
            Console.WriteLine("The element at index 1 is " + myArray[1]);
            Console.WriteLine("The element at index 2 is " + myArray[2]);
            Console.WriteLine("The element at index 3 is " + myArray[3]);
            Console.WriteLine("The element at index 4 is " + myArray[4]);
            Console.WriteLine("The element at index 5 is " + myArray[5]);
            Console.WriteLine("The element at index 6 is " + myArray[6]);
            Console.WriteLine("The element at index 7 is " + myArray[7]);
            Console.WriteLine("The element at index 8 is " + myArray[8]);
            Console.WriteLine("The element at index 9 is " + myArray[9]);
            **/

            /**
            for (int i = 0; i < 10; i++)
            {
                myArray[i] = i;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("The element at position " + i + " in the array is " + myArray[i]);
            }
            **/

            /**
            int[] studentArray = { 87, 68, 94, 100, 83, 78, 85, 91, 76, 87 };
            int total = 0;

            for (int i = 0; i < studentArray.Length; i++) 
            {
                total += studentArray[i];
            }

            Console.WriteLine("The total marks for the student is: " + total);
            Console.WriteLine("This consists of " + studentArray.Length + " marks");
            Console.WriteLine("Therefore the average mark is " + (total/studentArray.Length));
            **/

            /**
            string[] studentNames = new string[6];
            
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.Write($"Enter name for student {i + 1}: ");
                studentNames[i] = Console.ReadLine();
            }

            Console.WriteLine("\nEntered Student Names:");
            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.WriteLine($"Student {i + 1}: {studentNames[i]}");
            }
            **/

            /**
            double[] numbers = new double[10];

            
            double currentLargest;
            double currentSmallest;

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write($"Enter value {i + 1}: ");
                numbers[i] = Convert.ToDouble(Console.ReadLine());    
            }


            Console.WriteLine("\nArray Elements:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"The element at position {i + 1} is {numbers[i]}");
            }


            // Initialize currentLargest and currentSmallest with the first element of the array
            currentLargest = numbers[0];
            currentSmallest = numbers[0];

            // Find the largest and smallest values in the array
            for (int currentSize = 0; currentSize < numbers.Length; currentSize++)
            {
                if (numbers[currentSize] > currentLargest)
                {
                    currentLargest = numbers[currentSize];
                }
                else if (numbers[currentSize] < currentSmallest)
                {
                    currentSmallest = numbers[currentSize];
                }
            }

            // Print the largest and smallest values
            Console.WriteLine($"\nLargest Value: {currentLargest}");
            Console.WriteLine($"Smallest Value: {currentSmallest}");
            **/

            /**
            // Declare and initialize a 2-dimensional array with 3 rows and 4 columns
            int[,] myArray = new int[3, 4] { { 1, 2, 3, 4 }, { 1, 1, 1, 1 }, { 2, 2, 2, 2 } };

            // Loop through each row and column to print the contents
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    Console.WriteLine(myArray[i, j] + "\t");
                }
            }
            **/

            /**
            List<String> myStudentList = new List<String>();

            Random randomvalue = new Random();
            int randomNumber = randomvalue.Next(1, 12);

            Console.WriteLine("You now need to add " + randomNumber + " students to your class list");
            for (int i = 0; i < randomNumber; i++)
            {
                Console.Write("Please enter the name of the student " + (i + 1) + ": ");
                myStudentList.Add(Console.ReadLine());
                Console.WriteLine();
            }

            for (int i = 0; i < myStudentList.Count; i++)
            {
                Console.WriteLine("Student " + (i + 1) + ": " + myStudentList[i]);
            }
            **/

            /**
            int[] array1 = { 1, 2, 2, 1 };
            int[] array2 = { 1, 2, 3, 1, 3, 2, 1 };
            int[] array3 = { 3, 2, 1 };

            Console.WriteLine("Array 1 is a palindrome: " + Palindrome(array1));
            Console.WriteLine("Array 2 is a palindrome: " + Palindrome(array2));
            Console.WriteLine("Array 3 is a palindrome: " + Palindrome(array3));

            Console.ReadLine();
            **/

            /**
            List<int> listA = new List<int> { 1, 2, 2, 5 };
            List<int> listB = new List<int> { 1, 3, 4, 5, 7 };
            List<int> listC = new List<int> { 5, 2, 2, 1 };
            List<int> listD = new List<int> { };

            List<int> mergedListAB = Merge(listA, listB);
            List<int> mergedListCD = Merge(listC, listD);

            Console.WriteLine("Merged List AB: " + string.Join(", ", mergedListAB));
            Console.WriteLine("Merged List CD: " + (mergedListCD == null ? "null" : string.Join(", ", mergedListCD)));

            Console.ReadLine();
            **/

            int[,] array = {
                { 0, 2, 4, 0, 9, 5 },
                { 7, 1, 3, 3, 2, 1 },
                { 1, 3, 9, 8, 5, 6 },
                { 4, 6, 7, 9, 1, 0 }
            };

            int[] result = ArrayConversion(array);

            Console.WriteLine("Resulting one-dimensional array: " + string.Join(", ", result));

            Console.ReadLine();


        }

        /**
        static bool Palindrome(int[] array)
        {
            int length = array.Length;

            // Check if the length of the array is less than 1
            if (length < 1)
            {
                return false;
            }

            for (int i = 0; i < length / 2; i++)
            {
                // Compare the elements from the start and end of the array
                if (array[i] != array[length - 1 - i])
                {
                    return false; // Not a palindrome
                }
            }

            return true; // It's a palindrome
        }
        **/

        /**
        static List<int> Merge(List<int> list_a, List<int> list_b)
        {
            // Check if both input lists are sorted
            bool isSortedA = list_a.SequenceEqual(list_a.OrderBy(x => x));
            bool isSortedB = list_b.SequenceEqual(list_b.OrderBy(x => x));

            if (!isSortedA || !isSortedB)
            {
                return null; // At least one list is unsorted
            }

            // Merge the sorted lists and return the result
            List<int> mergedList = new List<int>();
            int i = 0, j = 0;

            while (i < list_a.Count && j < list_b.Count,)
            {
                if (list_a[i] < list_b[j])
                {
                    mergedList.Add(list_a[i]);
                    i++;
                }
                else
                {
                    mergedList.Add(list_b[j]);
                    j++;
                }
            }

            // Add remaining elements from both lists
            while (i < list_a.Count)
            {
                mergedList.Add(list_a[i]);
                i++;
            }

            while (j < list_b.Count)
            {
                mergedList.Add(list_b[j]);
                j++;
            }

            return mergedList;
        }
        **/

        static int[] ArrayConversion(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            int[] result = new int[rows * cols];
            int index = 0;

            // Loop through columns and rows, extracting odd values
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    int value = array[row, col];
                    if (value % 2 != 0)
                    {
                        result[index] = value;
                        index++;
                    }
                }
            }

            // Resize the result array to the actual number of odd values extracted
            Array.Resize(ref result, index);

            return result;

        }
    }
}
