using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task1
{
    public class Book: IEquatable<Book>, IComparable<Book>
    {
        public string Title { get; }
        public string Author { get; }
        public string Publisher { get; }
        public string Isbn { get; }
        public int PageCount { get; }
        public int Year { get; }
        public double Price { get; }

        public Book(string title, string author, int year, int pageCount, string publisher, double price = 0,
            string isbn = "0")
        {            
            CheckArguments(year, pageCount, price);
            //if (isbn != "0")  CheckISBN(isbn, year);

            Title = title;
            Author = author;
            Publisher = publisher;
            Isbn = isbn;
            PageCount = pageCount;
            Year = year;
            Price = price;
        }

        private void CheckISBN(string isbn, int year)
        {
            string pattern2007 = @"(/d)+[-| ](/d)+[-| ](/d)+[-| ](/d)+";
            string pattern = @"^978/d+[-| ]/d+[-| ]/d+[-| ]/d+";
            if (year < 2007 )
            {
                if (!Regex.IsMatch(isbn, pattern2007))
                {
                    throw new ArgumentException("ISBN is wrong!");
                }
            }
            else
            {
                if (!Regex.IsMatch(isbn, pattern))
                {
                    throw new ArgumentException("ISBN is wrong!");
                }
            }
        }

        private void CheckArguments(int year, int pageCount, double price)
        {
            if (year < 0  || pageCount < 0 || price < 0)
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return "Title: " + Title + " Author: " + Author + " Year: " + Year + " Count of pages: " + PageCount
                + " Publisher: " + Publisher + " Price: " + Price + " ISBN: " + Isbn;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(Book book)
        {
            if (book == null)
                return false;

            return Isbn == book.Isbn && Author == book.Author && Title == book.Title
                   && Publisher == book.Publisher && Year == book.Year && PageCount == book.PageCount;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Book book = obj as Book;
            if (book == null)
                return false;
            else
                return Equals(book);
        }

        public static bool operator ==(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return Object.Equals(book1, book2);

            return book1.Equals(book2);
        }

        public static bool operator !=(Book book1, Book book2)
        {
            if (((object)book1) == null || ((object)book2) == null)
                return !Object.Equals(book1, book2);

            return !book1.Equals(book2);
        }

        public int CompareTo(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            return Isbn.CompareTo(book.Isbn);
        }
    }
}
