namespace ExpressionTree;

/// <summary>
/// Type of node that contains left and right children with operand or another operation 
/// </summary>
public abstract class Operation : Node
{
    protected Operation(Node left, Node right) : base(left, right)
    {
    }
}