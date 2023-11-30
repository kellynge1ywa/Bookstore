
using System.Text;

namespace Bookstore;

public class OrderService : Iorder
{
    private readonly HttpClient _client ;
    private readonly string _URL = "http://localhost:3000/orders";
    public async Task<string> CreateOrder(Order order)
    {   Console.WriteLine("Debugging"+order);
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(order);
        var body = new StringContent(content , Encoding.UTF8,"application/json");
        var response = await _client.PostAsync(_URL , body);

        return response.IsSuccessStatusCode ? "Order Created successfully":"Something went wrong Order not created ";
    }
}
