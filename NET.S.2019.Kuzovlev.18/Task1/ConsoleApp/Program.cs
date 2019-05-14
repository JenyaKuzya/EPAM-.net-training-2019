using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            URLSerializer serializer = new URLSerializer();
            serializer.Serialize("input.txt", "result.txt");
        }
    }
}
