using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class with FindNextBiggerNumber method.
    /// </summary>
    public static class Finder
    {
        /// <summary>
        /// Elepsed time of method in mses.
        /// </summary>
        public static long ElapsedMs { set; get; }

        /// <summary>
        /// Returns the nearest largest integer consisting of the digits of the number, 
        /// and -1 if no such number exists.
        /// </summary>
        /// <param name="number"> Original number. </param>
        /// <returns> The nearest largest integer or -1. </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();

            int result = DoFindNextBiggerNumber(number);

            watch.Stop();
            ElapsedMs = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Returns the nearest largest integer consisting of the digits of the number, 
        /// and -1 if no such number exists.
        /// </summary>
        /// <param name="number"> Original number. </param>
        /// <returns> The nearest largest integer or -1. </returns>
        private static int DoFindNextBiggerNumber(int number)
        {
            Char[] charNumber = number.ToString().ToCharArray();

            if (charNumber.Length == 1)
            {
                return -1;
            }

            char temp;

            for (int i = charNumber.Length - 2; i >= 0; i--)
            {
                if (charNumber[i] < charNumber[i + 1])
                {
                    temp = charNumber[i];
                    charNumber[i] = charNumber[i + 1];
                    charNumber[i + 1] = temp;
                    Array.Sort(charNumber, i + 1, charNumber.Length - 1 - i);
                    try
                    {
                        return Convert.ToInt32(new String(charNumber));
                    }
                    catch (OverflowException)
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }
    }
}
