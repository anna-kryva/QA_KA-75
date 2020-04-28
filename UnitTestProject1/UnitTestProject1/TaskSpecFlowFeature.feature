Feature: SpecFlowFeature1
	Simple tests

@mainscenarios
Scenario: Newsletter e-mail validation
	Given I fill out the newsletter form
	And press the "SIGN UP" button
	But in the "Email address" field "qwerty@%#.com" is written
	Then an error message must occur

Scenario: Contact e-mail validation
	Given I fill out the newsletter form
	And press the "SUBMIT FORM" button
	But in the "Email address" field "qwerty" is written
	Then an error message must occur

Scenario: Contact GDPR Agreement validation
	Given I fill out the newsletter form
	And press the "SUBMIT FORM" button
	But GDPR Agreement checkbox is not selected
	Then an error message must occur


Scenario: Download test
	Given I open the Working Groups page
	And press the "Architectural Concepts" button 
	And press the "White Paper of the Architectural Concepts WG" button
	When I press the "DOWNLOAD WHITE PAPER" button
	Then the pdf file should open

Scenario: Login form test
	Given I fill out the login form
	And press the "Log In" button
	But the password field is empty
	Then an error message must occur

Scenario: Event date search test
	Given I search for Events is Archives: Events page
	And I write "684654.561.65" in "EVENTS FROM" field
	When the key is pressed 
	Then the valid date is returned

Scenario: Individual, Student form Mobile field test
	Given I fill out the Individual, Student form
	And press the "SIGN UP" button
	But the Mobile field is filled with "qwerty" 
	Then an error message must occur

Scenario: Individual, Student form Date of birth field test
	Given I fill out the Individual, Student form
	And press the "SIGN UP" button
	But the Date of birth field is filled with "8989098709" 
	Then an error message must occur