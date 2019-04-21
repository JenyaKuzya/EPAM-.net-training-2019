using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("MyTitle1", "MyAuthor1", 1981, 101, "MyPublisher1", 100, "2-266-11156-6");
            Book book2 = new Book("MyTitle2", "MyAuthor2", 1982, 102, "MyPublisher2", 100, "2-266-11156-6");
            Book book3 = new Book("MyTitle3", "MyAuthor3", 1983, 103, "MyPublisher3", 100, "2-266-11156-6");
            BookListService service = BookListService.Instance;
            service.AddBook(book2);
            service.AddBook(book1);
            service.AddBook(book3);
            Console.WriteLine(service.PrintBooks());
            Console.WriteLine("_______________________________________________________");
            service.SortBooksByTag(BookListService.Crit.author);
            Console.WriteLine(service.PrintBooks());
            service.SaveBooks("Books");
            service.LoadBooks("Books");
            Console.ReadLine();
            

        }
    }
}
