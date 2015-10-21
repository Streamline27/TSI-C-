using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Rectangle
{
    class Pair
    {
        public int A {get; set;}
        public int B {get; set;}

        public Pair(int a, int b)
        {
            this.A = a;
            this.B = b;
        }

        public int Sum
        {
            get
            {
                return A + B;
            }
        }

        public void WriteAB()
        {
            Console.WriteLine("A: " + A + " B: " + B);
        }
    }

}
