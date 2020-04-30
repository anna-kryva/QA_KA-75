Feature: ChangeFontBackgroundColor
	In order to to serf the site in comfort at night
	As a user
	I want to change bright user interface to dark

Scenario: Change UI color
	Given I have been on any page of the website https://www.vmr.gov.ua/
	And I have pressed a UI settings button
	When I press a change UI color button
	Then the website`s UI cullor should be changed
