using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            RightTriangle triangle = new RightTriangle(8, 6);
            triangle.WriteLine();
            Console.WriteLine("Triangle to string: "+triangle.ToString());

            Rectangle rect = new Rectangle(8, 6);
            rect.WriteLine();
            Console.WriteLine("Rectangle to string: " +  rect.ToString());

            Console.ReadLine();
                
        }
    }
}
