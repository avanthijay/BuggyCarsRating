Feature: Registration
	Users are able to register with BuggyCarRating

  @registration  
  Scenario Outline: Register with valid user details
    Given User is on Registration page
    When User enters  "<Username>", First Name "<First Name>", Last Name "<Last Name>", Password "<Password>"
    Then User should be able to see the message "Registration is successful"

    Examples:
      | Username | First Name | Last Name | Password   |
      | Jane    | Jane       | Applesead | Bcrtest@123 |

   
   @registration
  Scenario Outline: Register with existing user details
    Given User is on Registration page
    When User enters existing data for "<Username>", First Name "<First Name>", Last Name "<Last Name>", Password "<Password>"
    Then User should be able to see the message "UsernameExistsException: User already exists"

    Examples:
      | Username | First Name | Last Name | Password   |
      | JaneA    | Jane       | Applesead | Bcrtest@123 |