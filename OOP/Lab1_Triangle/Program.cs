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

            triangle.ShowInfo();
            Console.WriteLine(); 

            triangle.ChangeSides(6, 8, 10);
            triangle.ShowInfo();

            Console.ReadLine();
        }

    }
}
