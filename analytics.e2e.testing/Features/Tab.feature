Feature: Tab
	In order to view the demographics
	As a CRM user
	I want to be able to see all the tabs

Background: 
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal

Scenario Outline: Display Tab
	Then I should be able to see the tabs <tabs>

	Examples: TabTypes
	| tabs                          |             
	| Member Overview, Demographics |

Scenario: Changing Tab
	When I click on Demographics tab
    Then the Demographics tab should be selected

Scenario: Changing tab with query
	When I enter qualifier ty:
    And I search with the criteria Employee
	And I click on Demographics tab
	Then I should see the search tag Type: Employee
    And The search query should contain the string Employee 

Scenario: Creating other queries from other panel not in Demographics
	When I click on Demographics tab
	And I enter qualifier cat:
	And I search with the criteria Profile
	Then I should see the search tag Category: Profile
    And The search query should contain the string Profile
    



