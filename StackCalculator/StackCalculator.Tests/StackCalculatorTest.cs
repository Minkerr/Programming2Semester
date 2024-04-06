using Calculator.Exceptions;

namespace Calculator.Tests;

public class StackCalculatorTest
{
    private const double DELTA = 0.001;

    private static IEnumerable<TestCaseData> StackCalculators
        => new TestCaseData[]
        {
            new TestCaseData(new StackCalculator(new StackArrayImplementation())),
            new TestCaseData(new StackCalculator(new StackListImplementation())),
        };
    
    [TestCaseSource(nameof(StackCalculators))]
    public void Calculate_shouldReturn2ForSimpleExpression(StackCalculator calculator)
    {
        var actual = calculator.Calculate("2 1 *");
        Assert.That(actual, Is.EqualTo(2));
    }
    
    [TestCaseSource(nameof(StackCalculators))]
    public void Calculate_shouldWorkCorrectWithNotIntegerValues(StackCalculator calculator)
    {
        var actual = calculator.Calculate("2 10 / 1 10 / +");
        Assert.That(actual, Is.EqualTo(0.3).Within(DELTA));
    }
    
    [TestCaseSource(nameof(StackCalculators))]
    public void Calculate_shouldCalculateBigExpressionWithNegativeNumbers(StackCalculator calculator)
    {
        var actual = calculator.Calculate("-21 3 / 3 -10 -10 - * +");
        Assert.That(actual, Is.EqualTo(-7));
    }
    
    [TestCaseSource(nameof(StackCalculators))]
    public void Calculate_shouldThrowExceptionWhenThereIsDivisionByZero(StackCalculator calculator)
        => Assert.Throws<DivideByZeroException>(() => calculator.Calculate("-21 0 /"));
    
    [TestCaseSource(nameof(StackCalculators))]
    public void Calculate_shouldThrowExceptionForIncorrectInput(StackCalculator calculator)
    {
        Assert.Throws<StackCalculatorIncorrectInputException>(() 
            => calculator.Calculate("-21 3 1 /")); // not enough operators
        Assert.Throws<StackCalculatorIncorrectInputException>(() 
            => calculator.Calculate("-21 /")); // not enough numbers
        Assert.Throws<StackCalculatorIncorrectInputException>(() 
            => calculator.Calculate(" -21 3 /")); // extra spaces
        Assert.Throws<StackCalculatorIncorrectInputException>(() 
            => calculator.Calculate("-21.0 3 /")); // real numbers
        Assert.Throws<StackCalculatorIncorrectInputException>(() 
            => calculator.Calculate("a 3 /")); // invalid characters
    }
}