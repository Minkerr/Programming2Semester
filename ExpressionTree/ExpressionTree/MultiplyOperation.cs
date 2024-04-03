namespace ExpressionTree;

public class MultiplyOperation : Node
{
    public MultiplyOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
    {
        return left.Calculate() * right.Calculate();
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
}