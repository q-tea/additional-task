using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp6
{
    class Program
    {
        public static int NumerOfThread = 0;
        public static bool IsSqr(int number1)
        {
            return ((number1) == Math.Pow(Convert.ToInt32(Math.Sqrt(number1)), 2));
        }

        private static void CheckTheNumberRange()
        {
            int StartNumber = NumerOfThread * 1000000;
            Interlocked.Increment(ref NumerOfThread);
            for (int i = StartNumber; i < StartNumber + 1000000; ++i)
            {
                if (IsSqr(i))
                    Console.WriteLine("Число {0} является квадратом другого натурального числа", i);
            }
        }

        static void Main(string[] args)
        {
            Thread[] threads = new Thread[30];
            for (int i = 0; i < 30; ++i)
            {
                threads[i] = new Thread(CheckTheNumberRange);
                threads[i].Start();
            }
        }
    }
}
