using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Rectangle
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Demo pair.");
            Pair pair = new Pair(3, 3);
            pair.WriteAB();
            Console.WriteLine();

            Console.WriteLine("Demo Rectangle.");
            Rectangle rect = new Rectangle(15, 15);
            rect.ShowInfo();

            Console.ReadLine();
        }
    }
}
