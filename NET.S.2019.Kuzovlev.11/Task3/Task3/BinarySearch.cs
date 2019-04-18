using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public static class BinarySearch
    {
        public static int Find<T>(IEnumerable<T> enumerable, T value)
        {
            if (enumerable == null || value == null)
            {
                throw new ArgumentNullException();
            }

            List<T> list = enumerable.ToList();

            int left = 0, right = list.Count;
            int search = -1;

            while (left < right)
            {
                int middle = (left + right) / 2;
                int compareResult = ((IComparable<T>)value).CompareTo(list[middle]);

                if (compareResult == 0)
                {
                    search = middle;
                    break;
                }
                else if (compareResult < 0)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            return search;
        }        
    }
}
