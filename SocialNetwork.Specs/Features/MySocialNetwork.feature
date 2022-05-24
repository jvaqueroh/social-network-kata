Feature: MySocialNetwork
![MySocialNetwork](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
SocialNetwork kata BDD way

Link to a feature: [MySocialNetwork](SocialNetwork.Specs/Features/MySocialNetwork.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Registered user can view another user's timeline
	Given registered users Alice, Bob
	And user Alice posts the message "Hi, I'm Alice"
	When user Bob gets the timeline of user Alice
	Then timeline of user Alice contains "Hi, I'm Alice"

@mytag
Scenario: Subcribed user can view an aggregated list of post of user he is following
	Given registered users Alice, Bob, Charlie
	And user Alice posts the message "Hi, I'm Alice"
	And user Bob posts the message "Here Bob, whatsaaaaaaap!"
	And user Charlie follows users Alice, Bob
	When user Charlie gets the subscriptions
	Then subscriptions list of user Charlie contains "Hi, I'm Alice"
	And subscriptions list of user Charlie contains "Here Bob, whatsaaaaaaap!"