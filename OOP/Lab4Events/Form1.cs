using Lab4_Events.Game;
using Lab4_Events.Problems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_Events
{
    public partial class FormQuestion : Form
    {

        private int tick{get; set;}
        private MathQuizGame Game{ get; set;}
        private ProblemWritter problemWritter {get; set;}
        private EffectRunner effectRunner { get; set; } 

        private string BAD_RESULT_FEEDBACK = "You can do better! Keep trying!";
        private string SEMI_RESULT_FEEDBACK = "Quite Nice! I got a hang of it!";
        private string GOOD_RESULT_FEEDBACK = "Outstanding! You are marvelous!";
        private string STARTING_MOTO_FEEDBACK = "Game has started! Good luck!";

        private int BAD_RESULT_TRESHOLD = 60;
        private int SEMI_RESULT_TRESHOLD = 120;
        private int GOOD_RESULT_TRESHOLD = 200;

        /******************************/
        public FormQuestion()
        {
            InitializeComponent();

            effectRunner = new EffectRunner(this);
            problemWritter = new FormProblemWritter(this);
            Game = new MathQuizGame(problemWritter);
            AddEventsToGame(); // <--- All Stuff connected with event subscription here 
        }


        /* Methods for communication  */

        public void SetQuestionLabel(String text)
        {
            labelQuestion.Text = text;
        }

        public void SetFeedbackLabel(String text)
        {
            labelFeedback.Text = text;
        }

        public double GetAnswer()
        {
            Double answer;
            String answerText = textBoxAnswer.Text;
            if (Double.TryParse(answerText, out answer)) return answer;
            else return 0;
        }

        public void SetScoreLabel(String text)
        {
            labelScore.Text = text;
        }

        public void SetScoreLabelValue(string value)
        {
            labelScore.Text = value.ToString();
        }

        public void SetTimeLabel(string value)
        {
            labelTime.Text = value.ToString();
        }


        /* Form Events */
        
        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            Game.SubmitAnswer();
            Game.NextQuestion();
            textBoxAnswer.Text = "";
        }

        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            Game.NextQuestion();
            textBoxAnswer.Text = "";
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Game.Start();
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            ActiveControl = buttonNew;
        }
        
        /* Game event subscribers */
        private void AddEventsToGame()
        {
            Game.ScoreChanged += RefreshScoreLabel; // Binding Score property to form controll through event
            Game.Tick += RefreshTimeLabel; // One subscriber to two different events
            Game.AnsweredCorrectly += RefreshTimeLabel; // One subscriber to two different events

            // Example of running outer object methods as a subscriber
            Game.AnsweredCorrectly += effectRunner.RunGreenEffect;
            Game.AnsweredWrong += effectRunner.RunRedEffect;

            // Many subscribers to one event
            Game.GameEnded += DisableGameButtons;
            Game.GameEnded += EnableNewButton;
            Game.GameEnded += SetGameOverStatus;
            Game.GameEnded += GetOverallFeedback;

            Game.GameStarted += RefreshTimeLabel;
            Game.GameStarted += EnableGameButtons;
            Game.GameStarted += DisableNewButton;
            Game.GameStarted += SetMotoFeedback;
        }

        private void SetGameOverStatus()
        {
            SetQuestionLabel("Game Over");
        }
        
        private void RefreshScoreLabel()
        {
            SetScoreLabel(Game.Score.ToString());
        }
        
        private void RefreshTimeLabel()
        {
            SetTimeLabel(Game.RemainingTime.ToString());
        }

        private void EnableNewButton()
        {
            buttonNew.Enabled = true;
        }

        private void DisableNewButton()
        {
            buttonNew.Enabled = false;
        }

        private void EnableGameButtons()
        {
            buttonAnswer.Enabled = true;
            buttonQuestion.Enabled = true;
        }

        private void DisableGameButtons()
        {
            buttonAnswer.Enabled = false;
            buttonQuestion.Enabled = false;
        }

        private void SetMotoFeedback()
        {
            SetFeedbackLabel(STARTING_MOTO_FEEDBACK);
        }

        private void GetOverallFeedback()
        {
            if (Game.Score < BAD_RESULT_TRESHOLD) SetFeedbackLabel(BAD_RESULT_FEEDBACK);
            else if (Game.Score < SEMI_RESULT_TRESHOLD) SetFeedbackLabel(SEMI_RESULT_FEEDBACK);
            else if (Game.Score < GOOD_RESULT_TRESHOLD) SetFeedbackLabel(GOOD_RESULT_FEEDBACK);
        }
    }
}
