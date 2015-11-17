using System;
namespace DelegateList
{
    public delegate void TMyDelegate(ref int x); // способ вызвать!
    class TMyMath
    {
        public static void inc(ref int i) {
            Console.WriteLine("Incremented by 4");
            i += 4; 
        }
        public void dec(ref int i) {
            Console.WriteLine("Decremented by 3");
            i -= 3; 
        }
        public void div(ref int i) {
            Console.WriteLine("Halved");
            i /= 2; 
        }
        public void pow(ref int i) {
            Console.WriteLine("Squared");
            i *= i; 
        }
    }
    class Program
    {
        public static void Main()
        {
            // TMyMath Calculat = new TMyMath(); 
            TMyMath Calculat; Calculat = new TMyMath();
            TMyDelegate Incrementation = new TMyDelegate(TMyMath.inc);
            TMyDelegate Decrementation = new TMyDelegate(Calculat.dec);
            TMyDelegate Division = new TMyDelegate(Calculat.div);
            TMyDelegate Power = new TMyDelegate(Calculat.pow);
            TMyDelegate DelegateSequence = Power;
            DelegateSequence += Division; DelegateSequence += Decrementation;
            DelegateSequence += Incrementation; DelegateSequence += Decrementation;
            DelegateSequence += Division; DelegateSequence += Power;
            DelegateSequence -= Division; DelegateSequence -= Decrementation;
            int i = 4;
            DelegateSequence(ref i);
            Console.WriteLine("i=" + i);
            Console.ReadKey();
        }
    }
}