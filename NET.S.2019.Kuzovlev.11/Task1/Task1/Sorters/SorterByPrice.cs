using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SorterByPrice : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            return book1.Price.CompareTo(book2.Price);
        }
    }
}
