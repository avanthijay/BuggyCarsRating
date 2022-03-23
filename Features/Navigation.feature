Feature: Navigation
	

@mytag
Scenario Outline: User navigates back to Home Page
	Given User is on Login page
	And User navigates to "<newPage>"
	When User clicks on Home link
	Then User should be back to Home Page
	Examples: 
	| newPage |
	| make    |
	| model   |
	| overall |