﻿Feature: FilterTypes
	In order to view the demographics
	As a CRM user
	I want to be able to see all the filters I can use

@mytag
Scenario: Display all filters
	Given AnalyticsPortalAccess is Feature Toggled On
	And I log into CRM
	When I navigate to the analytics portal
	And I click on the search field
	And I type ':'
	Then I should be able to see all <filters>

	Examples: FilterTypes
	| filters  |
	| Keyword  |
	| Types    |
	| Status   |
	| System   |
	| Campaign |
	| Category |
