using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure triangle = new RightTriangle(8, 6);
            triangle.WriteLine();
            Console.WriteLine("Triangle to string: " + triangle.ToString());

            Figure rect = new Rectangle(8, 6);
            rect.WriteLine();
            Console.WriteLine("Rectangle to string: " + rect.ToString());

            Console.ReadLine();
                

        }
    }
}
