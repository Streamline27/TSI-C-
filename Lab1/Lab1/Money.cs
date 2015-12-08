using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Money
    {
        private long euro;
        private int fraction;

        public long Euro
        {
            public get
            {
                return euro;
            }
            set
            {
                euro = value;
            }
        }

        public int Fraction
        {
            get
            {
                return fraction;
            }
            set
            {
                // Manipuljacija chtob hranit'tolko 2 pervie cifti (Vzal iz ineta)
                // Esli bolshe 3eh cifr berjem 2 pervie
                //  Esli 1 cifra umnoz na 10
                // Inache figarj kak est'
                if (value >= 100) fraction = Convert.ToInt32(value.ToString().Substring(0, 2));
                else if (value < 10) fraction = value * 10;
                else fraction = value;
            }
        }

        public Money(long euro, int fraction){
            Euro = euro;
            Fraction = fraction;
        }

        public void WriteLine()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return Euro + "." + Fraction;
        }
    }
}
