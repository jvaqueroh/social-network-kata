using System.Reflection.Metadata;
using FluentAssertions;
using NUnit.Framework;

namespace SocialNetwork.Tests
{
    public class AcceptanceTests
    {
        private MySocialNetwork mySocialNetwork;

        [SetUp]
        public void Setup()
        {
            mySocialNetwork = new MySocialNetwork();
        }

        [Test]
        public void should_allow_Bob_to_read_posts_in_timeline_of_Alice()
        {
            var bob = GivenRegisteredUser("Bob");
            var alice = GivenRegisteredUser("Alice");
            var firstPost = GivenUserPostedAMessage(alice, "Hi, I'm Alice!");
            var secondPost = GivenUserPostedAMessage(alice, "This is my timelime");

            var result = mySocialNetwork.GetTimeline(bob, alice);

            result.Should().BeEquivalentTo(new[] { firstPost, secondPost});
        }

        [Test]
        public void should_allow_Charlie_to_read_aggregated_list_of_her_subscriptions()
        {
            var bob = GivenRegisteredUser("Bob");
            var alice = GivenRegisteredUser("Alice");
            var charlie = GivenRegisteredUser("Charlie");
            mySocialNetwork.Subscribe(charlie, bob);
            mySocialNetwork.Subscribe(charlie, alice);
            var messageFromBob = GivenUserPostedAMessage(bob, "Hi! I'm Bob.");
            var messageFromAlice = GivenUserPostedAMessage(alice, "Hi! I'm Alice.");

            var result = mySocialNetwork.GetSubscriptionsAggregatedTimeline(charlie);

            result.Should().BeEquivalentTo(messageFromBob, messageFromAlice);
        }

        [Test]
        public void should_allow_Bob_to_mention_Charlie()
        {
            var charlie = GivenRegisteredUser("Charlie");
            var bob = GivenRegisteredUser("Bob");
            var messageMentioningCharlie = GivenUserPostedAMessage(bob, "Having fun with @Charlie at the skate park.");

            var result = mySocialNetwork.GetMentions(charlie);

            result.Should().Equal(messageMentioningCharlie);
        }

        private string GivenUserPostedAMessage(User user, string message)
        {
            mySocialNetwork.Post(user, message);
            return message;
        }

        private User GivenRegisteredUser(string userName)
        {
            var aUser = new User(userName);
            mySocialNetwork.AddUser(aUser);
            return aUser;
        }
    }
}