
using System.Text;
using System.Text.Json.Serialization;

namespace Bookstore;

public class UserService : Iuser
{

    private readonly HttpClient _client ;
    private readonly string _URL = "http://localhost:3000/users";
// Costructor to initialize the HttpCient
    public UserService (){
        _client = new HttpClient();
    }
    public async Task<string> Register(User newUser)
    {
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(newUser);
        var body = new StringContent(content ,Encoding.UTF8 ,"application/json");
        var response = await _client.PostAsync(_URL , body);

        return response.IsSuccessStatusCode ? "Registration Succesfull": "";
    }
}
