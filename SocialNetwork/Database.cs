namespace SocialNetwork;

public static class Database
{
    public static ICollection<User> Users { get; set; }

    static Database()
    {
        Users = new List<User>();
    }
}