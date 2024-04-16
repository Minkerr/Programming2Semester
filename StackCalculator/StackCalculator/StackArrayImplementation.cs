using StackCalculator.Exceptions;

namespace StackCalculator;

/// <summary>
/// list stack implementation
/// </summary>
public class StackArrayImplementation : IStack 
{
    private const int DefaultCapacity = 1024; 
    private double[] stackArray;
    private int top; // index of top stack element in array

    public StackArrayImplementation() : this(DefaultCapacity)
    {
    }

    public StackArrayImplementation(int capacity) // constructor with custom capacity
    {
        stackArray = new double[capacity];
        top = -1; // top == -1 if the stack is empty 
    }

    public void Push(double value)
    {
        if (top == stackArray.Length - 1) // one cannot put more items on the stack than the capacity
        {
            Array.Resize(ref stackArray, stackArray.Length * 2);
        }
        top++; 
        stackArray[top] = value; // write element to the array
    }

    public double Pop()
    {
        if (top == -1) // one cannot delete an item from an empty stack
        {
            throw new StackIsEmptyException();
        }
        double result = stackArray[top];
        top--; // "remove" element from the top 
        return result;
    }

    public double Peek()
    {
        if (top == -1) // one cannot get an item from an empty stack
        {
            throw new StackIsEmptyException();
        }
        return stackArray[top]; // the top stack element is the element of the array with index == top
    }

    public bool IsEmpty()
        => top == -1; // the stack is empty if top == -1 
    
    public int Size()
        => top + 1; // stack size is the index of the top stack element + 1
}