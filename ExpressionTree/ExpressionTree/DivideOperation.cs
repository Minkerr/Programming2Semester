namespace ExpressionTree;

/// <summary>
/// Implementation of divide operation
/// </summary>
public class DivideOperation : Node
{
    private static double DELTA = 0.001;
    
    public DivideOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
    {
        double rightResult = right.Calculate();
        if (rightResult >= -DELTA && rightResult <= DELTA)
        {
            throw new DivideByZeroException();
        }
        return left.Calculate() / rightResult;
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
}