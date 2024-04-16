namespace ExpressionTree;

/// <summary>
/// Type of Node that storage the number
/// </summary>
public class Operand(double value) : INode
{
    public double Calculate()
        => value;
    
    public void Print()
        => Console.Write(value + " ");
}