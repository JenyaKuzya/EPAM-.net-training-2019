using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class RouletteEventArgs
    {
        public int Number { get; }

        public RouletteEventArgs(int number)
        {
            Number = number;
        }
    }
}
