using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Represents polinomial sequence.
    /// </summary>
    public sealed class Polynomial
    {
        /// <summary>
        /// Coefficients of the polinom.
        /// </summary>
        private double[] _coefficients;

        /// <summary>
        /// Polinom's constructor. 
        /// </summary>
        /// <param name="coefficients"> Coefficients of the polinom. </param>
        public Polynomial(double[] coefficients)
        {
            _coefficients = coefficients ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Show polinom as a string.
        /// </summary>
        /// <returns> String view of the polinom. </returns>
        public override string ToString()
        {
            string result = "";

            for(int i = 0; i < _coefficients.Length; i++)
            {
                if (_coefficients[i] != 0)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                result = _coefficients[i].ToString();
                                break;
                            }
                        case 1:
                            {
                                result = _coefficients[i] + "x" + " + " + result;
                                break;
                            }
                        default:
                            {
                                result = _coefficients[i] + "x^" + i + " + " + result;
                                break;
                            }
                    }
                }                              
            }
            return result.Trim(' ', '+');
        }

        /// <summary>
        /// Returns hash code of the polinom.
        /// </summary>
        /// <returns> Hash code of the polinom. </returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        /// <summary>
        /// Matches a polinom with other object whether they are equal.
        /// </summary>
        /// <param name="obj"> Object. </param>
        /// <returns> Bool result of matching. </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Polynomial polynom = (Polynomial)obj;

            if (this._coefficients.Length != polynom._coefficients.Length) return false;

            for (int i = 0; i < this._coefficients.Length; i++)
            {
                if (this._coefficients[i] != polynom._coefficients[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sums two polinoms.
        /// </summary>
        /// <param name="firstPolinom"> The first polinom. </param>
        /// <param name="secondPolinom"> The second polinom. </param>
        /// <returns> Result of summary. </returns>
        public static Polynomial operator +(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            Polynomial polinomWithMaxCoefficientsCount = firstPolinom._coefficients.Length > secondPolinom._coefficients.Length 
                ? firstPolinom : secondPolinom;
            double[] coefficients = polinomWithMaxCoefficientsCount._coefficients;
            for (int i = 0; i < Math.Min(firstPolinom._coefficients.Length, secondPolinom._coefficients.Length); i++)
            {
                coefficients[i] = firstPolinom._coefficients[i] + secondPolinom._coefficients[i];
            }
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Substracts two polinoms.
        /// </summary>
        /// <param name="firstPolinom"> The first polinom. </param>
        /// <param name="secondPolinom"> The second polinom. </param>
        /// <returns> Result of substracting. </returns>
        public static Polynomial operator -(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            Polynomial polinomWithMaxCoefficientsCount = firstPolinom._coefficients.Length > secondPolinom._coefficients.Length
                ? firstPolinom : secondPolinom;
            double[] coefficients = polinomWithMaxCoefficientsCount == firstPolinom
                ? firstPolinom._coefficients : (secondPolinom * -1)._coefficients;
            for (int i = 0; i < Math.Min(firstPolinom._coefficients.Length, secondPolinom._coefficients.Length); i++)
            {
                coefficients[i] = firstPolinom._coefficients[i] + secondPolinom._coefficients[i];
            }
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Multiples a polinom with a number.
        /// </summary>
        /// <param name="firstPolinom"> The polinom. </param>
        /// <param name="number"> Number. </param>
        /// <returns> Result of multipling. </returns>
        public static Polynomial operator *(Polynomial firstPolinom, double number)
        {
            for (int i = 0; i < firstPolinom._coefficients.Length; i++)
            {
                firstPolinom._coefficients[i] = firstPolinom._coefficients[i] * number;
            }
            return firstPolinom;
        }

        /// <summary>
        /// Divides a polinom with a number.
        /// </summary>
        /// <param name="firstPolinom">The polinom. </param>
        /// <param name="number"> Number. </param>
        /// <returns> Result of dividing. </returns>
        public static Polynomial operator /(Polynomial firstPolinom, double number)
        {
            for (int i = 0; i < firstPolinom._coefficients.Length; i++)
            {
                firstPolinom._coefficients[i] = firstPolinom._coefficients[i] / number;
            }
            return firstPolinom;
        }

        /// <summary>
        /// Matches whether two polinomes are equal.
        /// </summary>
        /// <param name="firstPolinom"> The first polinom. </param>
        /// <param name="secondPolinom"> The second polinom. </param>
        /// <returns> Result of matching. </returns>
        public static bool operator ==(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return firstPolinom.Equals(secondPolinom);
        }

        /// <summary>
        /// Matches whether two polinomes are not equal.
        /// </summary>
        /// <param name="firstPolinom"> The first polinom. </param>
        /// <param name="secondPolinom"> The second polinom. </param>
        /// <returns> Result of matching. </returns>
        public static bool operator !=(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return !firstPolinom.Equals(secondPolinom);
        }

        /// <summary>
        /// Calculates a value of polinom with double argument x.
        /// </summary>
        /// <param name="x"> Argument. </param>
        /// <returns> The value of polinom. </returns>
        public double Count(double x)
        {
            double result = 0;

            for (int i = 0; i < _coefficients.Length; i++)
            {
                result += _coefficients[i] * Math.Pow(x, i);
            }

            return result;
        }
    }
}
