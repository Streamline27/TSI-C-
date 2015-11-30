using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{
    /* ***************************************************************************************** */
    // Abstract class that provides functionality for outer world communication for ProblemWritter
    public abstract class ProblemWritter
    {
        /*  abstract methods for communication with outer world */
        public abstract void ShowQuestion(String question);
        public abstract void ShowFeedback(String feedback);
        public abstract double RecievetUserAnswer();
    }


    /* Derived class for communication with form */
    public class FormProblemWritter : ProblemWritter
    {
        private FormQuestion Form { get; set; }

        public FormProblemWritter(FormQuestion form)
        {
            Form = form;
        }

        public override void ShowQuestion(String question)
        {
            Form.SetQuestionLabel(question);
        }

        public override void ShowFeedback(String feedback)
        {
            Form.SetFeedbackLabel(feedback);
        }

        public override Double RecievetUserAnswer()
        {
            return Form.GetAnswer();
        }
    }

}
