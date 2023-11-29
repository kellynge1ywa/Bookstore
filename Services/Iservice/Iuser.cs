namespace Bookstore;

public interface Iuser
{

    Task<string> Register (User newUser);
    Task<User> Login(string username , string password);

}
