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
    }
}
