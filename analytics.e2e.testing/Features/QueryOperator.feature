Feature: QueryOperator
	In order to view the demographics
	As a CRM user
	I want to be able to use a filter with logical operators

Background: 
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal

Scenario: Display AND
	When I search with the criteria test1
	And I search with the criteria test2
	Then I should see a query operator and

Scenario: Display OR
	When I search with the criteria test1
	And I search with the criteria test2
	And I click the and operator
	Then I should see a query operator or

Scenario: Display THEN
	When I search with the criteria test1
	And I search with the criteria test2
	And I click the and operator
	And I click the or operator
	Then I should see a query operator then

