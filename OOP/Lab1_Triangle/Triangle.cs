using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Triangle
{
    //                  ravnostorinniy ravnobedrenniy
    enum TriangleType { equilaterial, isosceles, right, regular}

    class Triangle
    {
        /* Fields */
        private double side1, side2, side3;
        private double angle1, angle2, angle3;

        /* Propetries */
        public double Side1
        {
            get { return side1; }
            private set { side1 = value; }
        }
        public double Side2
        {
            get { return side2; }
            private set { side2 = value; }
        }
        public double Side3
        {
            get { return side3; }
            private set { side3 = value; }
        }
        public double Angle1
        {
            get { return angle1; }
            private set { angle1 = value; }
        }
        public double Angle2
        {
            get { return angle2; }
            private set { angle2 = value; }
        }
        public double Angle3
        {
            get { return angle3; }
            private set { angle3 = value; }
        }

        public double Area
        {
            get {
                    double maxAngle = Math.Max(Angle3, Math.Max(Angle2, Angle1));
                    double[] sidesSorted = new double[] { Side1, Side2, Side3 };
                    Array.Sort(sidesSorted);

                    return 0.5 * sidesSorted[0] * sidesSorted[1] * Math.Sin(maxAngle * Math.PI / 180);
                }
        }
        public double Perimeter
        {
            get { return Side1 + Side2 + Side3; }
        }

        public TriangleType Type
        {
            get
            {
                if (Side1 == Side2 && Side2 == Side3) return TriangleType.equilaterial;
                if (Angle1 == Angle2 && Angle3 == Angle2) return TriangleType.isosceles;
                if (Angle1 == 90 || Angle2 == 90 || Angle3 == 90) return TriangleType.right;
                return TriangleType.regular;
            }
        }

        public double Height1
        {
            get { return 2 * Area / Side1; }
        }
        public double Height2
        {
            get { return 2 * Area / Side2; }
        }
        public double Height3
        {
            get { return 2 * Area / Side3; }
        }
        
        /* Constructor */
        public Triangle(double side1, double side2, double side3, double angle1, double angle2, double angle3)
        {
            /* Exception handling */
            CheckAngles(angle1, angle2, angle3);
            CheckSides(side1, side2, side3);

            /* Assigning values */
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;

            Angle1 = angle1;
            Angle2 = angle2;
            Angle3 = angle3;

        }

        /* ******************************************************************  */
        /* ****************          Public methods         *****************  */

        public void ChangeAngles(double angle1, double angle2, double angle3){
            CheckAngles(angle1, angle2, angle3);
            Angle1 = angle1;
            Angle2 = Angle2;
            Angle3 = Angle3;
        }

        public void ChangeSides(double side1, double side2, double side3)
        {
            CheckSides(side1, side2, side3);
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }

      
        public override string ToString()
        {
            String angles = Angle1 + " , " + Angle2 + " , " + Angle3;
            String sides = Side1 + " , " + Side2 + " , " + Side3;
            return "Angles: " + angles + " Sides: " + sides;
        }

        public void ShowInfo()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Height 1: " + Height1);
            Console.WriteLine("Height 2: " + Height2);
            Console.WriteLine("Height 3: " + Height3);
            Console.WriteLine("Area: " + Area);
            Console.WriteLine("Perimeter: " + Perimeter);
        }

       
        /* ******************************************************************  */
        /* ****************     Private helper methods      *****************  */

        //===== ==== Exception hangling 
        private void CheckAngles(double angle1, double angle2, double angle3)
        {
            if (angle1 + angle2 + angle3 != 180) throw new System.ArgumentException("Sum of angles must be 180 degrees");
        }
        private void CheckSides(double side1, double side2, double side3)
        {
            double[] sides = new double[] { side1, side2, side3 };
            Array.Sort(sides);
            if (sides[0] + sides[1] < sides[2]) throw new System.ArgumentException("Sum of 2 sides is less than length of third");

        }
        

    }
}

