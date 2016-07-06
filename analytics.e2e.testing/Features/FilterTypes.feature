Feature: Filter Types
	In order to view the demographics
	As a CRM user
	I want to be able to see all the filters I can use


Scenario Outline: Display all filters
	Given I log into CRM as an authenticated user
	When I navigate to the analytics portal
	And I type : on the search field
	Then I should be able to see all filters <filters>

	Examples: FilterTypes
	| filters                                           |
	| Keyword, Type, Status, System, Campaign, Category, Joined, Tag, Question|
