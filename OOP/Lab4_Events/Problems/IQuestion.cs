using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events.Problems
{

    
    public interface IQuestion
    {
        Boolean IsAnsweredCorrectly { get; }
        String Result { get; }
        void AskNewQuestion();
        void SubmitAnswer();
    }
}
