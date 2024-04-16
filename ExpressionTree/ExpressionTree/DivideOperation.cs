namespace ExpressionTree;

/// <summary>
/// Implementation of divide operation
/// </summary>
public class DivideOperation(INode left, INode right) : Operation(left, right)
{
    private static double DELTA = 0.001;
    protected override char OperationSign => '-';

    public override double Calculate()
    {
        double rightResult = Right.Calculate();
        if (rightResult >= -DELTA && rightResult <= DELTA)
        {
            throw new DivideByZeroException();
        }
        return Left.Calculate() / rightResult;
    }
}