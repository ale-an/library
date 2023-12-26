using Library.Models;

namespace Library;

public class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var user1 = new User { Name = "Arthur"};
            var user2 = new User { Name = "klim"};

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
        }
    }
}