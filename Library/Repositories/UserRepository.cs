using Library.Models;

namespace Library.Repositories;

public class UserRepository
{
    public User Get(int id)
    {
        using var db = new AppContext();
        return db.Users.FirstOrDefault(x => x.Id == id);
    }

    public List<User> GetAll()
    {
        using var db = new AppContext();
        return db.Users.ToList();
    }

    public void Add(string name, string email)
    {
        using var db = new AppContext();
        var newUser = new User
        {
            Name = name,
            Email = email
        };

        db.Users.Add(newUser);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        using var db = new AppContext();
        var user = db.Users.FirstOrDefault(x => x.Id == id);

        db.Users.Remove(user);
        db.SaveChanges();
    }

    public void UpdateName(int id, string newName)
    {
        using var db = new AppContext();
        var user = db.Users.FirstOrDefault(x => x.Id == id);

        user.Name = newName;
        db.SaveChanges();
    }
}