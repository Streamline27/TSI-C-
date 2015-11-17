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

        /******************************/
        public FormQuestion()
        {
            InitializeComponent();

            problemWritter = new FormProblemWritter(this);
            problemFactory = new RandomMathProblemFactory(problemWritter);
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
            String answerText = textBoxAnswer.Text;
            double answer = Convert.ToDouble(answerText);
            return answer;
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
            Question.Ask();
            MathProblem mp = (MathProblem)Question;
            mp.OnAnswered += new AnswerDelegate(RunColorChange);

                
        }

        private void FormQuestion_Shown(object sender, EventArgs e)
        {
            buttonQuestion_Click(sender, e);
        }

        private void textBoxAnswer_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private Color c;
        // Visual effects
        private void RunColorChange()
        {
            c = this.BackColor;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tick++;
            BackColor = Color.FromArgb(tick, 0, tick);
            if (tick == 230)
            {
                timer1.Enabled = false;
                tick = 0;
                timer1.Enabled = false;
                this.BackColor = c;
            }
        }

    }
}
