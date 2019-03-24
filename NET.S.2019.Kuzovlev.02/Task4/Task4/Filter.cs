using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Class with FilterDigit method.
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// Filters the list of integer numbers and returns a list of numbers which contain a specified digit. 
        /// </summary>
        /// <param name="list"> The list of integer numbers. </param>
        /// <param name="digit"> A specified digit. </param>
        /// <returns> Filtered list. </returns>
        public static List<int> FilterDigit(List<int> list, int digit)
        {
            if (list == null)
            {
                throw new ArgumentNullException();
            }
            if (digit > 9 || digit < 0)
            {
                throw new ArgumentException("Digit should be in the range of 0..9");
            }
            List<int> result = new List<int>();
            foreach (int number in list)
            {
                if (number.ToString().Contains(digit.ToString()))
                {
                    result.Add(number);
                }
            }
            return result;
        }
    }
}
