using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithms
{
    public class AlgorithmGeneral
    {
        delegate void TimedAction();

        public static void ShowArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
            Console.WriteLine();
        }

        public static int[] GetRandomArray(int n, int startWith = 0)
        {
            int[] a = new int[n];
            for (int i = startWith; i < n; i++) a[i] = i;
            AlgorithmSort.RandomShuffle(a);
            return a;
        }


        public long GetRunningTime(TimedAction action)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            action.Invoke();
            stopwatch.Stop();

            return stopwatch.ElapsedMilliseconds;
        }
    }
}
