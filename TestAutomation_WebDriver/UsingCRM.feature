Feature: UsingCRMHubSpot
		As a user
		I want to be able to use CRM at full power 
		like create contact, deal, chatflow, ticket
		

@Contacts
Scenario: Navigation to all contacts
	Given I am on reports dashboard
	When I navigate to /contacts/list/view/all/
	Then I should be on the contacts page

##Scenario: Veiwing existing contacts
##		Given I am on the contacts page 
##		Then  I should see a list of contacts
##				And contacts have name
##				And contacts have email
##				And contacts have associated company

Scenario Outline: Check and Add important existing contacts
		Given I am on the contacts page 
		And I see a list of contacts
				| Name           | Email                 | Associated company |
				| Brian Halligan | bh@hubspot.com        | HubSpot, Inc.      |
		When I add contact with params
				| Name       | Email                 | Associated company |
				| Cool Robot | coolrobot@hubspot.com | HubSpot, Inc.      |
		Then I should see new list of contacts
				| Name           | Email                 | Associated company |
				| Cool Robot     | coolrobot@hubspot.com | HubSpot, Inc.      |
				| Brian Halligan | bh@hubspot.com        | HubSpot, Inc.      |
			
Scenario Outline: Delete contacts
		Given I am on the contacts page 
		And I see a list of contacts
				| Name           | Email                 | Associated company |
				| Cool Robot     | coolrobot@hubspot.com | HubSpot, Inc.      |
				| Brian Halligan | bh@hubspot.com        | HubSpot, Inc.      |
		When I delete contact with params
				| Name       | Email                 | Associated company |
				| Cool Robot | coolrobot@hubspot.com | HubSpot, Inc.      |
		Then I should see new list of contacts
				| Name           | Email                 | Associated company |
				| Brian Halligan | bh@hubspot.com        | HubSpot, Inc.      |

Scenario: Filter contacts
		Given I am on the contacts page
		When I sort contacts list by Last activity date 
			And choose last 365 days
		Then I should see contact Cool Robot
		
@Chatflows
Scenario: Navigation to Chatflows
		Given I am on reports dashboard
		When I press Conversations 
			And choose Chatflows in droplist
		Then I should see a Chatflows page

Scenario Outline: Create Chatflow for website
		Given I am on the Chatflows page
		When I press Create Chatflow 
			And choose chatflow for website
			And choose a live chat 
			And Press next
			And input a welcome message 
				| Welcome message                       |
				| Got any Questions? I`m happy to help! |  
			And press toggle switch in up right corner
		Then I should see a Last step with button Get tracking code

@Deal
Scenario: Navigation to Sales
		Given I am on reports dashboard
		When I press Sales
			And choose Deals in droplist 
		Then I should see a Deals page

Scenario Outline: Create Deal
		Given I am on Deals page
		When I press button Create deal with params
			| Deal name           | Deal type         | Company      | Contact    |
			| Investitors meeting | Existing buisness | Hubspot, Inc | Cool Robot |
			And press Create
		Then I should see a new Deal 

@Ticket
Scenario: Navigation to tickets
		Given I am on a reports dashbord 
		When I press Service
			And choose Tickets in droplist
		Then I should see the Tickets page

Scenario Outline: Create ticket
		Given I am on the Tickets page
		When I press Create ticket 
			And enter following params
			| Ticket name            | Source | Company      | Contact        |
			| Create automation test | Email  | Hubspot, Inc | Brian Halligan |
		Then I should see new Ticket in Activities

@Tasks
Scenario: Navigation to Tasks
		Given I am on the reports dashbord 
		When I press Service
			And choose Tasks in droplist
		Then I should see the Tasks

Scenario: Create task
	Given I am on the Tasks
	When I press th Create task
		And enter following data
		| Task title       | Type | Priority | Notes                                 |
		| Call to our clients | Call | High     | Call to schools, hospitals and police |
		And press Create 
	Then I should to see new Task