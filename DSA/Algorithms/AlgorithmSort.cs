using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmSort
    {
        public static void RandomShuffle(int[] a)
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

        public static void InsertionSort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                int k = i;
                while (k > 0 && a[k] > a[k - 1])
                {
                    int tmp = a[k-1];
                    a[k - 1] = a[k];
                    a[k] = tmp;
                    k--;
                }
            }
        }
    }
}
