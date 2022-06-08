using System;
using System.ComponentModel.DataAnnotations.Schema;
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
    }
}
