﻿@PersistExistingFeatureToggle

Feature: Authentication
	In order to view the demographics
	As a CRM user
	I want to be able to access the Analytics portal

@mytag
Scenario: Access Discovery UI
	Given AnalyticsPortalAccess is Feature Toggled On
	And I log into CRM with approved permission
	When I navigate to the portal
	Then I should be able to see the analytics page 
	And I should be able to see the search bar

Scenario: No access to Discovery UI
	Given I log into CRM with no approved permission
	When I navigate to the portal
	Then I should not be able to see the analytics page 