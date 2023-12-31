﻿namespace Bookstore;

public class BookController
{

    BookService bookService = new BookService();
        
        public async Task AddBookUi (){
        // Prompt for the username and password

        Console.WriteLine("Enter Book Name");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Book Description");
        string description = Console.ReadLine();
        /// validation handled here .
        if(name!=null || name !="" && description!=null || description !="" ){

        Book newBook = new Book(){name=name,description=description};
         await  AddBookRequest(newBook);
        }else{
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Provide all the Required fields");
        }
        
    }

    // Book addition logic
    public async Task AddBookRequest (Book newBook){

        string response  = await bookService.AddBook(newBook);

        Console.WriteLine(response);
    } 

    public async Task GetBooksUI (){
        List<Book> books = await bookService.GetBooks();
        Console.WriteLine($"Book ID\t\tBook Title\t\tBook Description");
        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine($"{i+1}\t\t{books[i].name}\t\t{books[i].description}\n");
            
        }
    }

}
