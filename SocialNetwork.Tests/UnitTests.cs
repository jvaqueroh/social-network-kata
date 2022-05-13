using FluentAssertions;
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
    }
}
