﻿using System;
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

            var result = mySocialNetwork.GetTimeline(readerUser, timelineUser);

            result.Should().BeEquivalentTo(firstPost, secondPost);
        }

        [Test]
        public void subscribe_a_registered_user_to_another_user()
        {
            var subscriberUser = GivenRegisterdUser("Charlie");
            var targetUser = GivenRegisterdUser("Bob");
            
            mySocialNetwork.Subscribe(subscriberUser, targetUser);

            Database.Subscriptions[subscriberUser].Should().Contain(targetUser);
        }

        [Test]
        public void return_aggregated_list_of_ordered_messages_for_an_user_subscriptions()
        {
            var subscriberUser = GivenRegisterdUser("Charlie");
            var targetUser1 = GivenRegisterdUser("Bob");
            var targetUser2 = GivenRegisterdUser("Alice");
            mySocialNetwork.Subscribe(subscriberUser, targetUser1);
            mySocialNetwork.Subscribe(subscriberUser, targetUser2);
            var targetUser1FirstPost = GivenRegisteredUserPostsAMessage(targetUser1, "Hi! I'm Bob.");
            var targetUser2FirstPost = GivenRegisteredUserPostsAMessage(targetUser2, "Hi! I'm Alice.");
            var targetUser1SecondPost = GivenRegisteredUserPostsAMessage(targetUser1, "This is Bob's timeline.");

            var result = mySocialNetwork.GetSubscriptionsAggregatedTimeline(subscriberUser);

            result.Should().Equal(targetUser1FirstPost, targetUser2FirstPost, targetUser1SecondPost);
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
