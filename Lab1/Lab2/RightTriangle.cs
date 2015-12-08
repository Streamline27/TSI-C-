using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class RightTriangle
    {
        public virtual double A { get; set; }
        public virtual double B { get; set; }

        public virtual double Perimeter
        {
            get
            {
                double C = Math.Sqrt(A * A + B * B);
                return A+B+C;
            }

        }

        public RightTriangle(double sideA, double sideB){
            A = sideA;
            B = sideB;
        }

        public virtual void WriteLine()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return "Side1 = " + A + " Side2 = " + B + " Perimeter = " + Perimeter;
        }
    }
}
