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
Feature: FilterMembership
	In order to select a membership
	As a customer
	I want to filter features and see appropriate memberships

@membership
Scenario: Filter features
	Given I am on the shop page
	And I see the sidebar with filter and features
	When I choose Dnipro city
	And I choose Priozernyi
	Then the result should be 3 memberships with titles:
	"""
	CLASSIC ПОВНОГО ДНЯ
	CLASSIC + БАСЕЙН ПОВНОГО ДНЯ
	PREMIUM ПОВНОГО ДНЯ
	"""

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
Feature: RedirectToTv
	In order to see the timetable of workouts
	As a client
	I shoud be redirected to the page with online workouts timetable

@mytag
Scenario: Online workout timetable
	Given I have hovered the navbar tab "Сервіси для клієнтів"
	And I see a dropdown list
	When I press "Розклад занять"
	Then I shoud be redirected to tv.sportlife.ua page with the online workouts timetable

#8
Feature: SpaSidebar
	In order to learn about spa
	As a customer
	I want to see detailed information about massage salon

@spa
Scenario: Massage Salon
	Given I on the spa page
	And there is a sidebar on the right
	When I click on "Масажний салон"
	Then the result is a massage salon page