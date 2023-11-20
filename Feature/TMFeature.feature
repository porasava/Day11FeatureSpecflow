Feature: TMFeature

A short sumAs a TurnUp portal user
I would like to create, edit and delete time and material records
So that I can manage employees time and material successfully


	Scenario: 01 Create time record with valid details
	Given I loged into TurnUp portal successfully
	When I navigate to time and material page
	Then I create a new time record
	Then the time record should be created successfully

	Scenario: 02 Edit time record with valid details
	Given I loged into TurnUp portal successfully
	When I navigate to time and material page
	Then I edit a time record
	Then the time record should be edited successfully

	Scenario: 03 Delete time record with valid details
	Given I loged into TurnUp portal successfully
	When I navigate to time and material page
	Then I delete a time record
	Then the time record should be deleted successfully


