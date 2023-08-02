namespace LibraryCatalog;

using System.Data.Common;
using LibraryCatalog.Class;

public class Program{
    public static void Main(string[] args)
    {
        bool running = true;

        Console.WriteLine("Welcome to the Library Catalog!");
        Console.WriteLine("Please enter the name of your library:");
        string libraryName = Console.ReadLine()!;
        Console.WriteLine("Please enter the address of your library:");
        string libraryAddress = Console.ReadLine()!;
        Library library = new Library(libraryName, libraryAddress);

        while(running)
        {
            Console.WriteLine("What would you like to do?");
            Console.Write("1. Add a book to the library");
            Console.WriteLine("\t\t 2. Add a media item to the library");
            Console.Write("3. Get all books in the library");
            Console.WriteLine("\t\t 4. Get all media items in the library");
            Console.Write("5. Search for a book by title");
            Console.WriteLine("\t\t 6. Search for a media item by title");
            Console.Write("7. Search for a book by author");
            Console.WriteLine("\t\t 8. Search for a media item by duration");
            Console.Write("9. Search for a book by ISBN");
            Console.WriteLine("\t\t 10. Search for a media item by media type");
            Console.Write("11.Search for a book by publication year");
            Console.WriteLine("\t12. Remove a media item from the library");
            Console.WriteLine("13.Remove a book from the library");
            Console.WriteLine("");
            Console.WriteLine("14. Print the library catalog");
            Console.WriteLine("15. Exit the program");
            int.TryParse(Console.ReadLine(), out int choice);

            switch(choice)
            {   
                case 1:
                // accept the book info
                    Console.WriteLine("Please enter the title of the book you'd like to add:");
                    string bookTitle = Console.ReadLine()!;
                    Console.WriteLine("Please enter the author of the book you'd like to add:");
                    string bookAuthor = Console.ReadLine()!;
                    Console.WriteLine("Please enter the ISBN of the book you'd like to add:");
                    string bookISBN = Console.ReadLine()!;
                    Console.WriteLine("Please enter the publication year of the book you'd like to add:");
                    string bookPublicationYear = Console.ReadLine()!;
                    // create book object form Book class
                    Book book = new Book(bookTitle, bookAuthor, bookISBN, bookPublicationYear);
                    // add book to library
                    library.AddBook(book);
                    break;
                case 2:
                // accept the media item info
                    Console.WriteLine("Please enter the title of the media item you'd like to add:");
                    string mediaItemTitle = Console.ReadLine()!;
                    Console.WriteLine("Please enter the media type of the media item you'd like to add:");
                    string mediaItemType = Console.ReadLine()!;
                    Console.WriteLine("Please enter the duration of the media item you'd like to add:");
                    int.TryParse(Console.ReadLine(), out int mediaItemDuration);
                    // create media item object from MediaItem class

                    MediaItem mediaItem = new MediaItem(mediaItemTitle, mediaItemType, mediaItemDuration);

                    // add media item to library
                    library.AddMediaItem(mediaItem);
                    break;
                case 3:
                    try
                    {
                        List<Book> books = library.GetBooks();
                        foreach(Book singleBook in books)
                        {
                            Console.WriteLine($"Title: {singleBook.Title}");
                            Console.WriteLine($"Author: {singleBook.Author}");
                            Console.WriteLine($"ISBN: {singleBook.ISBN}");
                            Console.WriteLine($"Publication Year: {singleBook.PublicationYear}");
                            Console.WriteLine("");
                            Console.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 4:
                    try
                    {
                        List<MediaItem> mediaItems = library.GetMediaItems();
                        foreach(MediaItem singleMediaItem in mediaItems)
                        {
                            Console.WriteLine($"Title: {singleMediaItem.Title}");
                            Console.WriteLine($"Media Type: {singleMediaItem.MediaType}");
                            Console.WriteLine($"Duration: {singleMediaItem.Duration}");
                            Console.WriteLine();
                            Console.ReadLine();

                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case 5:
                    try{
                        Console.WriteLine("Please enter the title of the book you'd like to search for:");
                        string booktitle = Console.ReadLine()!;
                        Book singleBook = library.SearchBooksByTitle(booktitle);
                        Console.WriteLine($"Title: {singleBook.Title}");
                        Console.WriteLine($"Author: {singleBook.Author}");
                        Console.WriteLine($"ISBN: {singleBook.ISBN}");
                        Console.WriteLine($"Publication Year: {singleBook.PublicationYear}");
                        Console.WriteLine();
                        Console.ReadLine();
                        
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 6:
                    try{
                        Console.WriteLine("Please enter the title of the media item you'd like to search for:");
                        string mediaItemTitlee = Console.ReadLine()!;
                        MediaItem singleMediaItem = library.SearchMediaItemsByTitle(mediaItemTitlee);
                        Console.WriteLine($"Title: {singleMediaItem.Title}");
                        Console.WriteLine($"Media Type: {singleMediaItem.MediaType}");
                        Console.WriteLine($"Duration: {singleMediaItem.Duration}");
                        Console.WriteLine();
                        Console.ReadLine();

                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 7:
                    try{
                        Console.WriteLine("Please enter the author of the book you'd like to search for:");
                        string bookAuthorName = Console.ReadLine()!;
                        List<Book> books = library.SearchBooksByAuthor(bookAuthorName);
                        foreach(Book singleBook in books)
                        {
                            Console.WriteLine($"Title: {singleBook.Title}");
                            Console.WriteLine($"Author: {singleBook.Author}");
                            Console.WriteLine($"ISBN: {singleBook.ISBN}");
                            Console.WriteLine($"Publication Year: {singleBook.PublicationYear}");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                
                case 8:
                    try{
                        Console.WriteLine("Please enter the duration of the media item you'd like to search for:");
                        int.TryParse(Console.ReadLine(), out int ItemDuration);
                        List<MediaItem> mediaItems = library.SearchMediaItemsByDuration(ItemDuration);
                        foreach(MediaItem singleMediaItem in mediaItems)
                        {
                            Console.WriteLine($"Title: {singleMediaItem.Title}");
                            Console.WriteLine($"Media Type: {singleMediaItem.MediaType}");
                            Console.WriteLine($"Duration: {singleMediaItem.Duration}");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 9:
                    try{
                        Console.WriteLine("Please enter the ISBN of the book you'd like to search for:");
                        string ISBN = Console.ReadLine()!;
                        Book singleBook = library.SearchBooksByISBN(ISBN);
                        Console.WriteLine($"Title: {singleBook.Title}");
                        Console.WriteLine($"Author: {singleBook.Author}");
                        Console.WriteLine($"ISBN: {singleBook.ISBN}");
                        Console.WriteLine($"Publication Year: {singleBook.PublicationYear}");
                        Console.WriteLine();
                        Console.ReadLine();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 10:
                    try{
                        Console.WriteLine("Please enter the media type of the media item you'd like to search for:");
                        string ItemType = Console.ReadLine()!;
                        List<MediaItem> mediaItems = library.SearchMediaItemsByMediaType(ItemType);
                        foreach(MediaItem sigleMediaItem in mediaItems)
                        {
                            Console.WriteLine($"Title: {sigleMediaItem.Title}");
                            Console.WriteLine($"Media Type: {sigleMediaItem.MediaType}");
                            Console.WriteLine($"Duration: {sigleMediaItem.Duration}");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 11:
                    // search a book by publication year
                    try{
                        Console.WriteLine("Please enter the publication year of the book you'd like to search for:");
                        string publicationYear = Console.ReadLine()!;
                        List<Book> books = library.SearchBooksByPublicationYear(publicationYear);
                        foreach(Book singleBook in books)
                        {
                            Console.WriteLine($"Title: {singleBook.Title}");
                            Console.WriteLine($"Author: {singleBook.Author}");
                            Console.WriteLine($"ISBN: {singleBook.ISBN}");
                            Console.WriteLine($"Publication Year: {singleBook.PublicationYear}");
                            Console.WriteLine();
                            Console.ReadLine();
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 12:
                // remove media item
                    try{
                        Console.WriteLine("Please enter the title of the media item you'd like to remove:");
                        string mediaTitle = Console.ReadLine()!;
                        library.RemoveMediaItem(mediaTitle);
                        Console.WriteLine("Media item removed successfully!");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;

                case 13:
                // remove book by isbn
                    try{
                        Console.WriteLine("Please enter the ISBN of the book you'd like to remove:");
                        string ISBN = Console.ReadLine()!;
                        library.RemoveBook(ISBN);
                        Console.WriteLine("Book removed successfully!");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);    
                    }
                    break;
                case 14:
                    // print the library catalog
                    library.PrintCatalog();
                    break;

                case 15:
                // exit
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
            }            
        }
    }
}