namespace ExpressionTree;

public abstract class Operation : Node
{
    protected Operation(Node left, Node right) : base(left, right)
    {
    }
}