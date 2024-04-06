namespace Calculator.Exceptions;

public class StackIsEmptyException : SystemException
{
    public StackIsEmptyException()
    {
    }

    public StackIsEmptyException(string? message) : base(message)
    {
    }
}