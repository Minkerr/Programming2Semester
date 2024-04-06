using Calculator.Exceptions;
using Assert = NUnit.Framework.Assert;

namespace Calculator.Tests;

public class StackTest
{
    private static IEnumerable<TestCaseData> Stacks
        => new TestCaseData[]
        {
            new TestCaseData(new StackArrayImplementation()),
            new TestCaseData(new StackListImplementation()),
        };

    [TestCaseSource(nameof(Stacks))]
    public void Add_shouldAddElementToStackTop(IStack stack)
    {
        stack.Add(2);
        Assert.That(stack.Peek(), Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Stacks))]
    public void Pop_shouldDeleteElementFromStackTopAndReturnDeletedElement(IStack stack)
    {
        stack.Add(2);
        var actual = stack.Pop();
        Assert.That(stack.IsEmpty(), Is.True);
        Assert.That(actual, Is.EqualTo(2));
    }

    [TestCaseSource(nameof(Stacks))]
    public void Pop_shouldThrowExceptionWhenStackIsEmpty(IStack stack)
    {
        Assert.Throws<StackIsEmptyException>(() => stack.Pop());
    }

    [TestCaseSource(nameof(Stacks))]
    public void Peek_shouldThrowExceptionWhenStackIsEmpty(IStack stack)
    {
        Assert.Throws<StackIsEmptyException>(() => stack.Peek());
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Size_shouldReturnNumberOfElements(IStack stack)
    {
        stack.Add(2);
        stack.Add(3);
        Assert.That(stack.Size(), Is.EqualTo(2));
    }
    
    [TestCaseSource(nameof(Stacks))]
    public void Size_shouldReturnZeroForEmptyStack(IStack stack)
    {
        Assert.That(stack.Size(), Is.EqualTo(0));
    }

    [Test]
    public void AddInArrayStack_shouldResizeStackWhenStackIsOverflowed()
    {
        IStack stack = new StackArrayImplementation(0);
        stack.Add(2);
        Assert.That(stack.Peek(), Is.EqualTo(2));
    }
}