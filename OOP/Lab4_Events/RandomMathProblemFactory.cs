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
        private List<Type> problemList; // List of types that can be randomly selected;

        public RandomMathProblemFactory(ProblemWritter problemWritter)
        {
            this.problemWritter = problemWritter;
            InitializeVariables();
            AddDefaultProblemTypesToDraft();
            AddCustomProblemsTypesToDraft();
        }

        public MathProblem CreateQuestion()
        {
            int firstArg = rand.Next(MAX_NUMBER);
            int secondArg = rand.Next(MAX_NUMBER);

            int index = rand.Next(problemList.Count);

            Type type = problemList[index];
            return (MathProblem) Activator.CreateInstance(type, firstArg, secondArg, problemWritter);
        }

        protected virtual void AddCustomProblemsTypesToDraft() { }

        /* Helper functions */
        private void InitializeVariables()
        {
            this.problemList = new List<Type>();
            this.rand = new Random();
        }

        protected void AddProblemType(Type type) {
            problemList.Add(type);
        }

        private void AddDefaultProblemTypesToDraft()
        {
            AddProblemType(typeof(Summation));
            AddProblemType(typeof(Substraction));
            AddProblemType(typeof(Pushka));
            AddProblemType(typeof(Multiplication));
        }


    }
}
