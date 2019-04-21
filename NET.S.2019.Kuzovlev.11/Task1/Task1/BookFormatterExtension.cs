using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class BookFormattingExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetPublisherAndPrice(this Book book)
        {
            return "Title: " + book.Title + " Author: " + book.Author + " Publisher: " + book.Publisher 
                + " Price: " + book.Price;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetPublisherAndYear(this Book book)
        {
            return "Title: " + book.Title + " Author: " + book.Author + " Publisher: " + book.Publisher
                + " Year: " + book.Year;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetPagesAndPublisher(this Book book)
        {
            return "Title: " + book.Title + " Author: " + book.Author + " Pages: " + book.PageCount
                + " Publisher: " + book.Publisher;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetISBN(this Book book)
        {
            return "Title: " + book.Title + " Author: " + book.Author + " ISBN: " + book.Isbn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public static string GetYearAndISBN(this Book book)
        {
            return "Title: " + book.Title + " Author: " + book.Author + " ISBN: " + book.Isbn + " Year: " + book.Year;
        }
    }
}
