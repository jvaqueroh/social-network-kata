namespace SocialNetwork
{
    public class MySocialNetwork
    {
        public UserSession Login(string user)
        {
            return new UserSession();
        }

        public TimeLine GetTimeline()
        {
            return new TimeLine();
        }
    }

    public class TimeLine
    {
        public List<Message> GetMessages()
        {
            return new List<Message>();
        }
    }

    public class UserSession
    {
        public void Publish(Message aMessage)
        {
        }
    }

    public class Message
    {
        public Message(string message)
        {
        }
    }
}