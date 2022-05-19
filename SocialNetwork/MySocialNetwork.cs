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
        throw new NotImplementedException();
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

    public User(string userName)
    {
        UserName = userName;
        Posts = new List<Post>();
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