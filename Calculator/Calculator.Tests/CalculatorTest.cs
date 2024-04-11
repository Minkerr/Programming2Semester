namespace Calculator.Tests;

public class CalculatorTest
{
    private const double Delta = 0.001;
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AssignDigit_shouldAssignDigitToDisplayedNumber()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        // assert
        Assert.That(calculator.Display, Is.EqualTo("1"));
    }
    
    [Test]
    public void AssignDigit_shouldAssignDigitToDisplayedNumberManyTimes()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDigit('3');
        // assert
        Assert.That(calculator.Display, Is.EqualTo("123"));
    }
    
    [Test]
    public void AssignDot_shouldAssignDotToZero()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDot();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("0,"));
    }
    
    [Test]
    public void AssignDot_shouldAssignDotToNonZeroNumber()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDigit('3');
        calculator.AssignDot();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("123,"));
    }
    
    [Test]
    public void AssignDigit_shouldAssignDigitAfterDot()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDot();
        calculator.AssignDigit('3');
        // assert
        Assert.That(calculator.Display, Is.EqualTo("12,3"));
    }
    
    [Test]
    public void AssignDot_shouldNotAssignDotTwice()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDot();
        calculator.AssignDigit('3');
        calculator.AssignDot();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("12,3"));
    }
    
    [Test]
    public void SetOperation_shouldSetCalculateNumberIfItIsNotTheFirstOperation()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.SetOperation('+');
        calculator.AssignDigit('2');
        calculator.SetOperation('+');
        // assert
        Assert.That(calculator.Display, Is.EqualTo("3"));
    }
    
    [Test]
    public void ClearCalculator_shouldSetDefaultValues()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDot();
        calculator.AssignDigit('3');
        calculator.SetOperation('-');
        calculator.ClearCalculator();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("0"));
    }

    [Test] 
    public void Calculate_shouldCalculateValueInCalculator()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.SetOperation('×');
        calculator.AssignDigit('3');
        calculator.Calculate();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("36"));
    }
    
    [Test] 
    public void AssignDot_shouldNotAddDotTwiceAfterCalculation()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.AssignDot();
        calculator.AssignDigit('5');
        calculator.SetOperation('×');
        calculator.AssignDigit('3');
        calculator.Calculate();
        calculator.AssignDot();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("37,5").Within(Delta));
    }
    
    [Test] 
    public void AssignDot_shouldAddDotAfterCalculationIfThereIsNoDot()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.SetOperation('×');
        calculator.AssignDigit('3');
        calculator.Calculate();
        calculator.AssignDot();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("36,").Within(Delta));
    }
    
    [Test] 
    public void AssignDot_shouldAddDotAfterSetNewOperation()
    {
        // arrange
        Calculator calculator = new Calculator();
        // act
        calculator.AssignDigit('1');
        calculator.AssignDigit('2');
        calculator.SetOperation('×');
        calculator.AssignDigit('3');
        calculator.SetOperation('+');
        calculator.AssignDot();
        calculator.AssignDigit('2');
        calculator.Calculate();
        // assert
        Assert.That(calculator.Display, Is.EqualTo("36,2").Within(Delta));
    }
}