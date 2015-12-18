using Lab4_Events.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events.Game.Problems.MathProblems
{
    public class MathProblemFactory
    {
        public static List<IQuestion> getListOfAllKinds(ProblemWritter pw){
            var kinds = new List<IQuestion>();
            kinds.Add(new Summation(pw));
            kinds.Add(new Substraction(pw));
            kinds.Add(new DoubleMult(pw));
            kinds.Add(new Multiplication(pw));
            return kinds;
        }
    }
}
