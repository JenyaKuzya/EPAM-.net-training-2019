using NUnit.Framework;
using System;
using Task1;

namespace Tests
{
    public class Tests
    {
        readonly Book book = new Book("Book", "Author", 2019, 987, "KMC Press", 100, "978-123-456-7-890");

        [TestCase("", ExpectedResult = "Title: Book Author: Author Year: 2019 " +
                "Count of pages: 987 Publisher: KMC Press Price: 100 ISBN: 978-123-456-7-890")]
        [TestCase("G", ExpectedResult = "Title: Book Author: Author Year: 2019 " +
                "Count of pages: 987 Publisher: KMC Press Price: 100 ISBN: 978-123-456-7-890")]
        [TestCase("C", ExpectedResult = "Title: Book Author: Author")]
        [TestCase("Year", ExpectedResult = "Title: Book Author: Author Year: 2019")]
        [TestCase("Pages", ExpectedResult = "Title: Book Author: Author Year: 2019 " +
                "Count of pages: 987")]
        [TestCase("Publisher", ExpectedResult = "Title: Book Author: Author Year: 2019 " +
                "Count of pages: 987 Publisher: KMC Press")]
        [TestCase("Price", ExpectedResult = "Title: Book Author: Author Year: 2019 " +
                "Count of pages: 987 Publisher: KMC Press Price: 100")]
        [TestCase("ISBN", ExpectedResult = "Title: Book Author: Author Year: 2019 ISBN: 978-123-456-7-890")]
        [Test]
        public string FormatTest(string format)
        {
            return book.ToString(format);
        }

        [Test]
        public void GetPublisherAndPriceTest()
        {
            string expected = "Title: Book Author: Author Publisher: KMC Press Price: 100";
            Assert.AreEqual(expected, book.GetPublisherAndPrice());
        }

        [Test]
        public void GetPublisherAndYearTest()
        {
            string expected = "Title: Book Author: Author Publisher: KMC Press Year: 2019";
            Assert.AreEqual(expected, book.GetPublisherAndYear());
        }

        [Test]
        public void GetPagesAndPublisherTest()
        {
            string expected = "Title: Book Author: Author Pages: 987 Publisher: KMC Press";
            Assert.AreEqual(expected, book.GetPagesAndPublisher());
        }

        [Test]
        public void GetISBNTest()
        {
            string expected = "Title: Book Author: Author ISBN: 978-123-456-7-890";
            Assert.AreEqual(expected, book.GetISBN());
        }

        [Test]
        public void GetYearAndISBNTest()
        {
            string expected = "Title: Book Author: Author ISBN: 978-123-456-7-890 Year: 2019";
            Assert.AreEqual(expected, book.GetYearAndISBN());
        }
    }
}