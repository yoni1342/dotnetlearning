namespace LibraryCatalog.Class;

public class Book{

    public Book(string title, string author, string isbn, string publicationYear){
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }
    public string Title {get; set;}
    public string Author {get; set;}
    public string ISBN {get; set;}
    public string PublicationYear {get; set;}

}