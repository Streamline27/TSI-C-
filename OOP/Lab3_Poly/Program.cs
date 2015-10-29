using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Poly
{
    // Interface for any sort of question
    public interface Question
    {
        Boolean IsAnswered { get; set; }
        void Ask();
        void RequestAnswer();
        void GetFeedback();
    }

    // Class for math problems with two arguments
    public abstract class MathProblem : Question
    {
        protected double A { get; set; }
        protected double B { get; set; }

        protected const String FB_POSITIVE = "Answer is right!";
        protected const String FB_NEGATIVE = "Answer is wrong!";

        public Boolean IsAnswered { get; set; }

        /* abstract methods for getting problem features */
        protected abstract String GetOperation();
        protected abstract double ComputeResult(double a, double b);

        /*  abstract methods for communication with outer world */
        protected abstract void ShowQuestion(String question);
        protected abstract void ShowFeedback(String feedback);
        protected abstract double GetUserAnswer();


        // Constructor
        public MathProblem(double a, double b)
        {
            A = a;
            B = b;
        }

        /*   Question interface methods
        *******************************/
        public virtual void Ask()
        {
            String question = GetQuestionText();
            ShowQuestion(question); // Requests abstract implementation
        }

        public virtual void RequestAnswer()
        {
            double AnticipatedAnswer = GetUserAnswer(); // Requests abstract implementation
            double ActualAnswer = ComputeResult(A, B);  // Requests abstract implementation

            // Computes if user answer is actually right
            if (AnticipatedAnswer == ActualAnswer) IsAnswered = true;
            else IsAnswered = false;
        }

        public virtual void GetFeedback()
        {
            string feedback;

            if (IsAnswered) feedback = FB_POSITIVE;
            else feedback = FB_NEGATIVE;

            ShowFeedback(feedback); // Requests abstract implementation
        }

        /******************************************/
        // Method for forming question text string
        protected virtual String GetQuestionText()
        {
            String operation = GetOperation();
            return A + operation + B + " =?";
        }
    }


    /* ***************************************************** */
    /* Derived abstract class for communication with console */

    public abstract class ConsoleMathProblem : MathProblem
    {

        protected override void ShowQuestion(string question)
        {
            Console.WriteLine(question);
        }

        protected override void ShowFeedback(string feedback)
        {
            Console.WriteLine(feedback);
        }

        protected override Double GetUserAnswer()
        {
            Console.Write("Enter answer: ");
            return Convert.ToDouble(Console.ReadLine());
        }

        public ConsoleMathProblem(double a, double b) : base(a, b) { }
    }

    /* **************************************** */
    /* ******  Classes for statements  ******** */


    // First statements (+)
    public class Summation : ConsoleMathProblem 
    {
        protected override String GetOperation()
        {
            return " + ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a + b;
        }

        public Summation(double a, double b) : base(a, b) { }
    }


    // Second statement (-)
    public class Substraction : ConsoleMathProblem
    {
        protected override String GetOperation()
        {
            return " - ";
        }

        protected override double ComputeResult(double a, double b)
        {
            return a - b;
        }

        public Substraction(int a, int b) : base(a, b) { }
    }


    class Program
    {
        static void Main(String[] args)
        {
            // Generating list of problems
            Random rand = new Random();
            List<Question> questions = new List<Question>();

            for (int i = 0; i < 10; i++)
            {
                // Getting random arguments of math problem
                int a = rand.Next(11);
                int b = rand.Next(11);

                // Adding a problem to a problem list
                if (rand.Next(2) == 1) questions.Add(new Summation(a, b));
                else questions.Add(new Substraction(a, b));
            }

            // Letting user to solve every problem in a list
            int k = 1;
            foreach (var question in questions)
            {
                Console.WriteLine();
                Console.WriteLine("Question #" + k++);
                question.Ask();
                question.RequestAnswer();
                question.GetFeedback();
            }

            Console.ReadLine();
        }
    }
}
