namespace SocialNetwork
{
    public class MySocialNetwork
    {
        public UserSession Login(string user)
        {
            return new UserSession(user);
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
        public string User { get; private set; }

        public UserSession(string user)
        {
            User = user;
        }

        public void Publish(Message aMessage)
        {
        }

    }

    public class Message
    {
        public Message(string message)
        {
        }

        public string Content { get; set; }
    }
    
    public interface MessageRepository
    {
        void Save(Message message);
    }
}