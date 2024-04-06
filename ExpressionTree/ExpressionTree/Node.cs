namespace ExpressionTree;

/// <summary>
/// Universal node of parse tree
/// </summary>
public abstract class Node
{
    protected double value;
    protected Node left;
    protected Node right;

    protected Node(Node left, Node right)
    {
        this.left = left;
        this.right = right;
    }

    protected Node(double value) 
        => this.value = value;
    
    /// <summary>
    /// Calculate the value of sub-tree with root in this node
    /// </summary>
    public abstract double Calculate();
    
    /// <summary>
    /// Print sub-tree with root in this node
    /// </summary>
    public abstract void Print();
}