namespace ExpressionTree;

/// <summary>
/// Implementation of multiply operation
/// </summary>
public class MultiplyOperation : Operation
{
    protected string Symbol = "*";
    
    public MultiplyOperation(Node left, Node right) : base(left, right)
    {
    }

    public override double Calculate()
        => left.Calculate() * right.Calculate();
    
    public override void Print()
    {
        Console.Write("( " + Symbol + " ");
        left.Print();
        right.Print();
        Console.Write(")");
    }
}