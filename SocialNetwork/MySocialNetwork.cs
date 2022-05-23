namespace SocialNetwork;

public class MySocialNetwork
{
    public ICollection<User> Users { get; }

    public MySocialNetwork()
    {
        Users = new List<User>();
    }

    public void AddUser(string userName)
    {
        Users.Add(new User(userName));
    }

    public void CreatePost(string user, string message)
    {
        Users.Single(u => u.UserName.Equals(user)).Posts.Add(new Post(message));
    }

    public void Follow(string user, string userToFollow)
    {
        Users.Single(u => u.UserName.Equals(user)).FollowingUsers.Add(userToFollow);
    }

    public ICollection<string> GetSubscriptionsMessages(string user)
    {
        throw new NotImplementedException();
    }
}

public class User
{
    public string UserName { get; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<string> FollowingUsers { get; set; }

    public User(string userName)
    {
        UserName = userName;
        Posts = new List<Post>();
        FollowingUsers = new List<string>();
    }
}

public class Post
{
    public string Message { get; }

    public Post(string message)
    {
        Message = message;
    }
}