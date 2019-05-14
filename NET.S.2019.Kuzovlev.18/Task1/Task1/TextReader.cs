using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class TextReader
    {
        public List<string> Parse(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("Incorrect file path");

            string[] urls = File.ReadAllLines(filePath);

            return urls.ToList();
        }
    }
}
