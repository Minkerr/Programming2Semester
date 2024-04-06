namespace Calculator;

// interface of stack data structure
public interface Stack 
{
    /// <summary>
    /// put new element on top of the stack
    /// </summary>
    /// <param name="value"></param>
    void Add(double value);

    /// <summary>
    /// remove top element og the stack
    /// </summary>
    /// <returns></returns>
    double Pop();

    /// <summary>
    /// get top element of the stack
    /// </summary>
    /// <returns></returns>
    double Peek();

    /// <summary>
    /// check  if the stack is empty
    /// </summary>
    /// <returns></returns>
    bool IsEmpty();

    /// <summary>
    /// get number of elements in the stack
    /// </summary>
    /// <returns></returns>
    int Size();
}