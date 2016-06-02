Feature: Display Panel
	In order to view the demographics
	As a CRM user
	I want to be able to see all the panels

@mytag
Scenario Outline: Display Panel
	Given AnalyticsPortalAccess is Feature Toggled On
	And I log into CRM 
	When I navigate to the portal
	Then I should be able to see the analytics page 
	And I should be able to see the <panels>

	Examples: Display Panels
	| panels           |
	| Types            |
	| Systems          |
	| Campaigns        |
	| Profile Statuses |
