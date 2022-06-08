namespace SocialNetwork;

public static class Database
{
    public static ICollection<User> Users { get; set; }
    public static IDictionary<User, ICollection<string>> Posts { get; set; }

    static Database()
    {
        Users = new List<User>();
        Posts = new Dictionary<User, ICollection<string>>();
    }
}