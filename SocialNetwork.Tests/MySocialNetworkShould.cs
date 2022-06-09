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
        [Test]
        public void register_a_user()
        {
            User newUser = new User("Bob");
            var mySocialNetwork = new MySocialNetwork();

            mySocialNetwork.AddUser(newUser);

            Database.Users.Should().ContainEquivalentOf(newUser);
        }

        [Test]
        public void save_a_message_posted_by_a_registered_user()
        {
            User givenUser = new User("Alice");
            var mySocialNetwork = new MySocialNetwork();
            mySocialNetwork.AddUser(givenUser);

            var message = "Hi! I'm Alice.";
            mySocialNetwork.Post(givenUser, message);

            Database.Posts[givenUser].Should().Contain(message);
        }

        [Test]
        public void get_the_timeline_of_a_registered_user_for_another_user()
        {
            var mySocialNetwork = new MySocialNetwork();
            var readerUser = new User("Bob");
            mySocialNetwork.AddUser(readerUser);
            var timelineUser = new User("Alice");
            mySocialNetwork.AddUser(timelineUser);
            var firstPost = "Hi! I'm Alice.";
            mySocialNetwork.Post(timelineUser, firstPost);
            var secondPost = "This is my timeline.";
            mySocialNetwork.Post(timelineUser, secondPost);
            var expectedMessages = new[] { firstPost, secondPost };

            var result = mySocialNetwork.GetTimeline(readerUser, timelineUser);
            
            result.Should().BeEquivalentTo(expectedMessages);
        }
    }
}
