namespace ExpressionTree.Tests;

public class ParseTreeTest
{
    [Test]
    public void Calculate_shouldCalculateSimpleExpression()
    {
        ParseTree tree = new ParseTree("+ 2 (/ 12 4)");
        Assert.That(tree.Calculate(), Is.EqualTo(5));
    }
    
    [Test]
    public void Calculate_shouldThrowExceptionForInputWithRealNumber()
    {
        Assert.Throws<IncorrectInputException>(() => new ParseTree("+ 2 (/ 12.0 4)"));
    }
    
    [Test]
    public void Calculate_shouldThrowExceptionForInputWithNotEnoughNumbers()
    {
        Assert.Throws<IncorrectInputException>(() => new ParseTree("+ 2"));
    }
    
    [Test]
    public void Calculate_shouldThrowExceptionForInputWithExtraNumbers()
    {
        Assert.Throws<IncorrectInputException>(() => new ParseTree("+ 2 3  * 4 5"));
    }
    
    [Test]
    public void Calculate_shouldThrowExceptionForInputThatStartsWithNumber()
    {
        Assert.Throws<IncorrectInputException>(() => new ParseTree("2 +"));
    }
}