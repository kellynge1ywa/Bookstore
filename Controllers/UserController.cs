namespace Bookstore;

public class UserController
{

    UserService userService = new UserService();

    public async Task  Init (){
        Console.WriteLine("Choose an Option : \n 1.Register \n 2.Login \n 3.Exit ");
        string option = Console.ReadLine();
        // validation of the option 
        bool success = int.TryParse(option, out int result); 
        if(success){
           await UserOption(result);

        }else{
            Console.WriteLine("Invalid Character");
        }

    }

    public async Task  UserOption (int option){

        switch(option){
            case 1:
            Console.WriteLine("Welcome to the Register Page");
            await RegisterUserUi();
            break;
            case 2:
            Console.WriteLine("Welcome to the Login Page");
            await LoginUserUi();
            break;
            case 3:
            Console.WriteLine("Exited Successfully...");
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

        User newUser = new User (){username=username , password=password};

         // register the user 

         await RegisterUserRequest(newUser);
    }
    
    // Registration logic
    public async Task RegisterUserRequest (User newUser){

        string response  = await userService.Register(newUser);

       Console.WriteLine(response);

       await Init();

    } 


    // Login user interface
       public async Task LoginUserUi (){
        // Prompt for the username and password

        Console.WriteLine("Enter Your Username");
        string username = Console.ReadLine();
        Console.WriteLine("Enter Your Password");
        string password = Console.ReadLine();
        /// validation handled here .


         // register the user 
         User loggedInUser = await LoginUserRequest(username , password);
         Console.WriteLine(loggedInUser.isAdmin);
         if(loggedInUser.isAdmin){

            // Logic for admins page 
            BookController bookController = new BookController();
           await  bookController.AddBookUi();
            
         }else{
            //logic for users page
         }

    } 

    // Login logic
    public async Task<User> LoginUserRequest (string username , string password){

       User loggedInUser = await userService.Login(username , password);

       return loggedInUser;
    } 


}
