
using System.Text;
using System.Text.Json.Serialization;
namespace Bookstore;

public class OrderService : Iorder
{
    private readonly HttpClient _client ;
    private readonly string _URL = "http://localhost:3000/orders";

    public OrderService()
    {

        _client = new HttpClient();

    }

    public async Task<string> CreateOrder(Order order)
    {   
        try
        {
            
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(order);
        var body =new StringContent(content , Encoding.UTF8,"application/json");
        var response = await _client.PostAsync(_URL , body);

        return response.IsSuccessStatusCode ? "Order Created successfully":"Something went wrong Order not created ";
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }


    }
}
