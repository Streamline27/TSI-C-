using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events.Game
{
    interface IQuizGame
    {
        void Start();
        void End();
        void NextQuestion();
        void SubmitAnswer();

        event AnswerHandler Answered;
        event AnswerHandler AnsweredCorrectly;
        event AnswerHandler AnsweredWrong;

    }
}
