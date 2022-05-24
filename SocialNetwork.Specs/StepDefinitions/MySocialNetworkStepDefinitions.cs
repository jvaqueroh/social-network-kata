namespace SocialNetwork.Specs.StepDefinitions
{
    [Binding]
    public sealed class MySocialNetworkStepDefinitions
    {
        private readonly MySocialNetwork mySocialNetwork;
        private ICollection<string> subscriptionsMessages;
        private ICollection<string> anotherUserTimeline;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public MySocialNetworkStepDefinitions(MySocialNetwork mySocialNetwork)
        {
            this.mySocialNetwork = mySocialNetwork;
        }

        [Given("registered users (.*)")]
        public void GivenRegisteredUsers(string users)
        {
            users.Split(",").ToList()
                .ForEach(u => mySocialNetwork.AddUser(u.Trim()));
        }

        [Given("user (.*) posts the message (.*)")]
        public void GivenUserPostsAMessage(string user, string message)
        {
            mySocialNetwork.CreatePost(user, message);
        }

        [Given("user (.*) follows users (.*)")]
        public void GivenUserFollowsOtherUsers(string user, string followedUsers)
        {
            foreach (var userToFollow in followedUsers.Split(","))
            {
                mySocialNetwork.Follow(user, userToFollow.Trim());
            }
        }

        [When("user (.*) gets the timeline of user (.*)")]
        public void WhenUserGetsTheTimelineOfAnotherUser(string user, string anotherUser)
        {
            anotherUserTimeline = mySocialNetwork.GetTimeline(user, anotherUser);
        }

        [When("user (.*) gets the subscriptions")]
        public void WhenUserGetsTheSubscriptions(string user)
        {
            subscriptionsMessages = mySocialNetwork.GetSubscriptionsMessages(user);
        }

        [Then("timeline of user (.*) contains (.*)")]
        public void ThenTimelineOfAnotherUserContains(string anotherUser, string message)
        {
            anotherUserTimeline.Should().Contain(message);
        }

        [Then("subscriptions list of user (.*) contains (.*)")]
        public void ThenUserSubscriptionsContains(string user, string message)
        {
            subscriptionsMessages.Should().Contain(message);
        }
    }
}