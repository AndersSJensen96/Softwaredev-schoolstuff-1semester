using System;
using Xunit;
using Bunit;
using BlazorDemo.Pages;
using System.Collections.Generic;

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

        [Theory]
        [MemberData(nameof(Data))]
        public void PowerOfMemberData(int number, int number2)
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
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { 1, 2 },
                new object[] { -4, -6},
                new object[] { 5, 2},
                new object[] { 10, 2},
                new object[] { 23425632, 34},
                new object[] { int.MinValue, int.MaxValue }
            };

        [Theory]
        [ClassData(typeof(PowerOfData))]
        public void PowerOfClassData(int number, int number2)
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
