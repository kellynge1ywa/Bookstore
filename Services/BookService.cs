
using System.Text;

namespace Bookstore;

public class BookService : Ibook
{
    private readonly HttpClient _client;
    private readonly string _URL = "http://localhost:3000/books";

    public BookService (){
        _client = new HttpClient();
    }
    public async Task<string> AddBook(Book newBook)
    {
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(newBook);
        var body = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _client.PostAsync(_URL,body);
        return response.IsSuccessStatusCode ? "Book was Added Successfully" : "Book addition failed";
    }

    public async Task<List<Book>> GetBooks()
    {   var response = await _client.GetAsync(_URL);
        var content = await response.Content.ReadAsStringAsync();
        List<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(content);
        foreach (var book in books)
        {
            Console.WriteLine(book.name);
        }
        return books;
    }
}
