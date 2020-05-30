Feature: GetMetadata
	

@GetMetaData
Scenario: Get file metadata
	Given I have a path to file 
	| Path         |
	| /diagram.png |
	When I send request to get its metadata
	Then I should be able to get file metadata 
