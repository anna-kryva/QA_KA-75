Feature: ShowServiceQuality
	In order to understand the service quality
	As an interested person
	I want to see a statistical data

Scenario Outline: Show quality of service
	Given I have been on the website https://transparent.vmr.gov.ua/ReportPages/Score.aspx
	And I have chosen as a start data next '<startData>' as a start data
	And I have chosen as an end data next '<endData>'as an end date
	And I have chosen next '<serviceCenter>' as a service center
	When I press view report
	Then the statistics and marks of quality of '<serviceCenter>' should be showen

	Examples: 
		| startData  | endData    | serviceCenter         |
		| 01.01.2020 | 03.03.2020 | Відділення 'Центр'    |
		| 15.02.2020 | 01.04.2020 | Відділення 'Вишенька' |
		| 01.12.2019 | 01.04.2020 | Відділення 'Замостя'  |