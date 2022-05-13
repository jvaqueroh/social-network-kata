using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace SocialNetwork.Tests
{
    public class UnitTests
    {
        private MessageRepository messageRepository;
        private MySocialNetwork mySocialNetwork;
        private string user;

        [SetUp]
        public void SetUp()
        {
            messageRepository = Substitute.For<MessageRepository>();
            mySocialNetwork = new MySocialNetwork(messageRepository);
            user = "Alice";
        }

        [Test]
        public void get_user_session_when_user_logs_in()
        {
            var result = mySocialNetwork.Login(user);

            result.User.Should().Be(user);
        }

        [Test]
        public void save_a_message_published_by_the_user()
        {
            var userSession = mySocialNetwork.Login(user);
            var message = new Message("Hello! I'm Alice.");

            userSession.Publish(message);

            messageRepository.Received(1).Save(Arg.Is<Message>(m => m.Content.Equals(message.Content)));
        }
    }
}
