using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{
    public class RandomMathProblemFactory
    {
        protected const int MAX_NUMBER = 11;
        protected ProblemWritter problemWritter;
        protected Random rand;
        private List<Type> problemList ;

        public RandomMathProblemFactory(ProblemWritter problemWritter)
        {
            //Initializing variables
            this.problemList = new List<Type>();
            this.rand = new Random();
            this.problemWritter = problemWritter;

            //Derived from MathProblem classes for draft
            AddProblemType(typeof(Summation));
            AddProblemType(typeof(Substraction));
            AddProblemType(typeof(Pushka));
            AddProblemType(typeof(Multiplication));
            AddCustomProblemsTypes();
        }

        protected virtual void AddCustomProblemsTypes() { }

        public MathProblem CreateQuestion()
        {
            int firstArg = rand.Next(MAX_NUMBER);
            int secondArg = rand.Next(MAX_NUMBER);

            int index = rand.Next(problemList.Count);
            Type type = problemList[index];
            return (MathProblem) Activator.CreateInstance(type, firstArg, secondArg, problemWritter);
        }


        /* Helper functions */
        protected void AddProblemType(Type type) {
            problemList.Add(type);
        }

    }
}
