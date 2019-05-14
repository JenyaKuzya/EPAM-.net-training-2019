using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class URL
    {
        public string HostName { get; set; }

        public List<string> URI { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
