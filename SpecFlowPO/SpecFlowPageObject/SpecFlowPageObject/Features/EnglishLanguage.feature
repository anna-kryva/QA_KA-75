Feature: EnglishLanguage
	In order to read information on the webpage
	As a person that does`n know Ukrainian
	I want to get an english version of the webpage

Scenario: Translate on English
	Given I have been on the website https://www.vmr.gov.ua/
	When I have pressed an english translation button
	Then the truslated webpage should be shown
