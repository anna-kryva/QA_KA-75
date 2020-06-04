Feature: toMainPage
	In order to go to main page
	As a website visitor
	I want to be redirected to main page

Scenario: Any olx page
	When I press logo
	Im getting redirected to main page


Feature: searchQuery
	In order to a search query
	As a website visitor
	I want to be redirected to search query results page

Scenario: main olx page
	When I enter search query in search field
	And press search button
	Im getting redirected to search query results page

Feature: goLogin
	In order to go to put an advertisment
	As a unlogined website visitor
	I want to be redirected to login page

Scenario: Any olx page
	When I press new advertisment
	Im getting redirected to login page
