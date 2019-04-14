using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SorterByPageCount : IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            return book1.PageCount.CompareTo(book2.PageCount);
        }
    }
}
