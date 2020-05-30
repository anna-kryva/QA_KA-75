Feature: UploadFile



@Upload
Scenario: Upload a file
	Given I have 'diagram.png' file to upload
	When I upload the file
	| Path         | Mode | AutoRename | Mute  |
	| /diagram.png | add  | true       | false |
	Then I should be able to get file info
	| Name        |
	| diagram.png |