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
        return Database.Posts[timelineOwnerUser];
    }

    public void Subscribe(User user, User targetUser)
    {
    }

    public ICollection<string> GetSubscriptionsAggregatedTimeline(User readerUser)
    {
        return new List<string>();
    }
}