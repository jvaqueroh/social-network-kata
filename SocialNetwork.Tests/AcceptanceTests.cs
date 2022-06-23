using System.Collections.Generic;
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
            CleanDatabase();
            mySocialNetwork = new MySocialNetwork();
        }

        [Test]
        public void should_allow_Bob_to_read_posts_in_timeline_of_Alice()
        {
            var bob = GivenRegisteredUser("Bob");
            var alice = GivenRegisteredUser("Alice");
            var firstPost = GivenUserPostedAMessage(alice, "Hi, I'm Alice!");
            var secondPost = GivenUserPostedAMessage(alice, "This is my timelime");

            var result = WhenUserGetsOtherUserTimeLine(bob, alice);

            ThenOtherUserPostsAreRetreived(result, firstPost, secondPost);
        }


        [Test]
        public void should_allow_Charlie_to_read_aggregated_list_of_her_subscriptions()
        {
            var bob = GivenRegisteredUser("Bob");
            var alice = GivenRegisteredUser("Alice");
            var charlie = GivenRegisteredUser("Charlie");
            GivenUserSubscribesToAnotherUser(charlie, bob);
            GivenUserSubscribesToAnotherUser(charlie, alice);
            var messageFromBob = GivenUserPostedAMessage(bob, "Hi! I'm Bob.");
            var messageFromAlice = GivenUserPostedAMessage(alice, "Hi! I'm Alice.");

            var result = WhenUserGetsSubscriptions(charlie);

            ThenAggregatedTimelinePostsAreRetreived(result, messageFromBob, messageFromAlice);
        }

        [Test]
        public void should_allow_Bob_to_mention_Charlie()
        {
            var charlie = GivenRegisteredUser("Charlie");
            var bob = GivenRegisteredUser("Bob");
            var messageMentioningCharlie = GivenUserPostedAMessage(bob, "Having fun with @Charlie at the skate park.");

            var result = WhenUserGetsMentions(charlie);

            ThenPostsWithUserMentionsAreRetreived(result, messageMentioningCharlie);
        }

        [Test]
        public void should_allow_Mallory_send_a_private_message_to_Alice()
        {
            var mallory = GivenRegisteredUser("Mallory");
            var alice = GivenRegisteredUser("Alice");
            var privateMessage = GivenAnUserSendPrivateMessageToAnotherUser(mallory, alice, "Hi Alice! I'm Mallory. Nice to meet you.");

            var result = WhenUserGetsPrivateMessages(alice);
            
            ThenPrivateMessagesAreRetreived(result, privateMessage);
        }

        private static void ThenOtherUserPostsAreRetreived(ICollection<string> result, string firstPost, string secondPost)
        {
            result.Should().BeEquivalentTo(new[] { firstPost, secondPost });
        }

        private ICollection<string> WhenUserGetsOtherUserTimeLine(User bob, User alice)
        {
            return mySocialNetwork.GetTimeline(bob, alice);
        }

        private static void ThenAggregatedTimelinePostsAreRetreived(ICollection<string> result, string messageFromBob,
            string messageFromAlice)
        {
            result.Should().BeEquivalentTo(messageFromBob, messageFromAlice);
        }

        private ICollection<string> WhenUserGetsSubscriptions(User charlie)
        {
            return mySocialNetwork.GetSubscriptionsAggregatedTimeline(charlie);
        }

        private void GivenUserSubscribesToAnotherUser(User charlie, User bob)
        {
            mySocialNetwork.Subscribe(charlie, bob);
        }

        private static void ThenPostsWithUserMentionsAreRetreived(ICollection<string> result, string messageMentioningCharlie)
        {
            result.Should().Equal(messageMentioningCharlie);
        }

        private ICollection<string> WhenUserGetsMentions(User charlie)
        {
            var result = mySocialNetwork.GetMentions(charlie);
            return result;
        }

        private static void ThenPrivateMessagesAreRetreived(ICollection<string> result, string privateMessage)
        {
            result.Should().Equal(privateMessage);
        }

        private ICollection<string> WhenUserGetsPrivateMessages(User alice)
        {
            var result = mySocialNetwork.GetPrivateMessages(alice);
            return result;
        }

        private string GivenAnUserSendPrivateMessageToAnotherUser(User senderUser, User receiverUser, string content)
        {
            mySocialNetwork.SendPrivateMessage(senderUser, receiverUser, content);
            return $"[from {senderUser.UserName}] {content}";
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
        
        private static void CleanDatabase()
        {
            Database.Posts.Clear();
            Database.Users.Clear();
            Database.Subscriptions.Clear();
        }
    }
}