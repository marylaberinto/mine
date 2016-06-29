Feature: Search
	In order to view the demographics
	As a CRM user
	I want to be able to search using the filters

Background: 
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal

Scenario: Single Basic Search
	When I search with the criteria Emp
	Then I should see the search tag Keyword: Emp
	And I should see the query containing Emp
