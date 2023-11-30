namespace Bookstore;

public interface Ibook
{

    public Task<string> AddBook(Book newBook);

    public Task<List<Book>> GetBooks();

}
