namespace ExpressionTree;

/// <summary>
/// Universal node of parse tree
/// </summary>
public interface INode
{
    /// <summary>
    /// Calculate the value of sub-tree with root in this node
    /// </summary>
    double Calculate();
    
    /// <summary>
    /// Print sub-tree with root in this node
    /// </summary>
    void Print();
}