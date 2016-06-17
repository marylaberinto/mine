Feature: Authentication
	In order to view the demographics
	As a CRM user
	I want to be able to access the Analytics portal


Scenario: Access Analytics Portal from CRM
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal
	Then I should be able to see the analytics page 
	And I should be able to view Discovery UI