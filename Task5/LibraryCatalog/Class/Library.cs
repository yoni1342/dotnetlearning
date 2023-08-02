namespace LibraryCatalog.Class;

public class Library{
    public Library(string name, string address){
        Name = name;
        Address = address;
    }
    public string Name {get; set;}
    public string Address {get; set;}
    private List<Book> Books {get; set;} = new List<Book>();

    private List<MediaItem> MediaItems {get; set;} = new List<MediaItem>();

    //add book to library if it titel and Isbn don't already exist
    public void AddBook(Book book){
        try{
            SearchBooksByTitle(book.Title);
            Console.WriteLine($"The book {book.Title} is already in the library.");
        } catch (Exception){
            try{
                SearchBooksByISBN(book.ISBN);
                Console.WriteLine($"The book {book.ISBN} is already in the library.");
            } catch (Exception){
                Books.Add(book);
            }
        }
    }

    // remove book from library by ISBN if it exists else exception
    public void RemoveBook(string ISBN)
    {
        Book book = Books.FirstOrDefault(book => book.ISBN == ISBN);
        if(book != null){
            Books.Remove(book);
        } else {
            throw new Exception($"The book {ISBN} is not in the library.");
        }
    }

    // get all books in library 
    public List<Book> GetBooks(){
        return Books;
    }

    // search for books by title 
    public Book SearchBooksByTitle(string title){
        Book book = Books.FirstOrDefault(book => book.Title == title);
        if(book != null){
            return book;
        } else {
            throw new Exception($"The book {title} is not in the library.");
        }
    }

    // search for book by author if it exists else return exception
    public List<Book> SearchBooksByAuthor(string author){
        List<Book> books = Books.Where(book => book.Author == author).ToList();
        if(books.Count > 0){
            return books;
        } else {
            throw new Exception($"The book {author} is not in the library.");
        }
    }

    // search for book by ISBN if it exists 
    public Book SearchBooksByISBN(string isbn){
        Book book = Books.FirstOrDefault(book => book.ISBN == isbn);
        if(book != null){
            return book;
        } else {
            throw new Exception($"The book {isbn} is not in the library.");
        }
    }

    // search for book by publication year 
    public List<Book> SearchBooksByPublicationYear(string publicationYear){
        List<Book> books = Books.Where(book => book.PublicationYear == publicationYear).ToList();
        if(books.Count > 0){
            return books;
        } else {
            throw new Exception($"The book {publicationYear} is not in the library.");
        }
    }

    // add media item to library if it doesn't already exist
    public void AddMediaItem(MediaItem mediaItem){
        if(!MediaItems.Contains(mediaItem)){
            MediaItems.Add(mediaItem);
        } else {
            Console.WriteLine($"The media item {mediaItem.Title} is already in the library.");
        }
    }

    // remove media item from library if it exists
    public void RemoveMediaItem(string mediaItemTitle){
        MediaItem mediaItem = MediaItems.FirstOrDefault(mediaItem => mediaItem.Title == mediaItemTitle);
        if(mediaItem != null){
            MediaItems.Remove(mediaItem);
        } else {
            throw new Exception($"The media item {mediaItemTitle} is not in the library.");
        }
    }

    // get all media items in library
    public List<MediaItem> GetMediaItems(){
        return MediaItems;
    }

    // search for media item by title
    public MediaItem SearchMediaItemsByTitle(string title){
        MediaItem mediaItem = MediaItems.FirstOrDefault(mediaItem => mediaItem.Title == title);
        if(mediaItem != null){
            return mediaItem;
        } else {
            throw new Exception($"The media item {title} is not in the library.");
        }
    }

    // search for media item by media type
    public List<MediaItem> SearchMediaItemsByMediaType(string mediaType){
        List<MediaItem> mediaItems = MediaItems.Where(mediaItem => mediaItem.MediaType == mediaType).ToList();
        if(mediaItems.Count > 0){
            return mediaItems;
        } else {
            throw new Exception($"The media item {mediaType} is not in the library.");
        }
    }

    // search for media item by duration
    public List<MediaItem> SearchMediaItemsByDuration(int duration){
        List<MediaItem> mediaItems = MediaItems.Where(mediaItem => mediaItem.Duration == duration).ToList();
        if(mediaItems.Count > 0){
            return mediaItems;
        } else {
            throw new Exception($"The media item {duration} is not in the library.");
        }
    }

    //print the catalog
    public void PrintCatalog(){
        Console.WriteLine($"The {Name} library is located at {Address}.");
        Console.WriteLine("Books:");
        foreach(Book book in Books){
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"ISBN: {book.ISBN}");
            Console.WriteLine($"Publication Year: {book.PublicationYear}");
        }
        Console.WriteLine("Media Items:");
        foreach(MediaItem mediaItem in MediaItems){
            Console.WriteLine($"Title: {mediaItem.Title}");
            Console.WriteLine($"Media Type: {mediaItem.MediaType}");
            Console.WriteLine($"Duration: {mediaItem.Duration}");
        }
    }

    

}  