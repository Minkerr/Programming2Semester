namespace Calculator;

public interface Stack 
{
    // put new element on top of the stack
    void Add(double value);

    // remove top element og the stack
    double Pop();

    // get top element of the stack
    double Peek();

    // check  if the stack is empty
    bool IsEmpty();

    // get number of elements in the stack
    int Size();
}