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
                    numbers = GetRandomArray(numElements);
                    Array.Sort(numbers);

                    // Selecting random key
                    int flag = rand.Next(2);
                    int key;
                    if (flag != 0) key = rand.Next(0, numElements);
                    else key = numElements;

                    // Outputing info and running algorithm
                    Console.WriteLine("Number of elements: " + numElements + ". key: " + key);
                    int pos1 = SearchBinary(numbers, key);
                }
            }
        }

        private static void Manual()
        {
            // Getting number of elements
            Console.Write("Enter number of elements: ");
            int numElements = Convert.ToInt32(Console.ReadLine());

            // Creating array of random numbers
            int[] numbers = GetRandomArray(numElements);

            // Getting key
            Console.Write("Enter key: ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            ShowArray(numbers);

            // Barrier search
            int pos;
            pos = SearchBarrier(numbers, key);
            Console.WriteLine("Position: " + pos + " (Barrier search)");

            // Binary search
            Console.WriteLine();
            Array.Sort(numbers);
            ShowArray(numbers);
            pos = SearchBinary(numbers, key);
            Console.WriteLine("Position: " + pos + " (Binary search)");
        }

        private static int[] GetRandomArray(int n, int startWith = 0)
        {
            int[] a = new int[n];
            for (int i = startWith; i < n; i++) a[i] = i;
            RandomShuffle(a);
            return a;
        }

        private static void RandomShuffle(int[] a)
        {
            Random random = new Random();
            for (int i = 1; i < a.Length; i++)
            {
                int pos = random.Next(i + 1);
                int tmp = a[pos];
                a[pos] = a[i];
                a[i] = tmp;
            }
        }

        private static void ShowArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        private static int SearchBinary(int[] a, int key)
        {
            int counter = 0; //Schetchik

            int lo = 0;
            int hi = a.Length - 1;
            int current = 0;
            while (a[current] != key && hi >= lo)
            {
                counter += 2; // Schetchik

                current = (hi + lo) / 2;
                if (a[current] > key)
                {
                    hi = current - 1;
                    counter++; // Schetchik
                }
                if (a[current] < key)
                {
                    lo = current + 1;
                    counter++; // Schetchik
                }
            }

            counter++; // Schetchik
            Console.WriteLine("Binary      Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");
            if (a[current] == key) return current;
            return -1;
        }

        private static int SearchBarrier(int[] a, int key)
        {
            // Adding barrier
            int lastIndex = a.Length - 1;
            if (a[lastIndex] == key)
            {
                String msg = "Incremental Search. Elements: " + a.Length + ". Number of compares: " + 1 + " (Key: " + key + ")";
                Console.WriteLine(msg);
                return lastIndex;
            }
            int tmp = a[lastIndex];
            a[lastIndex] = key;

            int counter = 1;

            // Searching for key
            int i = 0;
            while (a[i] != key)
            {
                counter++;
                i++;
            }
            counter++;

            /* Writting results to logs */
            Console.WriteLine("Incremental Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");

            // Removing barier
            a[lastIndex] = tmp;
            // Returning the result
            if (i == lastIndex) return -1;
            else return i;
        }


        static void Main(string[] args)
        {
            Manual();
            Console.ReadLine();
        } 



    }

}
