using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SquareMatrix<T>
    {
        public event EventHandler<ChangeEventArgs> ChangeElement;

        protected readonly T[,] _matrix;

        public SquareMatrix(int n)
        {
            _matrix = new T[n, n];
        }

        public int GetLength
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }

        public virtual T this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index1 >= _matrix.Length || index2 < 0 || index2 >= _matrix.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return _matrix[index1, index2];
            }
            set
            {
                if (index1 < 0 || index1 >= _matrix.Length || index2 < 0 || index2 >= _matrix.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                _matrix[index1, index2] = value;
                OnChange(index1, index2);               
            }
        }    
        
        protected void OnChange(int index1, int index2)
        {
            ChangeElement?.Invoke(this, new ChangeEventArgs(index1, index2));
        }

        public static SquareMatrix<T> operator +(SquareMatrix<T> arg1, SquareMatrix<T> arg2)
        {
            if (arg1 == null || arg2 == null)
                throw new ArgumentNullException();

            int shortestLength = Math.Min(arg1.GetLength, arg2.GetLength);
            SquareMatrix<T> argWithshortestLength = arg1.GetLength == shortestLength ? arg1 : arg2;

            try
            {
                for (int i = 0; i < shortestLength; i++)
                    for (int j = 0; j < shortestLength; j++)
                    {
                        arg1[i, j] += (dynamic)arg2[i, j];
                    }
            }
            catch
            {
                Console.WriteLine("Невозможно сложить элементы матрицы.");
            }

            return arg1;
        }
    }
}
