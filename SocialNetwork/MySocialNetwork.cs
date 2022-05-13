namespace SocialNetwork
{
    public class MySocialNetwork
    {
        private readonly MessageRepository messageRepository;

        public MySocialNetwork(MessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
        }

        public UserSession Login(string user)
        {
            return new UserSession(user, messageRepository);
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
        private readonly MessageRepository messageRepository;
        public string User { get; private set; }

        public UserSession(string user, MessageRepository messageRepository)
        {
            this.messageRepository = messageRepository;
            User = user;
        }

        public void Publish(Message aMessage)
        {
            messageRepository.Save(aMessage);
        }

    }

    public class Message
    {
        public string Content { get; private set; }

        public Message(string message)
        {
            Content = message;
        }
    }
    
    public interface MessageRepository
    {
        void Save(Message message);
    }

    public class MessageRepositoryInMemory:MessageRepository
    {
        public void Save(Message message)
        {
            throw new NotImplementedException();
        }
    }
}