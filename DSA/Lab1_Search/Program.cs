using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Lab1_Search
{
    class Program
    {
        private static void Automatic()
        {
            int[] numbers;
            Random rand = new Random();
            for (int numElements = 100; numElements <= 1000; numElements += 100)
            {
                for (int j = 0; j < 10; j++)
                {
                    // Generating random array
                    numbers = AlgorithmGeneral.GetRandomArray(numElements);
                    Array.Sort(numbers);

                    // Selecting random key
                    int flag = rand.Next(2);
                    int key;
                    if (flag != 0) key = rand.Next(0, numElements);
                    else key = numElements;

                    // Outputing info and running algorithm
                    Console.WriteLine("Number of elements: " + numElements + ". key: " + key);
                    int pos1 = AlgorithmSearch.SearchBinary(numbers, key);
                }
            }
        }

        private static void Manual()
        {
            // Getting number of elements
            Console.Write("Enter number of elements: ");
            int numElements = Convert.ToInt32(Console.ReadLine());

            // Creating array of random numbers
            int[] numbers = new int[numElements];
            for (int i = 0; i < numbers.Length; i++) numbers[i] = i;
            AlgorithmGeneral.ShowArray(numbers);


            // Getting key
            Console.Write("Enter key: ");
            int key = Convert.ToInt32(Console.ReadLine());

            int pos;
            pos = AlgorithmSearch.SearchBinary(numbers, key);
            Console.WriteLine("Position: " + pos + " (Binary search)");
            pos = AlgorithmSearch.SearchBarrier(numbers, key);
            Console.WriteLine("Position: " + pos + " (Barrier search)");
        }

        static void Main(string[] args)
        {
            /*long time = AlgorithmGeneral.GetRunningTime(delegate()
            {
                Console.WriteLine(AlgorithmSearch.SearchIncremental(numbers, key));
            });
            Console.WriteLine("Search incremental: Time in milliseconds" + time); */

            Manual();

            Console.ReadLine();
        } 



    }

}
