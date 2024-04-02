namespace Calculator.exceptions;

public class StackIsFullException : SystemException
{
    public StackIsFullException()
    {
    }

    public StackIsFullException(string? message) : base(message)
    {
    }
}