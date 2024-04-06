namespace ExpressionTree;

/// <summary>
/// Implementation of subtraction operation
/// </summary>
public class SubtractionOperation : Operation
{    
    protected string Symbol = "-";

    public SubtractionOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
        => left.Calculate() - right.Calculate();
}