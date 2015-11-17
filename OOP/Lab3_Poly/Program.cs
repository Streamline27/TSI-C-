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

        // member for communication with outer world
        private ProblemWritter problemWritter;

        protected const String FB_POSITIVE = "Answer is right!";
        protected const String FB_NEGATIVE = "Answer is wrong!";

        public Boolean IsAnswered { get; set; }

        /* abstract methods for getting problem features */
        protected abstract String GetOperation();
        protected abstract double ComputeResult(double a, double b);

        // Constructor
        public MathProblem(double a, double b, ProblemWritter problemWritter)
        {
            A = a;
            B = b;
            this.problemWritter = problemWritter;
        }

        /*   Question interface methods
        *******************************/
        public virtual void Ask()
        {
            String question = GetQuestionText();
            problemWritter.ShowQuestion(question); // Requests abstract implementation
        }

        public virtual void RequestAnswer()
        {
            double AnticipatedAnswer = problemWritter.RecieveUserAnswer(); // Requests abstract implementation
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

            problemWritter.ShowFeedback(feedback); // Requests abstract implementation
        }
        /* ***********    Done    *********** */

        // Method for forming question text string
        protected virtual String GetQuestionText()
        {
            String operation = GetOperation();
            return A + operation + B + " =?";
        }
    }

    /* ********************************************************************* */
    // Abstract class that provides functionality for outer world communication
    public abstract class ProblemWritter{
        /*  abstract methods for communication with outer world */
        public abstract void ShowQuestion(String question);
        public abstract void ShowFeedback(String feedback);
        public abstract double RecieveUserAnswer();
    }


    /* Derived class for communication with console */
    public class ConsoleProblemWritter : ProblemWritter
    {
        public override void ShowQuestion(String question)
        {
            Console.WriteLine(question);
        }

        public override void ShowFeedback(String feedback)
        {
            Console.WriteLine(feedback);
        }

        public override double RecieveUserAnswer()
        {
            Console.Write("Enter answer: ");
            return Convert.ToDouble(Console.ReadLine());
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

    // Second statement (-)
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

    class Program
    {
        static void NoMain(String[] args)
        {
            // Generating list of problems
            Random rand = new Random();
            List<Question> questions = new List<Question>();

            ProblemWritter pw = new ConsoleProblemWritter();
            for (int i = 0; i < 10; i++)
            {
                // Getting random arguments of math problem
                int a = rand.Next(11);
                int b = rand.Next(11);

                // Adding a problem to a problem list
                if (rand.Next(3) == 2) questions.Add(new Summation(a, b, pw));
                if (rand.Next(3) == 1) questions.Add(new Pushka(a, b, pw));
                else questions.Add(new Substraction(a, b, pw));
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
