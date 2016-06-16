Feature: Display Panel
	In order to view the demographics
	As a CRM user
	I want to be able to see all the panels

Scenario Outline: Display Panels
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal 
	Then I should be able to see the panels <panels>

	Examples: Display Panels
	| panels                                      |
	| Member Category, Types, Systems, Campaigns, Profile Statuses, Joined Date |