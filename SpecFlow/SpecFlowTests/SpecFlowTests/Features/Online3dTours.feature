Feature: Online3dTours
	In order to get information about the city
	As a user
	I want to be sown online 3D-tours

Scenario: Show 3D tours
	Given I have been on the webpage https://transparent.vmr.gov.ua/default.aspx
	When I pressonline 3D-touras button
	Then the list of 3D-tours should be shown
