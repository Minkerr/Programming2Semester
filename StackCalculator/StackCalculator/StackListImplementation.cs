using Calculator.exceptions;

namespace Calculator;

public class StackListImplementation : Stack // list stack implementation
{
    private List<double> stackList;
    
    public StackListImplementation()
    {
        stackList = new List<double>();
    }
    
    public void Add(double value) 
    {
        stackList.Add(value); // add element to list
    }

    public double Pop()
    {
        if(stackList.Count == 0) // one cannot delete an item from an empty stack
        {
            throw new StackIsEmptyException();
        }

        double result = stackList[^1];
        stackList.RemoveAt(stackList.Count - 1); // remove last element of the list
        return result;
    }

    public double Peek()
    {
        if(stackList.Count == 0) // one cannot get an item from an empty stack
        {
            throw new StackIsEmptyException();
        }

        return stackList[^1]; // the top element of the stack is the last element of the list 
    }

    public bool IsEmpty()
    {
        return stackList.Count == 0; // the stack is empty if there are no elements in the list 
    }

    public int Size()
    {
        return stackList.Count; // the size of stack is the size of list 
    }
}