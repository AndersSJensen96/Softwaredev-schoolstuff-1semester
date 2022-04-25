Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowSandbox/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**


Background: 
	||Use if features scenarios have repeating given statements
	||Can't be used with examaples sadly

@Add
Scenario: Add two numbers
	Given the first number is <First>
	And the second number is <Second>
	When the two numbers are added
	Then the result should be <Result>
	
Examples: 
| First | Second | Result |
| 50    | 70     | 120    |
| 50    | 50     | 100    |
| 100   | 70     | 170    |



