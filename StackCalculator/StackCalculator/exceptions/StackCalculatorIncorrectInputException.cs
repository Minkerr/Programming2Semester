namespace Calculator.exceptions;

public class StackCalculatorIncorrectInputException : SystemException
{
    public StackCalculatorIncorrectInputException()
    {
    }

    public StackCalculatorIncorrectInputException(string? message) : base(message)
    {
    }
}