namespace SocialNetwork;

public static class Database
{
    public static ICollection<User> Users { get; set; }
    public static IDictionary<User, ICollection<Post>> Posts { get; set; }
    public static IDictionary<User, ICollection<User>> Subscriptions { get; set; }

    static Database()
    {
        Users = new List<User>();
        Posts = new Dictionary<User, ICollection<Post>>();
        Subscriptions = new Dictionary<User, ICollection<User>>();
    }
}