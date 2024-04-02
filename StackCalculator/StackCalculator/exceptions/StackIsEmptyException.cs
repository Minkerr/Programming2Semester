namespace Calculator.exceptions;

public class StackIsEmptyException : SystemException
{
    public StackIsEmptyException()
    {
    }

    public StackIsEmptyException(string? message) : base(message)
    {
    }
}