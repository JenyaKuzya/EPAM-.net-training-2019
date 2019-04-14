using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Sorters
{
    public class SorterByMinElem : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr1.Min().CompareTo(arr2.Min());
        }
    }
}
