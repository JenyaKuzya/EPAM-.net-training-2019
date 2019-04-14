using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SorterByAuthor: IComparer<Book>
    {
        public int Compare(Book book1, Book book2)
        {
            return book1.Author.CompareTo(book2.Author);
        }
    }
}
