using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace SocialNetwork.Tests
{
    public class MySocialNetworkShould
    {
        private MySocialNetwork mySocialNetwork;

        [SetUp]
        public void SetUp()
        {
            mySocialNetwork = new MySocialNetwork();
        }

        [Test]
        public void register_a_user()
        {
            User newUser = new User("Bob");

            mySocialNetwork.AddUser(newUser);

            Database.Users.Should().ContainEquivalentOf(newUser);
        }

        [Test]
        public void save_a_message_posted_by_a_registered_user()
        {
            User givenUser = GivenRegisterdUser("Alice");

            var message = "Hi! I'm Alice.";
            mySocialNetwork.Post(givenUser, message);

            Database.Posts[givenUser].Should().Contain(message);
        }

        [Test]
        public void get_the_timeline_of_a_registered_user_for_another_user()
        {
            var readerUser = GivenRegisterdUser("Bob");
            var timelineUser = GivenRegisterdUser("Alice");
            var firstPost = GivenRegisteredUserPostsAMessage(timelineUser, "Hi! I'm Alice.");
            var secondPost = GivenRegisteredUserPostsAMessage(timelineUser, "This is my timeline.");
            var expectedMessages = new[] { firstPost, secondPost };

            var result = mySocialNetwork.GetTimeline(readerUser, timelineUser);

            result.Should().BeEquivalentTo(expectedMessages);
        }

        private string GivenRegisteredUserPostsAMessage(User timelineUser, string message)
        {
            mySocialNetwork.Post(timelineUser, message);
            return message;
        }

        private User GivenRegisterdUser(string userName)
        {
            var readerUser = new User(userName);
            mySocialNetwork.AddUser(readerUser);
            return readerUser;
        }
    }
}
