namespace ExpressionTree;

public class Operand : Node 
{
    public Operand(double value) : base(value)
    {
    }

    public override double Calculate()
    {
        return value;
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
}