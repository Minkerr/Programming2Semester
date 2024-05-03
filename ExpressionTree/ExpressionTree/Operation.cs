namespace ExpressionTree;

/// <summary>
/// Type of node that contains left and right children with operand or another operation 
/// </summary>
public abstract class Operation(INode left, INode right) : INode
{
    protected INode Left { get; } = left;
    protected INode Right { get; } = right;
    protected abstract char OperationSign { get; }

    public abstract double Calculate();

    public void Print()
    {
        Console.Write($"( {OperationSign}");
        Left.Print();
        Right.Print();
        Console.Write(")");
    }
}