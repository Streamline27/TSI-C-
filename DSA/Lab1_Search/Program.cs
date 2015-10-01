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
        static void Main(string[] args)
        {
            // Hello
            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(AlgorithmSearch.SearchIncremental(numbers, 2));
            Console.WriteLine(AlgorithmSearch.SearchBarrier(numbers, 2));
            Console.WriteLine(AlgorithmSearch.SearchBarrier(numbers, 2));

            Console.ReadLine();
        }

    }
}
