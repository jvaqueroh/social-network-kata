using System.Collections.Generic;
using NUnit.Framework;
using FluentAssertions;

namespace SocialNetwork.Tests
{
    public class AcceptanceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void loged_in_user_can_publish_messages_to_its_personal_timeline()
        {
            // given a loged-in user
            // and the user published a message
            // and the user published another message
            // when the user loads its timeline
            // then messages are recovered in order by time
            var mySocialNetwork = new MySocialNetwork();
            var userSession = GivenALogedInUserSession(mySocialNetwork, "Alice");
            var aMessage = GivenAMessage("Hello My Social Network!");
            var anotherMessage = GivenAMessage("I'm Alice");
            var expectedMessages = new List<Message>()
            {
                aMessage,
                anotherMessage
            };

            userSession.Publish(aMessage);
            userSession.Publish(anotherMessage);
            
            var timeline = mySocialNetwork.GetTimeline();
            var messages = timeline.GetMessages();

            messages.Should().BeEquivalentTo(expectedMessages);
        }

        private static UserSession GivenALogedInUserSession(MySocialNetwork mySocialNetwork, string user)
        {
            var userSession = mySocialNetwork.Login(user);
            return userSession;
        }

        private static Message GivenAMessage(string message)
        {
            Message aMessage = new(message);
            return aMessage;
        }
    }
}