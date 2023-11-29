
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
}
