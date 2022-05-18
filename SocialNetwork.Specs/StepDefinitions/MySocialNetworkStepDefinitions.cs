namespace SocialNetwork.Specs.StepDefinitions
{
    [Binding]
    public sealed class MySocialNetworkStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        [Given("user (.*) posts the message (.*)")]
        public void GivenUserPostsAMessage(string user, string message)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            throw new PendingStepException();
        }

        [Given("user (.*) follows users (.*)")]
        public void GivenUserFollowsOtherUsers(string user, string followedUsers)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("user (.*) gets the subscriptions")]
        public void WhenUserGetsTheSubscriptions(string user)
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("subscriptions list of user (.*) contains (.*)")]
        public void ThenUserSubscriptionsContains(string user, string message)
        {
            //TODO: implement assert (verification) logic

            throw new PendingStepException();
        }
    }
}