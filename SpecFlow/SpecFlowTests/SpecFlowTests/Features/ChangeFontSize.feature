Feature: ChangeFontSize
	In order to avoid uncomfortabe reading
	As an ill-sighted person
	I want to change a font size on the page

Scenario: Add two numbers
	Given I have been on page of the website https://www.vmr.gov.ua/
	And I have pressed UI settings button
	When I press a change font size button
	Then the font size on the page should be changed
