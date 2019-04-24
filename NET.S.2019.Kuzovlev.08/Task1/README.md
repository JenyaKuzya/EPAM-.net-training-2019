Create a Book class (ISBN, author, title, publisher, year of publication, number of pages, price). Override all necessary methods of *Object( class. Implement IComparable and IEquatable interfaces for Book class. Create a BookListService class as a service to work with a collection of books with the following methods:

- AddBook (adds a book if not exists in the collection, otherwise throws an exception);
- RemoveBook (removes a book if it exists, otherwise throws an exception);
- FindBookByTag (finds a book by a given criterio);
- SortBooksByTag (sorts books by a given criterio).
- Create a BookListService class to perform basic operations with a list of books, which can be loaded and/or saved in a BookListStorage. Test classes by a console application. Use a binary file as storage. Only BinaryReader and BinaryWriter classes are allowed to work with. Do not use delegates.