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

        public event AnswerHandler Answered;
        public event AnswerHandler AnsweredCorrectly;
        public event AnswerHandler AnsweredWrong;
        public event AnswerHandler QuestionAsked;
        public event GameConditionHandler GameEnded;
        public event GameConditionHandler GameStarted;

    }
}
