using System;
using Xunit;
using Bunit;
using BlazorDemo.Pages;

namespace TestCalculator
{
    public class CalculatorTest : TestContext
    {
        [Theory]
        [InlineData(9)]
        [InlineData(25)]
        [InlineData(16)]
        public void SquareRoote(int number)
        {
            //Arrange
            double ExpectedResult = Math.Sqrt(number);
            var calculatorComponent = RenderComponent<Calculator>();
            var input1 = calculatorComponent.Find("#FirstColumn");
            input1.MarkupMatches("<input id=\"FirstColumn\" placeholder=\"Enter First Number\"/>");
            

            var Sqr = calculatorComponent.Find("#SquareRoot");
            //Sqr.MarkupMatches("<input id=\"FinalResult\" readonly />");

            //Act
            input1.Change(number);
            Sqr.Click();


            //Assert
            var Final = calculatorComponent.Find("#FinalResult");
            //Final.MarkupMatches($"<input id=\"FinalResult\" readonly />{ExpectedResult}");
            Assert.Equal(ExpectedResult, double.Parse(Final.GetAttribute("value")));
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(10, 2)]
        [InlineData(23425632, 34)]
        public void Modulus(int number, int number2)
        {
            //Arrange
            double ExpectedResult = number % number2;


            var calculatorComponent = RenderComponent<Calculator>();
            var input1 = calculatorComponent.Find("#FirstColumn");
            input1.MarkupMatches("<input id=\"FirstColumn\" placeholder=\"Enter First Number\"/>");

            var input2 = calculatorComponent.Find("#SecondColumn");
            input2.MarkupMatches("<input id=\"SecondColumn\" placeholder=\"Enter Second Number\"/>");


            var Mod = calculatorComponent.Find("#ModulusNumber");

            //Act
            input1.Change(number);
            input2.Change(number2);
            Mod.Click();


            //Assert
            var Final = calculatorComponent.Find("#FinalResult");
            //Final.MarkupMatches($"<input id=\"FinalResult\" readonly />{ExpectedResult}");
            Assert.Equal(ExpectedResult, double.Parse(Final.GetAttribute("value")));
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(10, 2)]
        [InlineData(23425632, 34)]
        public void PowerOf(int number, int number2)
        {
            //Arrange
            double ExpectedResult = Math.Pow(number, number2);


            var calculatorComponent = RenderComponent<Calculator>();
            var input1 = calculatorComponent.Find("#FirstColumn");
            input1.MarkupMatches("<input id=\"FirstColumn\" placeholder=\"Enter First Number\"/>");

            var input2 = calculatorComponent.Find("#SecondColumn");
            input2.MarkupMatches("<input id=\"SecondColumn\" placeholder=\"Enter Second Number\"/>");


            var pwr = calculatorComponent.Find("#PowerOf");

            //Act
            input1.Change(number);
            input2.Change(number2);
            pwr.Click();


            //Assert
            var Final = calculatorComponent.Find("#FinalResult");
            //Final.MarkupMatches($"<input id=\"FinalResult\" readonly />{ExpectedResult}");
            Assert.Equal(ExpectedResult, double.Parse(Final.GetAttribute("value")));
        }
    }
}
