namespace SocialNetwork;

public class MySocialNetwork
{
    public void AddUser(User user)
    {
        Database.Users.Add(user);
        Database.Posts.Add(user, new List<string>());
    }

    public void Post(User user, string message)
    {
        Database.Posts[user].Add(message);
    }

    public ICollection<string> GetTimeline(User readerUser, User timelineOwnerUser)
    {
        return new List<string>();
    }
}