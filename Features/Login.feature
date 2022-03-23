Feature: Login
	Login feature tests

@login
Scenario: User login with valid credentials
	Given User is on Login page
	When User enter credentials for a "validUser" 
	Then User should be logged in

@login
Scenario: User login with invalid credentials
	Given User is on Login page
	When User enter credentials for a "InvalidUser" 
	Then User should see the "Invalid username/password" message
	
Scenario: User logout
	Given User is on Login page
	And User is logged in as "validUser"
	When User clicks the logut link
	Then User shluld be logged out
