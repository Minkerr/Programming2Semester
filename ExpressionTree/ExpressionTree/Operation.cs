namespace ExpressionTree;

/// <summary>
/// Type of node that contains left and right children with operand or another operation 
/// </summary>
public abstract class Operation : Node
{
    protected string Symbol;
    
    protected Operation(Node left, Node right) : base(left, right)
    {
    }

    public override void Print()
    {
        Console.Write(" ( " + Symbol + " ");
        left.Print();
        right.Print();
        Console.Write(")");
    }
}