using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Task1
{
    public class Book: IEquatable<Book>, IComparable<Book>, IFormattable
    {
        private readonly ILogger logger = new NLogger();

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

            logger.Log("Info", "New book was created.");
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
                logger.Log("Error", "Wrong arguments for book.");
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);            
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format)
            {
                case "G":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year + " Count of pages: " + PageCount
                + " Publisher: " + Publisher + " Price: " + Price + " ISBN: " + Isbn;
                case "C":
                    return "Title: " + Title + " Author: " + Author;
                case "Year":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year;
                case "Pages":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year + " Count of pages: " + PageCount;
                case "Publisher":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year + " Count of pages: " + PageCount
                + " Publisher: " + Publisher;
                case "Price":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year + " Count of pages: " + PageCount
                + " Publisher: " + Publisher + " Price: " + Price;
                case "ISBN":
                    return "Title: " + Title + " Author: " + Author + " Year: " + Year + " ISBN: " + Isbn;
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
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
