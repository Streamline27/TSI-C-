using Lab4_Events.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events.Game
{
    public delegate void AnswerHandler(); // способ вызвать!
    public delegate void GameConditionHandler();

    // This class can be used if we don't want score or timers. Just to practise for example.
    // Plus we can supply any sort of problems that implements IQuestion
    // (Text problems for example if we implement them)
    public abstract class QuizGame : IQuizGame
    {
        private Random Rand { get; set; }
        private ProblemWritter ProblemWritter { get; set; }

        protected List<IQuestion> QuestionTypeList { get;  set; }
        protected IQuestion CurrentQuestion { get; set; }

        public bool IsStarted { get; private set; }

        public event AnswerHandler Answered;
        public event AnswerHandler AnsweredCorrectly;
        public event AnswerHandler AnsweredWrong;
        public event AnswerHandler QuestionAsked;
        public event GameConditionHandler GameEnded;
        public event GameConditionHandler GameStarted;

        protected abstract List<IQuestion> GetQuestionKindList(ProblemWritter pw);

        /* Public interface methods */
        public QuizGame(ProblemWritter problemWritter)
        {
            this.Rand = new Random();
            this.IsStarted = false;
            this.ProblemWritter = problemWritter;
            this.QuestionTypeList = GetQuestionKindList(problemWritter); // Abstract Implementation
        }


        public virtual void Start()
        {
            if (IsStarted) return;

            IsStarted = true;
            OnGameStarted();
            NextQuestion();
        }

        public virtual void End()
        {
            IsStarted = false;
            OnGameEnded();
        }

        public virtual void NextQuestion()
        {
            if (!IsStarted) return;
            OnQuestionAsked();
            CurrentQuestion = GetRandomQuestion();
            CurrentQuestion.AskNewQuestion();
        }

        public virtual void SubmitAnswer()
        {
            CurrentQuestion.SubmitAnswer();
            ShowFeedback();
            OnAnswered();
            if (CurrentQuestion.IsAnsweredCorrectly) OnAnsweredCorrectly();
            else OnAnsweredWrong();
        }


        /* Private helper methods */
        private void ShowFeedback()
        {
            String feedback = GetFeedback(CurrentQuestion.IsAnsweredCorrectly, CurrentQuestion.Result);
            ProblemWritter.ShowFeedback(feedback);
        }

        private IQuestion GetRandomQuestion()
        {
            int index = Rand.Next(QuestionTypeList.Count);
            return QuestionTypeList[index];
        }

        protected virtual String GetFeedback(bool isAnsweredCorrectly, String rightAnswer)
        {
            if (isAnsweredCorrectly) return "Answer is correct";
            else return "Answer is wrong";
        }


        /* Event Handlers */
        private void OnAnswered()
        {
            if (Answered != null) Answered();
        }

        private void OnQuestionAsked()
        {
            if (QuestionAsked != null) QuestionAsked();
        }

        private void OnAnsweredCorrectly()
        {
            bool correctly = CurrentQuestion.IsAnsweredCorrectly;
            if (correctly && AnsweredCorrectly != null) AnsweredCorrectly();
        }

        private void OnAnsweredWrong()
        {
            bool uncorrectly = !CurrentQuestion.IsAnsweredCorrectly;
            if (uncorrectly && AnsweredWrong != null) AnsweredWrong();
        }

        private void OnGameStarted()
        {
            if (GameStarted!= null) GameStarted();
        }

        private void OnGameEnded()
        {
            if (GameEnded != null) GameEnded();
        }
    }
}
