using Calculator.exceptions;

namespace Calculator;

public class StackArrayImplementation : Stack // list stack implementation
{
    private const int DEFAULT_CAPASITY = 1024; 
    private int capacity; // max capacity of stack
    private double[] stackArray;
    private int top; // index of top stack element in array

    public StackArrayImplementation()
    {
        capacity = DEFAULT_CAPASITY;
        stackArray = new double[capacity];
        top = -1; // top == -1 if the stack is empty 
    }

    public StackArrayImplementation(int capacity) // constructor with custom capacity
    {
        this.capacity = capacity;
        stackArray = new double[capacity];
        top = -1; // top == -1 if the stack is empty 
    }

    public void Add(double value)
    {
        if (top == capacity - 1) // one cannot put more items on the stack than the capacity
        {
            throw new StackIsFullException();
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
    {
        return (top == -1); // the stack is empty if top == -1 
    }

    public int Size()
    {
        return top + 1; // stack size is the index of the top stack element + 1
    }
}