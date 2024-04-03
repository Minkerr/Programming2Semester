namespace ExpressionTree;

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
    {
        this.value = value;
    }

    public abstract double Calculate();
    
    public abstract void Print();
}