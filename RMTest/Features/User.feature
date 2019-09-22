Feature: User
	Responsible for registering new accounts with combination of different emailaddress and password 

@smoke
Scenario: Register new account with valid email address and password
	Given I have navigated to the application
	And I see application opened
	And I click SigIn or SignUp link
	And I click Register Account link
	And I enter EmailAddress and Password to registration form
	| EmailAddress  | Password  |
	| test@test.com | abc123123 |
	When I click Sign Up button
	Then I should see the complete registration info page

@smoke
Scenario Outline: Check validation on registration using existing email address
	Given I have navigated to the application
	And I see application opened
	And I click SigIn or SignUp link
	And I click Register Account link
	And I enter EmailAddress and Password to registration form
	| EmailAddress   | Password   |
	| <EmailAddress> | <Password> |
	When I click Sign Up button
	Then I should see the Sign Up page error as <ErrorMessage>
	Examples: 
	| EmailAddress              | Password  | ErrorMessage                                                                                                                  |
	| praveen.singh80@yahoo.com | abc123123 | This email address is already registered in our system. If you forgot your password, please click the "Forgot your password?” |
