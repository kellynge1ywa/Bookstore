namespace Bookstore;

public class OrderController
{ 


    OrderService orderService = new OrderService();
    
    public async Task CreatOrderRequest (Order order){


      string response = await orderService.CreateOrder(order);
      Console.WriteLine(response);
    } 

}
