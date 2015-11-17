using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{

    public interface Question
    {
        Boolean IsAnswered { get; set; }
        void Ask();
        void RequestAnswer();
        void GetFeedback();
    }

    public delegate void AnswerDelegate(); // способ вызвать!

    public abstract class MathProblem : Question
    {
        protected double A { get; set; }
        protected double B { get; set; }

        public event AnswerDelegate OnAnswered;

        private ProblemWritter problemWritter; // member for communication with outer world

        protected const String FB_POSITIVE = "Answer is right!";
        protected const String FB_NEGATIVE = "Answer is wrong!";

        public Boolean IsAnswered { get; set; }

        /* abstract methods for getting problem features */
        protected abstract String GetOperation();
        protected abstract double ComputeResult(double a, double b);

        public MathProblem(double a, double b, ProblemWritter problemWritter)
        {
            A = a;
            B = b;
            this.problemWritter = problemWritter;
        }

        public virtual void Ask()
        {
            String question = GetQuestionText();
            problemWritter.ShowQuestion(question); // Requests abstract implementation
        }

        public virtual void RequestAnswer()
        {
            double AnticipatedAnswer = problemWritter.RecievetUserAnswer(); // Requests abstract implementation
            double ActualAnswer = ComputeResult(A, B);  // Requests abstract implementation

            if (AnticipatedAnswer == ActualAnswer) IsAnswered = true;
            else IsAnswered = false;
            OnAnswered();
        }

        public virtual void GetFeedback()
        {
            string feedback;

            if (IsAnswered) feedback = FB_POSITIVE;
            else feedback = FB_NEGATIVE;

            problemWritter.ShowFeedback(feedback); // Requests abstract implementation
        }

        // Method for forming question text string
        protected virtual String GetQuestionText()
        {
            String operation = GetOperation();
            return A + operation + B + " =?";
        }
    }
   

    /* **************************************** */
    /* ******  Classes for statements  ******** */

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

        public Summation(int a, int b, ProblemWritter problemWritter) : base(a, b, problemWritter) { }
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

        public Substraction(int a, int b, ProblemWritter problemWritter) : base(a, b, problemWritter) { }
    }

    // Second statement (NIKITA)
    public class Pushka : MathProblem
    {
        protected override String GetOperation()
        {
            return " NIKITA ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a * b + a * b;
        }

        public Pushka(int a, int b, ProblemWritter problemWritter) : base(a, b, problemWritter) { }
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

        public Multiplication(int a, int b, ProblemWritter problemWritter) : base(a, b, problemWritter) { }
    }
}
