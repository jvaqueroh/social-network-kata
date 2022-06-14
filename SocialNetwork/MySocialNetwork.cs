namespace SocialNetwork;

public class MySocialNetwork
{
    public void AddUser(User user)
    {
        Database.Users.Add(user);
        Database.Posts.Add(user, new List<Post>());
        Database.Subscriptions.Add(user, new List<User>());
    }

    public void Post(User user, string message)
    {
        Database.Posts[user].Add(SocialNetwork.Post.Create(message));
    }

    public ICollection<string> GetTimeline(User readerUser, User timelineOwnerUser)
    {
        return Database.Posts[timelineOwnerUser]
            .Select(p => p.Message)
            .ToList();
    }

    public void Subscribe(User user, User targetUser)
    {
        Database.Subscriptions[user].Add(targetUser);
    }

    public ICollection<string> GetSubscriptionsAggregatedTimeline(User readerUser)
    {
        var aggregatedPostsList = new List<Post>();
        foreach (var targetUser in Database.Subscriptions[readerUser])
        {
            aggregatedPostsList.AddRange(Database.Posts[targetUser]);
        }
        return aggregatedPostsList
            .OrderBy(p => p.CreationDateTime)
            .Select(p=>p.Message)
            .ToList();
    }

    public ICollection<string> GetMentions(User user)
    {
        return new List<string>();
    }
}