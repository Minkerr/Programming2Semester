namespace ExpressionTree;

/// <summary>
/// Implementation of subtraction operation
/// </summary>
public class SubtractionOperation : Node
{
    public SubtractionOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
        => left.Calculate() - right.Calculate();
    

    public override void Print()
    {
        throw new NotImplementedException();
    }
}