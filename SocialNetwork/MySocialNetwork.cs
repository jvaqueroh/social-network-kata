namespace SocialNetwork;

public class MySocialNetwork
{
    public void AddUser(User user)
    {
        Database.Users.Add(user);
    }

    public void Post(User user, string message)
    {
    }

    public ICollection<string> GetTimeline(User readerUser, User timelineOwnerUser)
    {
        return new List<string>();
    }
}