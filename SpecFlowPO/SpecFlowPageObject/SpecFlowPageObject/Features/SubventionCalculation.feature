Feature: SubventionCalculation
	In order to understand my situation with subvebtion
	as a citien
	I want to be calculated my subvention 

Scenario Outline: Calculate a subvention
	Given I have been on the webpage https://www.vmr.gov.ua/TransparentCity/Lists/Subsidy/Default.aspx
	And I have entered '<square>' in general flat square row
	And I have entered '<people>' in registered people number row
	And I have entered '<income>' in overall incom per month row
	And I have entered '<tax>' in overall taxes per month row
	When I press count
	Then the subvention should be shown

	Examples: 
		| square | people | income | tax  |
		| 24     | 2      | 20000  | 2500 |
		| 54     | 3      | 26000  | 3200 |
		| 16     | 4      | 5200   | 1700 |
