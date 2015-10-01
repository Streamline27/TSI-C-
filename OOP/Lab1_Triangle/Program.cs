using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(3, 4, 5, 30, 90, 60);
            Console.WriteLine(triangle.Area);


            Console.WriteLine(triangle.Side1);
            Console.WriteLine(triangle.Side2);
            Console.WriteLine(triangle.Side3);
            Console.WriteLine(triangle.ToString());
            Console.ReadLine();

        }
    }
}
