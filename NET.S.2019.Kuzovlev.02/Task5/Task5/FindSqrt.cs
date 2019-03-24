using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    /// <summary>
    /// Class with FindNthRoot method.
    /// </summary>
    public static class FindSqrt
    {
        /// <summary>
        /// Returns n-th root of number with a specified accuracy with Newton's method.
        /// </summary>
        /// <param name="a"> Number. </param>
        /// <param name="n"> Degree. </param>
        /// <param name="eps"> Accuracy. </param>
        /// <returns> Root of number. </returns>
        public static double FindNthRoot(double a, double n, double eps)
        {
            if (eps <= 0)
                throw new ArgumentException("Epsilon should be greater than 0.");
            if (n <= 0)
                throw new ArgumentException("N should be greater than 0.");
            if (a < 0 && n % 2 == 0)
                throw new ArgumentException("For negative number n should be odd.");

            double x0 = a / n;
            double x1 = (1 / n) * ((n - 1) * x0 + a / Math.Pow(x0, n - 1));

            while (Math.Abs(x1 - x0) >= eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + a / Math.Pow(x0, n - 1));
            }

            return x1;
        }
    }
}
