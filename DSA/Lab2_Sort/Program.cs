using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Sort
{
    class Program
    {
        public static int InsertionSort(int[] a)
        {
            int schetchik = 0;
            for (int i = 1; i < a.Length; i++)
            {
                int k = i;
                while (k > 0 && a[k] < a[k - 1])
                {
                    int tmp = a[k - 1];
                    a[k - 1] = a[k];
                    a[k] = tmp;
                    k--;
                    schetchik += 2;
                }
                schetchik++;
            }
            return schetchik;
        }


        private static int getBinDigit(int number, int rank)
        {
            return (number & (1 << rank)) >> rank;
        }

        public static int RadixSort(int[] a){
            int[] b = new int[a.Length];
            int numIterations = Convert.ToString(a.Max(), 2).Length;

            int schetchik = 0;

            for (int digit = 0; digit < numIterations; digit++)
			{
                int indexB = 0;
                for (int m = 0; m < 2; m++)
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        if (getBinDigit(a[i], digit)==m)
                        {
                            b[indexB] = a[i];
                            indexB += 1;
                        }
                        schetchik++;
                    }
                    schetchik++;
                }
                schetchik++;
                for (int i = 0; i < a.Length; i++)
                {
                    schetchik++;
                    a[i] = b[i];
                }
			}
            return schetchik;
        }

        
        static void Main(string[] args)
        {
            
            Console.Write("Enter number of elements (0 for deffault): ");
            int n = Convert.ToInt32(Console.ReadLine());

            // Creating random array
            int[] a;
            if (n == 0) a = GetRandomArray(6, 0);
            else 
            {
                // Reading data to array
                a = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write((i + 1) + ". ");
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
            }

            // Creating array coppy for Insertion sort
            int[] b = new int[a.Length];
            Array.Copy(a, b, a.Length);

            Console.WriteLine("Insertion sort: ");
            InsertionSort(b);
            Show(b);

            Console.WriteLine("Radix sort: ");
            RadixSort(a);
            Show(a);
            
            Console.ReadLine();
        }

        /* ******************************************************************* */
        /* ******************   Misc. functionality    *********************** */

        static private void ShowBinary(int[] a)
        {
            for (int i = 0; i < a.Length; i++) Console.WriteLine(Convert.ToString(a[i], 2));
            Console.WriteLine();
        }


        static private void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        public static int[] GetRandomArray(int n, int startWith = 0)
        {
            Random random = new Random();
            int[] a = new int[n];
            for (int i = startWith; i < n; i++) a[i] = i;
            for (int i = 1; i < a.Length; i++)
            {
                int pos = random.Next(i + 1);
                int tmp = a[pos];
                a[pos] = a[i];
                a[i] = tmp;
            }
            return a;
        }
    }
}
