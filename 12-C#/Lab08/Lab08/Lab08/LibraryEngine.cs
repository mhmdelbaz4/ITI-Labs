namespace Lab08;

internal delegate string myDel (Book book);


internal class LibraryEngine
{

    public static void ProcessBooks(List<Book> bList, Func<Book,string> del)
    {
        foreach (Book book in bList)
        {
            Console.WriteLine(del?.Invoke(book));
        }
    }

    public static void ProcessBooksV2(List<Book> bList, myDel del)
    {
        foreach (Book book in bList)
        {
            Console.WriteLine(del?.Invoke(book));
        }
    }

}
