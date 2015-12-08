using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Rectangle : RightTriangle
    {
        public Rectangle(int sideA, int sideB) : base(sideA, sideB) { }

        public override double Perimeter
        {
            get
            {
                return (A + B)*2;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
