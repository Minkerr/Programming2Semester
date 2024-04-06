namespace ExpressionTree;

/// <summary>
/// Implementation of multiply operation
/// </summary>
public class MultiplyOperation : Node
{
    public MultiplyOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
        => left.Calculate() * right.Calculate();
    

    public override void Print()
    {
        throw new NotImplementedException();
    }
}