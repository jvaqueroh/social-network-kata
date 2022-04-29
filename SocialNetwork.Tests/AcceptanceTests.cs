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
        public void Alice_can_publish_messages_to_a_personal_timeline()
        {
            // user login
            // user publish a message
            // user publish another message
            // messages are recovered in order by time
            var mySocialNetwork = new MySocialNetwork();
            const string aliceUser = "Alice";
            Message aMessage = new("Hello My Social Network!");
            Message anotherMessage = new("I'm Alice");
            var expectedMessages = new List<Message>()
            {
                new("Hello My Social Network!"),
                new("I'm Alice")
            };

            var aliceSession = mySocialNetwork.Login(aliceUser);
            aliceSession.Publish(aMessage);
            aliceSession.Publish(anotherMessage);
            var timeline = mySocialNetwork.GetTimeline();
            var messages = timeline.GetMessages();

            messages.Should().BeEquivalentTo(expectedMessages);
        }
    }
}