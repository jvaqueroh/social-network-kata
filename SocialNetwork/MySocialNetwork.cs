namespace SocialNetwork;

public class MySocialNetwork
{
    public void AddUser(User user)
    {
        Database.Users.Add(user);
        Database.Posts.Add(user, new List<string>());
        Database.Subscriptions.Add(user, new List<User>());
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
        Database.Subscriptions[user].Add(targetUser);
    }

    public ICollection<string> GetSubscriptionsAggregatedTimeline(User readerUser)
    {
        var aggregatedMessagesList = new List<string>();
        foreach (var targetUser in Database.Subscriptions[readerUser])
        {
            aggregatedMessagesList.AddRange(Database.Posts[targetUser]);
        }
        return aggregatedMessagesList;
    }
}