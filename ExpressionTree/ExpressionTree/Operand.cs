namespace ExpressionTree;

/// <summary>
/// Type of Node that storage the number
/// </summary>
public class Operand : Node 
{
    public Operand(double value) : base(value)
    {
    }

    public override double Calculate()
        => value;


    public override void Print()
        => Console.Write(value);
}