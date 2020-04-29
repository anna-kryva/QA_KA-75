#sportlife.ua

#1
Feature: ToMainPage
	In order to go to main page
	As a visitor
	I want to click on te logo and go over to the main page

@mainpage
Scenario: Click on the Logo
	Given I on the page with clubs
	When I press the logo
	Then the result should be the main page

#2
Feature: ChooseClubFromList
	In order to choose the club
	As a customer
	I want to be able to see the detailed information about the club

@navbar
Scenario: Choose club
	Given I am on the main page
	When I hover the mouse cursor over
	And click on a name of the club in the dropdown list
	Then I see detailed information on a new page

#3
Feature: FacebookLink
	In order to see the facebook page
	As a visitor
	I want to be redirected from Sportlife to Facebook

@facebook
Scenario: Redirect to Facebook
	Given I am on a main sprotlife page
	And there is a facebook icon at the bottom of the page
	When I click on the icon
	Then I should be redirected to the facebook page

#4
Feature: SelectClubTriners
	In order to select a coach
	As a customer
	I want to choose a club from menu

@membership
Scenario: Select club
	Given I am on the trainers page
	When I choose club Priozernyi
	Then I should see the coach list

#5
Feature: LookingForStaff
	In order to apply for a job
	As an applicant
	I want to see the list of vacancies

@vacancy
Scenario: List of Vacancies
	Given I on the looking for staff page
	And I see the list of clubs in Kyiv
	When I click on Gatne
	Then the result should be the list of vacancies with titles: 
	"""
	Адміністрація
	Фітнес
	"""

#6
Feature: PoolPageLink
	In order to choose the club with a pool
	As a customer
	I want to see the list of clubs

@pool
Scenario: Click on the Link
	Given I am on a pool page
	And there is a link at the end of the page - "Плавай" 
	When I click on the link
	Then the result should be list of cities with clubs

#7
Feature: EmptyTable
	In order to see the lis of trainers
	As a client
	I shoud be able to choose workout category

@mytag
Scenario: Empty Bathhouse Worker List 
	Given I on the trainers page with the selected club Pryozernyi
	When I click on the Bathhouse worker tab
	Then I shoud see empty list

#8
Feature: SubmitForm
	In order to buy a gym membership
	As a customer
	I want to fill the form and submit

@spa
Scenario: Massage Salon
	Given I am on the shop page
	When I fill the form
	And submit it
	Then the result is a liqpay page