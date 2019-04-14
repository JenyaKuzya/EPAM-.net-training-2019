using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SorterBySum : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr1.Sum().CompareTo(arr2.Sum());
        }
    }
}
