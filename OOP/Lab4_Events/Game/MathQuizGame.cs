using Lab4_Events.Game.Problems.MathProblems;
using Lab4_Events.Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Events.Game
{
    public delegate void TimeHandler();
    public delegate void ValueChangeHandler();

    // This is a quiz game for math problems with timer and score
    // QuizGame is fully independent from Form and communicate outer world via ProblemWritter and Events
    class MathQuizGame : QuizGame
    {
        private int DEF_SCORE_DELTA = 6;
        private int DEF_TIME_DELTA = 2;
        private int DEF_TIME_FOR_ROUND = 20;

        private int score;
        private int remainingTime;

        private Timer Timer { get; set; }

        public int ScoreChangeWhenAnswered { get; set; }
        public int TimeChangeWhenAnswered { get; set; }
        public int TimeForRound { get; set; }

        public event TimeHandler Tick;
        public event ValueChangeHandler ScoreChanged;
        public event ValueChangeHandler RemainingTimeChanged;

        /* Properties */
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                if (score < 0) score = 0;
                OnScoreChanged();
            }
        }

        public int RemainingTime
        {
            get
            {
                return remainingTime;
            }
            private set
            {
                remainingTime = value;
                if (remainingTime < 0) remainingTime = 0;
                OnRemainingTimeChanged();
                if (RemainingTime == 0) this.End();
            }
        }

        /* Public interface methods */
        public MathQuizGame(ProblemWritter pw)
            : base(pw)
        {
            SetDefaultParameterValues();
            InitializeTimer();
            // Assigning behavior through events;
            this.AnsweredCorrectly += IncreaseScore;
            this.AnsweredCorrectly += AddTime;
            this.AnsweredWrong += DecreaseScore;
        }


        public override void Start()
        {
            Score = 0;
            RemainingTime = TimeForRound;
            Timer.Enabled = true;
            base.Start();
        }

        public override void End()
        {
            Timer.Enabled = false;
            base.End();
        }

        public virtual void IncreaseScore()
        {
            Score += ScoreChangeWhenAnswered;
        }

        public virtual void IncreaseScore(int value)
        {
            Score += value;
        }

        public virtual void DecreaseScore()
        {
            Score -= ScoreChangeWhenAnswered;
        }

        public virtual void DecreaseScore(int value)
        {
            Score -= value;
        }

        public virtual void AddTime()
        {
            RemainingTime += TimeChangeWhenAnswered;
        }

        public virtual void AddTime(int value)
        {
            RemainingTime += value;
        }


        /* Abstract method implementation */
        protected override List<IQuestion> GetQuestionKindList(ProblemWritter pw)
        {
            return MathProblemFactory.getListOfAllKinds(pw);
        }


        /* Overriding virtual method to change behavior of base class */
        protected override string GetFeedback(bool isAnsweredCorrectly, string rightAnswer)
        {
            if (isAnsweredCorrectly) return "Nice, you got that right!";
            else return "Worng! Right answer is " + rightAnswer;
        }


        /* Event handlers */
        private void OnTick()
        {
            if (Tick != null) Tick();
        }

        private void OnScoreChanged()
        {
            if (ScoreChanged != null) ScoreChanged();
        }

        private void OnRemainingTimeChanged()
        {
            if (RemainingTimeChanged != null) RemainingTimeChanged();
        }

        /* Private helper methods */
        private void SetDefaultParameterValues()
        {
            ScoreChangeWhenAnswered = DEF_SCORE_DELTA;
            TimeChangeWhenAnswered = DEF_TIME_DELTA;
            TimeForRound = DEF_TIME_FOR_ROUND;
            Score = 0;
        }

        private void InitializeTimer()
        {
            Timer = new Timer();
            Timer.Interval = 1000;
            Timer.Tick += (sender, e) =>
            {
                RemainingTime--;
                OnTick();
            };
        }
        
    }
}
