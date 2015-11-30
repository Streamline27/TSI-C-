using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{

    public delegate void AnswerHandler(); // способ вызвать!

    public interface Question
    {
        Boolean IsAnsweredCorrectly { get; set; }
        void Ask();
        void RequestAnswer();
        void GetFeedback();

        event AnswerHandler Answered;
        event AnswerHandler AnsweredCorrectly;
        event AnswerHandler AnsweredWrong;

    }

    public abstract class MathProblem : Question
    {
        protected double A { get; set; }
        protected double B { get; set; }

        private ProblemWritter problemWritter; // member for communication with outer world

        protected const String FB_POSITIVE = "Answer is right!";
        protected const String FB_NEGATIVE = "Answer is wrong!";

        public Boolean IsAnsweredCorrectly { get; set; }

        public event AnswerHandler Answered;
        public event AnswerHandler AnsweredCorrectly;
        public event AnswerHandler AnsweredWrong;

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
            String question = GetQuestionText(A, B, GetOperation());
            problemWritter.ShowQuestion(question); // Requests abstract implementation
        }

        public virtual void RequestAnswer()
        {
            double AnticipatedAnswer = problemWritter.RecievetUserAnswer(); // Requests abstract implementation
            double ActualAnswer = ComputeResult(A, B);  // Requests abstract implementation

            CompareAnswers(AnticipatedAnswer, ActualAnswer);
            OnAnswered();
            OnAnsweredCorrectly();
            OnAnsweredWrong();
        }

        
        public virtual void GetFeedback()
        {
            string feedback;

            if (IsAnsweredCorrectly) feedback = FB_POSITIVE;
            else feedback = FB_NEGATIVE;

            problemWritter.ShowFeedback(feedback); // Requests abstract implementation
        }

        // Method for forming question text string
        protected virtual String GetQuestionText(double A, double B, String operation)
        {
            return A + operation + B + " =?";
        }

        // Private helper methods
        private void OnAnswered()
        {
            if (Answered!=null) Answered();
        }

        private void OnAnsweredCorrectly()
        {
            if (IsAnsweredCorrectly && AnsweredCorrectly!=null) AnsweredCorrectly();
        }

        private void OnAnsweredWrong()
        {
            if (!IsAnsweredCorrectly && AnsweredWrong!=null) AnsweredWrong();
        }

        private void CompareAnswers(double AnticipatedAnswer, double ActualAnswer)
        {
            if (AnticipatedAnswer == ActualAnswer) IsAnsweredCorrectly = true;
            else IsAnsweredCorrectly = false;
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
