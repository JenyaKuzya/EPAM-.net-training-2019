using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int n) : base(n) { }

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
                _matrix[index1, index2] = value;
                _matrix[index2, index1] = value;
                ChangeElement?.Invoke(this, new ChangeEventArgs(index1, index2));
            }
        }
    }
}
