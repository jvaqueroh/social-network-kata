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

        private string GivenUserPostedAMessage(User alice, string message)
        {
            var aPost = message;
            mySocialNetwork.Post(alice, aPost);
            return aPost;
        }

        private User GivenRegisteredUser(string userName)
        {
            var aUser = new User(userName);
            mySocialNetwork.AddUser(aUser);
            return aUser;
        }
    }
}