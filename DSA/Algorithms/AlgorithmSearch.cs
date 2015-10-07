using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmSearch
    {
        private static String path = @"C:\Users\Vladislav\Desktop\SearchingLog.txt";

        public static int SearchIncremental(int[] a, int key)
        {
            int n = a.Length;
            int i = 0;
            while ((a[i] != key) && (i < n)) i++;
            if (i == n) return -1;
            else return i;
        }

        public static int SearchBarrier(int[] a, int key)
        {
            // Adding barrier
            int lastIndex = a.Length - 1;
            if (a[lastIndex] == key)
            {
                String msg = "Incremental Search. Elements: " + a.Length + ". Number of compares: " + 1 + " (Key: " + key + ")";
                Console.WriteLine(msg);
                //WriteToFile(msg);
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
            //WriteToFile("Incremental Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");
            Console.WriteLine("Incremental Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");

            // Removing barier
            a[lastIndex] = tmp;
            // Returning the result
            if (i == lastIndex) return -1;
            else return i;
        }

        public static int SearchBinaryRecursive(int[] a, int key){
            return SearchBinaryRecursive(a, key, 0, a.Length-1);
        }

        private static int SearchBinaryRecursive(int[] a, int key, int lo, int hi)
        {
            if (hi == lo && a[hi] != key) return -1;
            int current = (hi + lo) / 2;
            if (a[current] > key)  return SearchBinaryRecursive(a, key, lo, current - 1);
            if (a[current] < key)  return SearchBinaryRecursive(a, key, current + 1, hi);
            if (a[current] == key) return current;
            return -1;
        }

        public static int SearchBinary(int[] a, int key)
        {
            int counter = 0; //Schetchik

            int lo = 0;
            int hi = a.Length-1;
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
            /* Writting results to logs */
            //WriteToFile("Binary      Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");
            Console.WriteLine("Binary      Search. Elements: " + a.Length + ". Number of compares: " + counter + " (Key: " + key + ")");
            if (a[current] == key) return current;
            return -1;
        }

        private static void WriteToFile(String message)
        {
            Console.WriteLine(message);
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, true);
            file.WriteLine(message);
        }
    }



}
