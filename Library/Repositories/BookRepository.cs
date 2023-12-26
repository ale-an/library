using Library.Models;

namespace Library.Repositories;

public class BookRepository
{
    public Book Get(int id)
    {
        using var db = new AppContext();

        return db.Books.FirstOrDefault(x => x.Id == id);
    }

    public List<Book> GetAll()
    {
        using var db = new AppContext();
        return db.Books.ToList();
    }

    public void Add(string title, string author, int releaseYear)
    {
        using var db = new AppContext();
        var newBook = new Book
        {
            Title = title,
            ReleaseYear = releaseYear
        };

        db.Books.Add(newBook);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppContext();
        var book = db.Books.FirstOrDefault(x => x.Id == id);

        db.Books.Remove(book);
        db.SaveChanges();
    }

    public void UpdateReleaseYear(int id, int newYear)
    {
        using var db = new AppContext();

        var book = db.Books.FirstOrDefault(x => x.Id == id);

        book.ReleaseYear = newYear;
        db.SaveChanges();
    }

    //Получать список книг определенного жанра и вышедших между определенными годами
    public List<Book> Get(int genreId, int firstYear, int secondYear)
    {
        using var db = new AppContext();

        var genre = db.Genres.FirstOrDefault(x => x.Id == genreId);

        return db.Books
            .Where(x => x.Genres.Contains(genre))
            .Where(x => x.ReleaseYear >= firstYear && x.ReleaseYear <= secondYear)
            .ToList();
    }

    //Получать количество книг определенного автора в библиотеке
    public int GetCountByAuthor(int authorId)
    {
        using var db = new AppContext();

        return db.Books.Where(x => x.AuthorId == authorId).Count();
    }

    //Получать количество книг определенного жанра в библиотеке
    public int GetCountByGenre(int genreId)
    {
        using var db = new AppContext();

        var genre = db.Genres.FirstOrDefault(x => x.Id == genreId);

        return db.Books.Where(x => x.Genres.Contains(genre)).Count();
    }

    //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке
    public bool HasWithAuthorAndTitle(int authorId, string title)
    {
        using var db = new AppContext();

        return db.Books
            .Where(x => x.AuthorId == authorId)
            .Where(x => x.Title.Contains(title))
            .Any();
    }

    //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя
    public bool HasUser(int userId, int bookId)
    {
        using var db = new AppContext();

        var user = db.Users.FirstOrDefault(x => x.Id == userId);

        return db.Books
            .Where(x => x.Users.Contains(user))
            .Where(x => x.Id == bookId)
            .Any();
    }

    //Получать количество книг на руках у пользователя
    public int GetCountByUser(int userId)
    {
        using var db = new AppContext();

        var user = db.Users.FirstOrDefault(x => x.Id == userId);

        return db.Books.Where(x => x.Users.Contains(user)).Count();
    }

    //Получение последней вышедшей книги
    public Book GetLast()
    {
        using var db = new AppContext();

        return db.Books.OrderBy(x => x.ReleaseYear).LastOrDefault();
    }

    //Получение списка всех книг, отсортированного в алфавитном порядке по названию
    public List<Book> GetSortedByTitle()
    {
        using var db = new AppContext();

        return db.Books.OrderBy(x => x.Title).ToList();
    }

    //Получение списка всех книг, отсортированного в порядке убывания года их выхода
    public List<Book> GetSortedByYear()
    {
        using var db = new AppContext();

        return db.Books.OrderByDescending(x => x.ReleaseYear).ToList();
    }
}