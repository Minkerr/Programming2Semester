namespace Calculator;

/// <summary>
/// interface of stack data structure
/// </summary>
public interface IStack 
{
    /// <summary>
    /// put new element on top of the stack
    /// </summary>
    /// <param name="value"></param>
    void Add(double value);

    /// <summary>
    /// remove top element og the stack
    /// </summary>
    double Pop();

    /// <summary>
    /// get top element of the stack
    /// </summary>
    double Peek();

    /// <summary>
    /// check  if the stack is empty
    /// </summary>
    bool IsEmpty();

    /// <summary>
    /// get number of elements in the stack
    /// </summary>
    int Size();
}