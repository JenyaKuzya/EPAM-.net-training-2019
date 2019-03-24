using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Class with InsertNumber Method.
    /// </summary>
    public static class Inserter
    {
        /// <summary>
        /// Inserts number2 in number1 from i to j bites.
        /// </summary>
        /// <param name="number1"> First number. </param>
        /// <param name="number2"> Second number. </param>
        /// <param name="i"> Start bit. </param>
        /// <param name="j"> End bit. </param>
        /// <returns> New number. </returns>
        public static int InsertNumber(int number1, int number2, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentException("Index j should be greater than i.");
            }
            if (i > 31 || j > 31 || i < 0 || j < 0)
            {
                throw new ArgumentException("Indexes i and j should be less than 32 and not negative.");
            }
            string bitNumber1 = Convert.ToString(number1, 2);
            string bitNumber2 = Convert.ToString(number2, 2);
            while (bitNumber1.Length < 32)
            {
                bitNumber1 = '0' + bitNumber1;
            }
            while (bitNumber2.Length < 32)
            {
                bitNumber2 = '0' + bitNumber2;
            }
            int count = j - i + 1; // Count of inserted bits.
            int startIndex = bitNumber1.Length - 1 - j;
            string numberPart = bitNumber2.Substring(bitNumber2.Length - count);
            bitNumber1 = bitNumber1.Remove(startIndex, count);
            bitNumber1 = bitNumber1.Insert(startIndex, numberPart);
            return Convert.ToInt32(bitNumber1, 2);
        }
    }
}
