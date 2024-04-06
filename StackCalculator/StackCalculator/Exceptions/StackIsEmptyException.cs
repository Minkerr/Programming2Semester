namespace Calculator.Exceptions;

/// <summary>
/// this exception is thrown when user try to get or pop element from empty IStack
/// </summary>
public class StackIsEmptyException : SystemException
{
    public StackIsEmptyException()
    {
    }

    public StackIsEmptyException(string? message) : base(message)
    {
    }
}