@PersistExistingFeatureToggle

Feature: Authentication
	In order to view the demographics
	As a CRM user
	I want to be able to access the Analytics portal


Scenario: Access Discovery UI
	Given AnalyticsPortalAccess is Feature Toggled On
	And I log into CRM
	When I navigate to the analytics portal
	Then I should be able to see the analytics page 
	And I should be able to view Discovery UI

Scenario: No access to Discovery UI
	Given AnalyticsPortalAccess is Feature Toggled Off
	And I log into CRM
	Then I should not be able to navigate to the analytics portal

#To be implemented after feature toggle exceptions are set up
#Scenario: No access to Discovery UI
#	Given AnalyticsPortalAccess is Feature Toggled Off
#	And I log into CRM
#	When I navigate to the portal
#	Then I should not be able to see the analytics page