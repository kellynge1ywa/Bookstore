namespace Bookstore;

public interface Iorder
{
       public Task<string> CreateOrder(Order order); 

}
