using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab4_Events
{
    public class EffectRunner
    {
        private FormQuestion Form { get; set; }
        private Color DefaultColor { get; set; }
        private Timer Timer { get; set; }

        private int INTERVAL = 70;

        public EffectRunner(FormQuestion form)
        {
            Form = form;
            DefaultColor = form.BackColor;
            Timer = new Timer();
            Timer.Interval = INTERVAL;
            Timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            Form.BackColor = DefaultColor;
            Timer.Stop();
        }

        public void RunGreenEffect()
        {
            RunColorEffect(Color.Green);
        }

        public void RunRedEffect()
        {
            RunColorEffect(Color.Red);
        }

        private void RunColorEffect(Color color)
        {
            Form.BackColor = color;
            Timer.Start();
        }

        

    }
}

