using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Triangle
{
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
     
        /* Public interface methods */
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

        public double GetArea()
        {
            double maxAngle = Math.Max(Angle3, Math.Max(Angle2, Angle1));
            double[] sidesSorted = new double[]{Side1, Side2, Side3};
            Array.Sort(sidesSorted);

            return 0.5 *sidesSorted[0] * sidesSorted[1] * Math.Sin(maxAngle * Math.PI / 180 );
        }

        public double GetPerimeter()
        {
            return side1+side2+side3;
        }

        public double GetHeight1()
        {
            return 2 * GetArea() / side1;
        }
        public double GetHeight2()
        {
            return 2 * GetArea() / side2;
        }
        public double GetHeight3()
        {
            return 2 * GetArea() / side3;
        }


        /* ********************** */
        /* Private helper methods */

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

