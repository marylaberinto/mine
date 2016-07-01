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
	And The search query should contain the string Emp

Scenario: Basic Search with partial qualifier
	When I enter qualifier ty:
    And I search with the criteria Employee
	Then I should see the search tag Type: Employee
    And The search query should contain the string Employee

Scenario: Basic Search with full qualifier
	When I enter qualifier Status: 
    And I search with the criteria Student
	Then I should see the search tag Status: Student
    And The search query should contain the string Student

#To be tested after DMP-681
#Scenario: Search by selecting from panel
#	When I click on Types panel entry Unknown
#	Then I should see the search tag Type: Unknown
#	And The search query should contain the string Unknown
