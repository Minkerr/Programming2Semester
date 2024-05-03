namespace ExpressionTree;

/// <summary>
/// Implementation of subtraction operation
/// </summary>
public class SubtractionOperation(INode left, INode right) : Operation(left, right)
{    
    protected override char OperationSign => '-';

    public override double Calculate()
        => Left.Calculate() - Right.Calculate();
}