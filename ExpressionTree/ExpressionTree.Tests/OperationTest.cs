namespace ExpressionTree.Tests;

public class Tests
{
    private static double DELTA = 0.001;
    
    [Test]
    public void Calculate_shouldWorkForAddOperation()
    {
        ParseTree tree = new ParseTree(
            new AddOperation(new Operand(3), new Operand(10)) 
            );
        Assert.That(tree.Calculate(), Is.EqualTo(13));
    }
    
    [Test]
    public void Calculate_shouldWorkForSubtractionOperation()
    {
        ParseTree tree = new ParseTree(
            new SubtractionOperation(new Operand(-3), new Operand(-10)) 
        );
        Assert.That(tree.Calculate(), Is.EqualTo(7));
    }
    
    [Test]
    public void Calculate_shouldWorkForMultiplyOperation()
    {
        ParseTree tree = new ParseTree(
            new MultiplyOperation(new Operand(3), new Operand(-10)) 
        );
        Assert.That(tree.Calculate(), Is.EqualTo(-30));
    }
    
    [Test]
    public void Calculate_shouldWorkForDivideOperation()
    {
        ParseTree tree = new ParseTree(
            new DivideOperation(new Operand(21), new Operand(-7)) 
        );
        Assert.That(tree.Calculate(), Is.EqualTo(-3));
    }
    
    [Test]
    public void Calculate_shouldWorkForFloatResults()
    {
        // arrange
        ParseTree tree = new ParseTree(
            new AddOperation(new Operand(0.2), new Operand(0.1)) 
        );
        // act
        var actual = tree.Calculate() >= 0.3 - DELTA && tree.Calculate() <= 0.3 + DELTA;
        // assert
        Assert.That(actual, Is.True);
    }
    
    [Test]
    public void Calculate_shouldThrowExceptionWhenDivideByZero()
    {
        ParseTree tree = new ParseTree(
            new DivideOperation(new Operand(21), new Operand(0)) 
        );
        Assert.Throws<DivideByZeroException>(() => tree.Calculate());
    }
}