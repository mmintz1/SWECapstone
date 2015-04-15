Feature: CheckOut
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: The user and the system confirms the order
	Given That there are items in the shopping cart
	When The User inputs the billing information and confirms the order
	Then The System updates the inventory
	And The System displays order confirmation

	@mytag
Scenario: The user does not confirm the order
	Given That there are items in the shopping cart
	When The User inputs the billing information and clicks cancel
	Then The System does not update the inventory
