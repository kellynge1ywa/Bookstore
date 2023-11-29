namespace Bookstore;

public class UserController
{

    UserService userService = new UserService();

    public async Task  init (){
        Console.WriteLine("Choose an Option : \n 1.Register \n 2. Login \n 3.Exit ");
        string option = Console.ReadLine();
        // validation of the option 
        bool success = int.TryParse(option, out int result); 
        await UserOption(result);

    }

    public async Task  UserOption (int option){

        switch(option){
            case 1:
            await RegisterUserUi();
            Console.WriteLine("Welcome to the Register Page");
            break;
            case 2:
            Console.WriteLine("Welcome to the Login Page");
            break;
            case 3:
            await init();
            break;
        }

    }

    public async Task RegisterUserUi (){
        // Prompt for the username and password

        Console.WriteLine("Enter Your Username");
        string username = Console.ReadLine();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine();
        /// validation handled here .

        User newUser = new User (){username=username , password=password };

         // register the user 

         await RegisterUserRequest(newUser);
    } 
    public async Task RegisterUserRequest (User newUser){

        string response  = await userService.Register(newUser);

       Console.WriteLine(response);

       await init();

    } 

}
