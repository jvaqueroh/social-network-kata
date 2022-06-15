namespace SocialNetwork;

public static class Database
{
    public static ICollection<User> Users { get; set; }
    public static IDictionary<User, ICollection<Post>> Posts { get; set; }
    public static IDictionary<User, ICollection<User>> Subscriptions { get; set; }
    public static IDictionary<User, ICollection<PrivateMessage>> PrivateMessages { get; }

    static Database()
    {
        Users = new List<User>();
        Posts = new Dictionary<User, ICollection<Post>>();
        Subscriptions = new Dictionary<User, ICollection<User>>();
        PrivateMessages = new Dictionary<User, ICollection<PrivateMessage>>();
    }
}