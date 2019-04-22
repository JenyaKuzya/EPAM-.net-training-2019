using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class ChangeEventArgs
    {
        public int Index1 { get; }
        public int Index2 { get; }

        public ChangeEventArgs(int index1, int index2)
        {
            Index1 = index1;
            Index2 = index2;
        }
    }
}
