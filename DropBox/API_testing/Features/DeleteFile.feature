Feature: DeleteFile
	

@DeleteFile
Scenario: Delete a file
	Given I have a path to the file to delete
	| Path         |
	| /diagram.png |
	When I send request to delete it
	Then I get info about deleted file
