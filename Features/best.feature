Feature: FirstTest
	Checking basic functionality,
	testing bugs found

@mainscenarios
Scenario: Going to privacy policy page
	Given I am creating new account
	When Trying to read privacy policy by clicking on it
	Then I am going to the very same page

Scenario: Setting mobile number
	Given I am on personal account settings page
	When Setting new mobile number longer than the standard length
	And Clicking "save"
	Then Site saves this number

Scenario: Setting ICQ number
	Given I am on personal account settings page
	When Setting new ICQ number to zero
	And Clicking "save"
	Then Site saves this value

Scenario: Easily setting new email
	Given I am on personal account settings page
	When Setting new custom email
	And Clicking "save"
	Then Site saves this number

Scenario: Stacktrace when setting email with emojii
	Given I am on personal account settings page
	When Setting new custom email(with 😋 sign)
	And Clicking "save"
	Then Site throws all SQL error output to me

Scenario: Showing newsfeed subscription XML
	Given I am on "welcome" page
	When Clicking on "newsfeed"
	Then It shows me XML to subscribe to RSS

Scenario: No info about past events
	Given I am on "BEST Symposia On Education" page
	When Clicking on "Summer season 2000"
	Then It shows no events

Scenario: Logging out
	Given I am on any "best" page
	When Clicking on "My account" button
	And Clicking "Log out"
	Then It redirects me to index page

