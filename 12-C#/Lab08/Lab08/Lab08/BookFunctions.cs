namespace Lab08;

internal class BookFunctions
{
    public static string? GetTitle(Book book)
    {
        return book.Title;
    }
    public static string? GetAuthors(Book book)
    {
        return string.Join(" ,", book.Authors!); 
    }
    public static string? GetPrice(Book book)
    {
        return book.Price.ToString();
    }

    public static string? GetPublciationDate(Book book)
    {
        return book.PublicationDate.ToString();
    }

    public static string? GetISBN(Book book)
    {
        return book.ISBN;
    }
}
