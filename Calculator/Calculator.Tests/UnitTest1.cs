namespace Calculator.Tests;

public class CalculatorTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigitToDisplayedNumber('1');
        // assert
        Assert.That(calculator.Display, Is.EqualTo("1"));
    }
}