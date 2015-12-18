using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Events
{
    /* ***************************************************************************************** */
    // Abstract class that provides functionality for outer world communication for Problems
    public interface ProblemWritter
    {
        /*  abstract methods for communication with outer world */
        void ShowQuestion(String question);
        void ShowFeedback(String feedback);
        double RecievetUserAnswer();
    }


    /* Derived class for communication with form */
    public class FormProblemWritter : ProblemWritter
    {
        protected FormQuestion Form { get; set; }

        public FormProblemWritter(FormQuestion form)
        {
            Form = form;
        }

        public void ShowQuestion(String question)
        {
            Form.SetQuestionLabel(question);
        }

        public void ShowFeedback(String feedback)
        {
            Form.SetFeedbackLabel(feedback);
        }

        public Double RecievetUserAnswer()
        {
            return Form.GetAnswer();
        }
    }

}
