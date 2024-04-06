namespace ExpressionTree;

/// <summary>
/// Implementation of divide operation
/// </summary>
public class DivideOperation : Operation
{
    private static double DELTA = 0.001;
    protected string Symbol = "/";
    
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
}