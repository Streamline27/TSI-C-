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
            int[] numbers = AlgorithmGeneral.GetRandomArray(8);
            AlgorithmGeneral.ShowArray(numbers);

            Console.WriteLine(AlgorithmSearch.SearchIncremental(numbers, 2));

            Console.WriteLine(AlgorithmSearch.SearchBarrier(numbers, 2));
            Console.WriteLine(AlgorithmSearch.SearchBarrier(numbers, 2));

            Console.ReadLine();
        }

    }
}
