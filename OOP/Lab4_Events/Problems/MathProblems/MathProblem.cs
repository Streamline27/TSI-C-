using Lab4_Events.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{
    public abstract class MathProblem : IQuestion
    {
        protected double A { get; set; }
        protected double B { get; set; }

        private ProblemWritter ProblemWritter { get; set; }// member for communication with outer world
        private Random Rand { get; set; }

        public Boolean IsAnsweredCorrectly { get; set; }

        /* abstract methods for getting problem features */
        protected abstract String GetOperation();
        protected abstract double ComputeResult(double a, double b);

        protected const int MAX_ARGUMENT = 11;

            
        public MathProblem(ProblemWritter problemWritter)
        {
            this.ProblemWritter = problemWritter;
            Rand = new Random();
        }

        public String Result
        {
            get{ return ComputeResult(A, B).ToString();  }
        }

        public virtual void AskNewQuestion()
        {
            A = Rand.Next(MAX_ARGUMENT);
            B = Rand.Next(MAX_ARGUMENT);
            String question = GetQuestionText(A, B, GetOperation());
            ProblemWritter.ShowQuestion(question); // Requests abstract implementation
        }

        public virtual void SubmitAnswer()
        {
            double AnticipatedAnswer = ProblemWritter.RecievetUserAnswer(); // Requests abstract implementation
            double ActualAnswer = ComputeResult(A, B);  // Requests abstract implementation

            CompareAnswers(AnticipatedAnswer, ActualAnswer);
        }


        // Method for forming question text string
        protected virtual String GetQuestionText(double A, double B, String operation)
        {
            return A + operation + B + " =?";
        }

        // Private helper methods
        private void CompareAnswers(double AnticipatedAnswer, double ActualAnswer)
        {
            if (AnticipatedAnswer == ActualAnswer) IsAnsweredCorrectly = true;
            else IsAnsweredCorrectly = false;
        }

    }
    
}
