using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public sealed class Polynomial
    {
        private double[] _coefficients;

        public Polynomial(double[] coefficients)
        {
            _coefficients = coefficients ?? throw new ArgumentNullException();
        }

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

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

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

        public static Polynomial operator -(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            Polynomial polinomWithMaxCoefficientsCount = firstPolinom._coefficients.Length > secondPolinom._coefficients.Length
                ? firstPolinom : secondPolinom;
            double[] coefficients = polinomWithMaxCoefficientsCount == firstPolinom
                ? firstPolinom._coefficients : (secondPolinom * -1)._coefficients;
            for (int i = 0; i < Math.Min(firstPolinom._coefficients.Length, secondPolinom._coefficients.Length); i++)
            {
                coefficients[i] = firstPolinom._coefficients[i] - secondPolinom._coefficients[i];
            }
            return new Polynomial(coefficients);
        }

        public static Polynomial operator *(Polynomial firstPolinom, double number)
        {
            for (int i = 0; i < firstPolinom._coefficients.Length; i++)
            {
                firstPolinom._coefficients[i] = firstPolinom._coefficients[i] * number;
            }
            return firstPolinom;
        }

        public static Polynomial operator /(Polynomial firstPolinom, double number)
        {
            for (int i = 0; i < firstPolinom._coefficients.Length; i++)
            {
                firstPolinom._coefficients[i] = firstPolinom._coefficients[i] / number;
            }
            return firstPolinom;
        }

        public static bool operator ==(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return firstPolinom.Equals(secondPolinom);
        }

        public static bool operator !=(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return !firstPolinom.Equals(secondPolinom);
        }

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
