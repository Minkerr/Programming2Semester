namespace ExpressionTree;

/// <summary>
/// Implementation of multiply operation
/// </summary>
public class MultiplyOperation(INode left, INode right) : Operation(left, right)
{
    protected override char OperationSign => '*';
    
    public override double Calculate()
        => Left.Calculate() * Right.Calculate();
}