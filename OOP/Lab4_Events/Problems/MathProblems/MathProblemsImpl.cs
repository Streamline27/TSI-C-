using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events.Problems
{
        // First statements (+)
    public class Summation : MathProblem
    {
        protected override String GetOperation()
        {
            return " + ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a + b;
        }

        public Summation(ProblemWritter problemWritter) : base(problemWritter) { }
    }


    // Second statement (-)
    public class Substraction : MathProblem
    {
        protected override String GetOperation()
        {
            return " - ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a - b;
        }

        public Substraction(ProblemWritter problemWritter) : base(problemWritter) { }
    }

    // Second statement (NIKITA)
    public class DoubleMult : MathProblem
    {
        protected override String GetOperation()
        {
            return "";
        }

        protected override string GetQuestionText(double A, double B, String operation)
        {
            return A + " * " + B + " + " + A + " * " + B + " =?";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a * b + a * b;
        }

        public DoubleMult(ProblemWritter problemWritter) : base(problemWritter) { }
    }

    // Third statement (*)
    public class Multiplication : MathProblem
    {
        protected override String GetOperation()
        {
            return " * ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a * b;
        }

        public Multiplication(ProblemWritter problemWritter) : base(problemWritter) { }
    }
}
