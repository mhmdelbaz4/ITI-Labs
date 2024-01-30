using Lab08;

List<Book> bookList = new List<Book>()
{
    new Book("100","Title1",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(1980,8,4),150.7m),
    new Book("110","Title2",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2000,10,4),270.6m),
    new Book("120","Title3",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2010,5,4),750.6m),
    new Book("130","Title4",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2015,7,14),500.0m),
    new Book("140","Title5",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2005,11,24),1100.5m),
    new Book("150","Title6",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2015,1,1),550.9m),
    new Book("160","Title7",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2020,3,2),250.5m),
    new Book("170","Title8",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2023,7,9),2000.0m),
    new Book("180","Title9",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2010,1,5),210.5m),
    new Book("190","Title10",new string[]{"Author1", "Author2", "Author3", "Author4", },new DateTime(2011,6,6),1000.9m)
};


// func -> built-in
Console.WriteLine("Books ISBN");
LibraryEngine.ProcessBooks(bookList, BookFunctions.GetISBN!);
Console.WriteLine("*****************************************");

// lambda expression
Console.WriteLine("Books Titles");
LibraryEngine.ProcessBooks(bookList, (book) => book.Title!);
Console.WriteLine("*****************************************");


// func -> built in
Console.WriteLine("Books Authors");
LibraryEngine.ProcessBooks(bookList, BookFunctions.GetAuthors!);
Console.WriteLine("*****************************************");


// annoymous method
Console.WriteLine("Books PublicationDate");
LibraryEngine.ProcessBooks(bookList, delegate (Book book) { return book.PublicationDate.ToString(); });
Console.WriteLine("*****************************************");

// user-defined delegate
Console.WriteLine("Books Prices");
LibraryEngine.ProcessBooksV2(bookList, BookFunctions.GetPrice!);
Console.WriteLine("*****************************************");
