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
            SetFeedbackLabel("");
        }

        private void FormQuestion_Shown(object sender, EventArgs e)
        {
            buttonQuestion_Click(sender, e);
        }

        private void textBoxAnswer_MouseClick(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Red;
        }

    }
}
