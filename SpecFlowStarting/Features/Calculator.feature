Feature: Calculator

@mytag
Scenario: Add two numbers
	Given the number is 50
	And the number is 70
	When the two numbers are added
	Then the result should be 120

Scenario: Using tables enter employee details
	#Given I have opened my application
	#Then I should see the Home page
	When I filled all the fields
	| Name    | Age | Phone       | Email              |
	| Subramanyam | 30  | 98878789889 | karthink@gmail.com |
	| Balaji | 27  | 129089788 | balaji@gmail.com |
	| Ganesh | 30  | 7897898898 | ganesh@gmail.com |

	#And I click save button
	#Then all the data should be saved in application or DB


	Scenario Outline: Using tables enter employee details for multiple users
	#Given I have opened my application
	#Then I should see the Home page
	When I filled all the fields <Name>, <Age>, <Phone> and <Email>
	#And I click save button
	#Then all the data should be saved in application or DB

	Examples: 
	| Name    | Age | Phone       | Email              |
	| Karthik | 30  | 98878789889 | karthink@gmail.com |
	| Balaji | 27  | 129089788 | balaji@gmail.com |
	| Ganesh | 30  | 7897898898 | ganesh@gmail.com |




	#Scenerio -4 : ScenerioContext 

	#scenerio -5: Dynamic Tables.No need to create Employee class
	#Install SpecFlow.Assist.Dynamic;