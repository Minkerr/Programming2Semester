namespace ExpressionTree;

/// <summary>
/// Implementation of subtraction operation
/// </summary>
public class AddOperation : Operation
{
    protected string Symbol = "+";
    
    public AddOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
        => left.Calculate() + right.Calculate();
}