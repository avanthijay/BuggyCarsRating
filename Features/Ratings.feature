Feature: Ratings
	Ratings and other functionalities 

@ratings
Scenario: User votes and comment
	Given User is registered and logged in
	When User navigates to most popular modal 
	And User adds a comment
	Then User should see the increased vote count 
	And User cannot make more comments