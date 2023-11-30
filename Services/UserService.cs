
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

    public  async Task<User> Login(string username , string password)
    { 
             
             try
             {
         var response = await _client.GetAsync(_URL+"?"+$"username={username}");
         var content = await response.Content.ReadAsStringAsync();
         List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(content);
         bool isMatch =false;
         if(users!=null){
            isMatch = true;
         }else{
            Console.WriteLine ("User Does Not Exist");
         }
         
        Console.WriteLine(isMatch ? "Log in Successfully" : "Invalid Credentials") ;

        return users[0];
             }
             catch (Exception e)
             {
                
                throw ;
             }

    }

    public async Task<string> Register(User newUser)
    {
        
        var content = Newtonsoft.Json.JsonConvert.SerializeObject(newUser);
        var body = new StringContent(content ,Encoding.UTF8 ,"application/json");
        var response = await _client.PostAsync(_URL , body);

        return response.IsSuccessStatusCode ? "Registration Succesfull": "Registration Failed";
    }
    public async Task<List<User>> GetUsers (){


         try
         {

         var response = await _client.GetAsync(_URL);
         var content = await response.Content.ReadAsStringAsync();
         List<User> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(content); 

         return users;

            
         }
         catch (System.Exception)
         {
            
            throw;
         }
        
    }
}
