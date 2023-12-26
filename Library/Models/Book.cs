namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ReleaseYear { get; set; }

    public List<Genre> Genres { get; set; } = new List<Genre>();
    
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public List<User> Users { get; set; } = new List<User>();
}