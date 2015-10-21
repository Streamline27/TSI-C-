using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Sort
{



    class Program
    {

        public static void InsertionSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int k = i;
                while (k > 0 && a[k] < a[k - 1])
                {
                    int tmp = a[k-1];
                    a[k - 1] = a[k];
                    a[k] = tmp;
                    k--;
                }
            }
        }

        private static int getDigit(int number, int rank){
            int a = 1;
            for (int i = 1; i < rank; i++) a*=10;
            return (number /  a) % 10;
        }


        static private bool Odinakovie(int[] a)
        {
            //for (int i = 1; i < a.Length; i++) if (a[i - 1] != a[i]) return false;
            for (int i = 0; i < a.Length; i++) if (a[i] != 6) return false;
            return true;
        }

        static private void Show(int[] a)
        {
            for (int i = 0; i < a.Length; i++) Console.Write(a[i]);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            
   
            int[] randoms = new int[10];

            int together = 0;

            for (int j = 0; j < 1; j++)
            {

                int count = 0 ;

                do
                {
                    for (int i = 0; i < randoms.Length; i++) randoms[i] = rand.Next(1, 7);
     //               Show(randoms);
                    count++;
                } while (!Odinakovie(randoms));
                together += count;

            }


            Console.WriteLine("Counter YOLO: " + together/1000);
            Console.ReadLine();
        }


    }
}
