using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace SocialNetwork.Tests
{
    public class UnitTests
    {
        [Test]
        public void get_user_session_when_user_logs_in()
        {
            var user = "Alice";
            var mySocialNetwork = new MySocialNetwork();
            
            var result = mySocialNetwork.Login(user);

            result.User.Should().Be(user);
        }

        [Test]
        public void save_a_message_published_by_the_user()
        {
            var mySocialNetwork = new MySocialNetwork();
            string user = "Alice";
            var userSession = mySocialNetwork.Login(user);
            var messageRepository = Substitute.For<MessageRepository>();
            var message = new Message("Hello! I'm Alice.");

            userSession.Publish(message);

            messageRepository.Received(1).Save(Arg.Is<Message>(m => m.Content.Equals(message.Content)));
        }
    }
}
