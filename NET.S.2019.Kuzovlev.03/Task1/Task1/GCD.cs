using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Task1
{
    /// <summary>
    /// Class for finding the greatest common division of two or more numbers.
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Delegate for GCD methods.
        /// </summary>
        /// <param name="num1"> First number. </param>
        /// <param name="num2"> Second number. </param>
        /// <returns> GCD of two numbers. </returns>
        public delegate int GCDMethod(int num1, int num2);

        /// <summary>
        /// Elepsed time of method in mses.
        /// </summary>
        public static long ElapsedTime { get; set; }

        /// <summary>
        /// Returns GCD of two numbers with Euclidean algorithm.
        /// </summary>
        /// <param name="num1"> First number. </param>
        /// <param name="num2"> Second number. </param>
        /// <returns> GCD of two numbers. </returns>
        public static int EuclidGCD(int num1, int num2)
        {
            while (num2 != 0)
            {
                int t = num2;
                num2 = num1 % num2;
                num1 = t;
            }
            try
            {
                return checked(Math.Abs(num1 + num2));
            }
            catch (OverflowException)
            {
                return Int32.MaxValue;
            }
            
        }

        /// <summary>
        /// Returns GCD of the two or more numbers with the gcdMethod algorithm (Stein's or Euclidean algorithm).
        /// </summary>
        /// <param name="gcdMethod"> GCD algorithm. </param>
        /// <param name="numbers"> Array of the numbers. </param>
        /// <returns> GCD of the numbers. </returns>
        public static int MultiGCD(GCDMethod gcdMethod, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("Array shouldn't be null");
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException("Array should contain more than 1 number.");
            }

            var watch = Stopwatch.StartNew();

            int result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
                result = gcdMethod(numbers[i], result);

            watch.Stop();
            ElapsedTime = watch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Returns GCD of two numbers with Binary GCD algorithm (Stein's algorithm).
        /// </summary>
        /// <param name="num1"> First number. </param>
        /// <param name="num2"> Second number. </param>
        /// <returns> GCD of two numbers. </returns>
        public static int SteinsGCD(int num1, int num2)
        {
            try
            {
                num1 = checked(Math.Abs(num1));
            }
            catch (OverflowException)
            {
                num1 = Int32.MaxValue;
            }
            try
            {
                num2 = checked(Math.Abs(num2));
            }
            catch (OverflowException)
            {
                num2 = Int32.MaxValue;
            }
            // GCD(0, b) == b; GCD(a, 0) == a,  
            // GCD(0, 0) == 0 
            if (num1 == 0)
                return num2;
            if (num2 == 0)
                return num1;

            // Finding K, where K is the greatest  
            // power of 2 that divides both num1 and num2 
            int k;
            for (k = 0; ((num1 | num2) & 1) == 0; ++k)
            {
                num1 >>= 1;
                num2 >>= 1;
            }

            // Dividing num1 by 2 until a becomes odd 
            while ((num1 & 1) == 0)
                num1 >>= 1;

            // From here on, 'num1' is always odd 
            do
            {
                // If num2 is even, remove  
                // all factor of 2 in num2  
                while ((num2 & 1) == 0)
                    num2 >>= 1;

                /* Now num1 and num2 are both odd. Swap  
                if necessary so num1 <= num2, then set  
                num2 = num2 - num1 (which is even).*/
                if (num1 > num2)
                {
                    Swap(ref num1, ref num2);
                }

                num2 = (num2 - num1);
            } while (num2 != 0);

            // restore common factors of 2 
            return num1 << k;
        }

        /// <summary>
        /// Swaps two numbers.
        /// </summary>
        /// <param name="num1"> First number. </param>
        /// <param name="num2"> Second number. </param>
        private static void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }
}
