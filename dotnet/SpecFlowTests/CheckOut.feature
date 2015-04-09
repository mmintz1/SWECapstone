Feature: CheckOut
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: The user and the system confirms the order
	Given That there are items in the shopping cart
	When The User confirms the order
	And The User inputs the billing information
	And The System confirms the order
	Then The System updates the inventory
	And The System displays order confirmation
