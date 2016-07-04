Feature: AutoSuggest
	In order to view the demographics
	As a CRM user
	I want to be able to see all autosuggest I can use

Background: 
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal

Scenario: Display autosuggest popup
	When I enter qualifier Campaign: 
	And I search with the criteria Cp
	Then I should be able to see the autosuggest popup


