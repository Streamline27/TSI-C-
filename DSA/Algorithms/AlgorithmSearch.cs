using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AlgorithmSearch
    {
        public static int SearchIncremental(int[] a, int key)
        {
            int n = a.Length;
            int i = 0;
            while ((a[i] != key) && (i < n)) i++;
            if (i == key) return i;
            else return -1;
        }

        public static int SearchBarrier(int[] a, int key)
        {
            // Adding barrier
            int lastIndex = a.Length - 1;
            if (a[lastIndex] != key) a[lastIndex] = key;
            else return a.Length - 1;

            // Searching for key
            int i = 0;
            while (a[i] != key) i++;
            if (i == lastIndex) return -1;
            else return i;
        }
    }
}
