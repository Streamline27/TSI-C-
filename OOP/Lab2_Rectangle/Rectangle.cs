using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Rectangle
{
    class Rectangle : Pair
    {
        public Rectangle(int a, int b) : base(a, b) { }

        public virtual int Perimeter
        {
            get
            {
                return Sum * 2;
            }
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("Demo.");
            Console.Write("Rectangle: ");
            WriteAB();
            Console.WriteLine("Property Perimeter: " + Perimeter);
            Console.WriteLine("Inherited property A: " + A);
            Console.WriteLine("Īnherited property B: " + B);
            Console.WriteLine("Inherited method sum: " + Sum);

        }
    }
}
