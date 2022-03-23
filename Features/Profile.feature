Feature: Profile
	As a user I want to update my profile details

Scenario Outline: Profile details update
	Given User is logged in as a "validUser2" user
	And User is on Profile Page
	When User updates profile "<key>" as "<value>" and save
	Then User should see the update successfull message
	Examples: 
	| key       | value |
	| firstName | Peter |
	#| lastName  | Pan   |# OutOfScope - This test is intended to test every attribute of UserProfile
	#| Age       | 11    |

@mytag
Scenario: Profile Password update
	Given User is logged in as a "ProfileUpdate" user
	When User update profile details
	And User is logged out
	Then User is logged in with new password
	And User change the password back to original password