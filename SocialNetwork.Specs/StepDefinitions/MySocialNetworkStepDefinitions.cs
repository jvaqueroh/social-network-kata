namespace SocialNetwork.Specs.StepDefinitions
{
    [Binding]
    public sealed class MySocialNetworkStepDefinitions
    {
        private readonly MySocialNetwork mySocialNetwork;
        private ICollection<string> subscriptionsMessages;

        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        public MySocialNetworkStepDefinitions(MySocialNetwork mySocialNetwork)
        {
            this.mySocialNetwork = mySocialNetwork;
        }

        [Given("user (.*) posts the message (.*)")]
        public void GivenUserPostsAMessage(string user, string message)
        {
            mySocialNetwork.AddUser(user);
            mySocialNetwork.CreatePost(user, message);
        }

        [Given("user (.*) follows users (.*)")]
        public void GivenUserFollowsOtherUsers(string user, string followedUsers)
        {
            foreach (var userToFollow in followedUsers.Split(","))
            {
                mySocialNetwork.Follow(user, userToFollow);
            }
        }

        [When("user (.*) gets the subscriptions")]
        public void WhenUserGetsTheSubscriptions(string user)
        {
            subscriptionsMessages = mySocialNetwork.GetSubscriptionsMessages(user);
        }

        [Then("subscriptions list of user (.*) contains (.*)")]
        public void ThenUserSubscriptionsContains(string user, string message)
        {
            subscriptionsMessages.Should().Contain(message);
        }
    }
}