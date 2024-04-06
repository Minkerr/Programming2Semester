namespace Calculator.Exceptions;

/// <summary>
///  this exception is thrown when StackCalculator get incorrect expression in Polish notation
/// </summary>
public class StackCalculatorIncorrectInputException : SystemException
{
    public StackCalculatorIncorrectInputException()
    {
    }

    public StackCalculatorIncorrectInputException(string? message) : base(message)
    {
    }
}