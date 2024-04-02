using Calculator.exceptions;

namespace Calculator.Tests;

public class StackCalculatorTest
{
    private const double DELTA = 0.001;
    
    private bool ApproximatelyEqual(double first, double second)
    {
        return first >= second - DELTA && first <= second + DELTA;
    }
    
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new StackArrayImplementation()),
            new TestCaseData(new StackListImplementation()),
        };
    
    [TestCaseSource(nameof(Stacks))]
    public void Calculate_shouldReturn2ForSimpleExpression(Stack stack)
    {
        // arrange
        StackCalculator calculator = new StackCalculator(stack);
        // actual
        var actual = calculator.Calculate("2 1 *");
        // assert
        Assert.That(actual, Is.EqualTo(2));
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Calculate_shouldWorkCorrectWithNotIntegerValues(Stack stack)
    {
        // arrange
        StackCalculator calculator = new StackCalculator(stack);
        // actual
        var actual = calculator.Calculate("2 10 / 1 10 / +");
        // assert
        Assert.That(ApproximatelyEqual(actual, 0.3), Is.True);
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Calculate_shouldCalculateBigExpressionWithNegativeNumbers(Stack stack)
    {
        // arrange
        StackCalculator calculator = new StackCalculator(stack);
        // actual
        var actual = calculator.Calculate("-21 3 / 3 -10 -10 - * +");
        // assert
        Assert.That(actual, Is.EqualTo(-7));
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Calculate_shouldThrowExceptionWhenThereIsDivisionByZero(Stack stack)
    {
        StackCalculator calculator = new StackCalculator(stack);
        Assert.Throws<DivideByZeroException>(() => calculator.Calculate("-21 0 /"));
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Calculate_shouldThrowExceptionForIncorrectInput(Stack stack)
    {
        StackCalculator calculator = new StackCalculator(stack);
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