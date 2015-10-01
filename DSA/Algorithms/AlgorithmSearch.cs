﻿using System;
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
            if (i == n) return -1;
            else return i;
        }

        public static int SearchBarrier(int[] a, int key)
        {
            // Adding barrier
            int lastIndex = a.Length - 1;
            if (a[lastIndex] == key) return lastIndex;
            int tmp = a[lastIndex];
            a[lastIndex] = key;

            // Searching for key
            int i = 0;
            while (a[i] != key) i++;

            // Removing barier
            a[lastIndex] = tmp;
            // Returning the result
            if (i == lastIndex) return -1;
            else return i;
        }
    }
}
