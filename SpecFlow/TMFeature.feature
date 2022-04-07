Feature: TMFeature

As a TurnUp portal admin
I would like to Create, Edit and Delete Time and Material Records
To Manage employee's time and material successfully


Scenario: Create time and material record with valid data
	Given Logged into Turnup portal successfully
	And I navigate to time and material page
	When I created Time and Material record
	Then Time and material record created successfully

Scenario Outline: edit time and material record with valid data
	Given logged into turnup portal successfully
	And i navigate to time and material page
	When i update '<description>' '<code>' '<price>' on an existing time and material record
	Then time and material should have updated '<description>' '<code>' '<price>'

	Examples: 
	| description | code     | price |
	| parrot      | keyboard | 10    |
	| pigeon      | mouse    | 20    |
	| ostrich     | pen      | 30    |

