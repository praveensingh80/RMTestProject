Feature: Login
	Check login functionality with different permutation and combination of emailaddress and password

@smoke
Scenario: Check login with correct email address and password
	Given I have navigated to the application
	And I see application opened
	And I click SigIn or SignUp link
	And I enter EmailAddress and Password to login form
	| EmailAddress              | Password  |
	| praveen.singh80@yahoo.com | abc123123 |
	When I click Sign In button
	Then I should see the profile page with emailaddress as label

@smoke
Scenario Outline: Verify validation with incorrect email address and password
	Given I have navigated to the application
	And I see application opened
	And I click SigIn or SignUp link
	And I enter EmailAddress and Password to login form
	| EmailAddress   | Password   |
	| <EmailAddress> | <Password> |
	When I click Sign In button
	Then I should see the Sign In page error as <ErrorMessage>
	Examples: 
	| EmailAddress  | Password  | ErrorMessage                                                                                                                                                                                                                                         |
	| test@test.com | abc123123 | Incorrect username or password. You can use the "Forgot password" link if you do not remember your password or create a new account if you do not already have one. Use the same e-mail address that you used previously if you made an application. |

