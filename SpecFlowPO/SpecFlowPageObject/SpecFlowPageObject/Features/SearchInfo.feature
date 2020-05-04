Feature: SearchInfo
	In order to get information about things I am interested in
	As a user
	I want to find concrete information 

Scenario Outline: Find an information
	Given I have been on the website https://www.vmr.gov.ua/default.aspx
	And I have entered '<interest>' in the search raw 
	When I press find
	Then The pagege with a list of related to the '<interest>' links should be shown

	Examples: 
		| interest |
		| Covid-19 |
		| Roshen   |