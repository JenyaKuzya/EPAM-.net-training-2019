using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int n) : base(n) { }

        public override T this[int index1, int index2]
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

                if (index1 != index2)
                {
                    throw new ArgumentException("Indexes should be equal.");
                }
                _matrix[index1, index2] = value;
                OnChange(index1, index2);
            }
        }
    }
}
