using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /// <summary>
    /// Class with methods for convrting.
    /// </summary>
    public static class BinaryView
    {
        /// <summary>
        /// Converts double number into string binary view.
        /// </summary>
        /// <param name="number"> The double number. </param>
        /// <returns> The binary view of the number. </returns>
        public static string DoubleBinaryView(this double number)
        {
            string sign = number < 0 ? "1" : "0";
            switch (number)
            {
                case double.Epsilon:
                    return "0000000000000000000000000000000000000000000000000000000000000001";
                case double.NaN:
                    return "1111111111111000000000000000000000000000000000000000000000000000";
                case double.PositiveInfinity:
                    return "0111111111110000000000000000000000000000000000000000000000000000";
                case double.NegativeInfinity:
                    return "1111111111110000000000000000000000000000000000000000000000000000";
                case 0:
                    return $"{sign}000000000000000000000000000000000000000000000000000000000000000";
            }

            number = Math.Abs(number);

            double fractionalPart = number % 1;
            string binaryIntPart = ConvertIntPart(number, out int exponentLength);

            string mantisa = binaryIntPart + ConvertDoublePart(fractionalPart);
            while (mantisa.Length < 53)
            {
                mantisa += "0";
            }
            mantisa = mantisa.Substring(1, 52);

            string exponent = ConvertIntPart(exponentLength - 1 + 1023, out exponentLength);

            return sign + exponent + mantisa;
        }

        /// <summary>
        /// Converts an integer part of the double number to binary view.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="exponentLength"></param>
        /// <returns>The binary view of the integer part of the number.</returns>
        private static string ConvertIntPart(double number, out int exponentLength)
        {
            string result = "";

            while (number >= 1)
            {
                result = ((int)(number % 2)).ToString() + result;
                number = Math.Floor(number / 2);
            }

            exponentLength = result.Length;

            if (result.Length > 53)
            {
                result = result.Substring(0, 53);
            }

            return result;
        }

        /// <summary>
        /// Converts a fractional part of the double number to binary view.
        /// </summary>
        /// <param name="number">The fractional part of the number.</param>
        /// <returns> The binary view of the fractional part of the number. </returns>
        private static string ConvertDoublePart(double number)
        {
            string result = "";

            while (number != 0)
            {
                result = result + ((int)(number * 2)).ToString();
                number = (number * 2) % 1;
            }

            return result;
        }
    }
}
