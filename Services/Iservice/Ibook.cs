namespace Bookstore;

public interface Ibook
{

    public Task<string> AddBook(Book newBook);

}
