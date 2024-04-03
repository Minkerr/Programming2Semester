namespace ExpressionTree;

public class AddOperation : Operation
{
    public AddOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
    {
        return left.Calculate() + right.Calculate();
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
}