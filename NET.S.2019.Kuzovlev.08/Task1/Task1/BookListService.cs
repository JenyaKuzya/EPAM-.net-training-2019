using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    public sealed class BookListService
    {
        public enum Crit
        {
            isbn,
            author,
            title,
            publisher,
            year,
            pages,
            price
        }

        private List<Book> bookListStorage;

        private static volatile BookListService instance = null;
        private static readonly object padlock = new object();

        BookListService()
        {
            bookListStorage = new List<Book>();
        }

        public static BookListService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new BookListService();
                        }
                    }
                }
                return instance;
            }
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book can't be null");
            }

            if (bookListStorage.Contains(book))
            {
                throw new ArgumentException("List contains this book already.");
            }

            bookListStorage.Add(book);
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book can't be null");
            }

            if (!bookListStorage.Contains(book))
            {
                throw new ArgumentException("List doesn't contain this book.");
            }

            bookListStorage.Remove(book);
        }

        public Book FindBookByTag(Crit crit, string value)
        {
            switch (crit)
            {
                case Crit.isbn:
                    return bookListStorage.Find(book => book.Isbn == value);
                case Crit.author:
                    return bookListStorage.Find(book => book.Author == value);
                case Crit.title:
                    return bookListStorage.Find(book => book.Title == value);
                case Crit.publisher:
                    return bookListStorage.Find(book => book.Publisher == value);
                case Crit.year:
                    return bookListStorage.Find(book => book.Year == int.Parse(value));
                case Crit.price:
                    return bookListStorage.Find(book => book.Price == int.Parse(value));
                case Crit.pages:
                    return bookListStorage.Find(book => book.PageCount == int.Parse(value));
                default:
                    return null;
            }
        }

        public void SortBooksByTag(Crit crit)
        {
            switch (crit)
            {
                case Crit.isbn:
                    bookListStorage.Sort(new SorterByISBN());
                    break;
                case Crit.author:
                    bookListStorage.Sort(new SorterByAuthor());
                    break;
                case Crit.title:
                    bookListStorage.Sort(new SorterByTitle());
                    break;
                case Crit.publisher:
                    bookListStorage.Sort(new SorterByPublisher());
                    break;
                case Crit.year:
                    bookListStorage.Sort(new SorterByYear());
                    break;
                case Crit.price:
                    bookListStorage.Sort(new SorterByPrice());
                    break;
                case Crit.pages:
                    bookListStorage.Sort(new SorterByPageCount());
                    break;
            }
        }

        public string PrintBooks()
        {
            string result = string.Empty;

            foreach (Book book in bookListStorage)
            {
                result += book.ToString();
            }

            return result;
        }

        public void SaveBooks(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (Book book in bookListStorage)
                {
                    writer.Write(book.Isbn);
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Publisher);
                    writer.Write(book.Year);
                    writer.Write(book.PageCount);
                    writer.Write(book.Price);
                }
            }
        }

        public void LoadBooks(string filename)
        {
            if (File.Exists(filename))
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
                {
                    List<Book> result = new List<Book>();

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        string isbn = reader.ReadString();
                        string author = reader.ReadString();
                        string title = reader.ReadString();
                        string publisher = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();
                        double price = reader.ReadDouble();

                        result.Add(new Book(title, author, year, pages, publisher, price, isbn));
                    }

                    bookListStorage = result;
                }
            }
        }
    }
}
