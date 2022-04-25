using calculatorlib;
namespace SpecFlowSandbox.StepDefinitions
{
	[Binding]
	public sealed class CalculatorStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
		Calculator cal = new Calculator();
		
		int result = 0;
		

		[Given("the first number is (.*)")]
		public void GivenTheFirstNumberIs(int number)
		{
			cal.FirstNumber = number;
		}

		[Given("the second number is (.*)")]
		public void GivenTheSecondNumberIs(int number)
		{
			cal.SecondNumber = number;
		}

		[When("the two numbers are added")]
		public void WhenTheTwoNumbersAreAdded()
		{
			result = cal.Add();
		}

		[When("the two numbers are subtracted")]
		public void WhenTheTwoNumbersAreSubtracted()
		{
			result = cal.Subtract();
		}

		[Then("the result should be (.*)")]
		public void ThenTheResultShouldBe(int result)
		{
			this.result.Should().Be(result);
		}
	}
}