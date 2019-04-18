using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public static class Fibonacci
    {
        public static List<int> MakeSequence(int count)
        {
            List<int> fibonacciNumbers = new List<int>();
            if (count > 0)
            {
                fibonacciNumbers.Add(1);
            }
            if (count > 1)
            {
                fibonacciNumbers.Add(1);
            }
            for (int i = 2; i < count; i++)
            {
                int previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                int previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(previous + previous2);
            }
            return fibonacciNumbers;
        }
    }
}
