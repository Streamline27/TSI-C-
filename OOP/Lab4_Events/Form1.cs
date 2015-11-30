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

        private int tick = 0;
        private Question Question{ get; set;}
        private ProblemWritter problemWritter;
        private RandomMathProblemFactory problemFactory;
        private Color defaultColor;

        private int SCORE_CHANGE_WHEN_CORRECT = 6;
        private int SCORE_CHANGE_WHEN_WRONG = -6;

        /******************************/
        public FormQuestion()
        {
            InitializeComponent();

            problemWritter = new FormProblemWritter(this);
            problemFactory = new RandomMathProblemFactory(problemWritter);
            defaultColor = this.BackColor;
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

        public void SetTimerLabel(String text)
        {
            labelScore.Text = text;
        }

        public void IncreaseScoreLabelValue(int value)
        {
            int labelValue = Convert.ToInt32(labelScore.Text);
            labelValue += value;
            labelScore.Text = labelValue.ToString();
        }

        /* Events */

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            Question.RequestAnswer();
            Question.GetFeedback();
        }


        private void buttonQuestion_Click(object sender, EventArgs e)
        {
            Question = problemFactory.CreateQuestion();
            AddEventsToQuestion();
            Question.Ask();
        }

        
        private void FormQuestion_Shown(object sender, EventArgs e)
        {
            buttonQuestion_Click(sender, e);
        }


        /* Private helper methods */
        private void AddEventsToQuestion()
        {
            MathProblem mp = (MathProblem)Question;
            mp.AnsweredCorrectly += OnAnsweredCorrectly;
            mp.AnsweredWrong += RunColorChange;
            mp.AnsweredWrong += OnAnsweredWrong;
        }


        private void OnAnsweredCorrectly()
        {
            IncreaseScoreLabelValue(SCORE_CHANGE_WHEN_CORRECT);
        }
        private void OnAnsweredWrong()
        {
            IncreaseScoreLabelValue(SCORE_CHANGE_WHEN_WRONG);
        }

        // Visual effects
        private void RunColorChange()
        {
            tick = 0;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick+=2;
            BackColor = Color.FromArgb(tick, 0, tick);
            if (tick == 230)
            {
                timer1.Enabled = false;
                tick = 0;
                this.BackColor = defaultColor;
            }
        }

    }
}
