namespace ExpressionTree;

/// <summary>
/// Binary tree that calculates the value of an expression
/// </summary>
public class ParseTree
{
    private INode root;
    private int size;

    public ParseTree(string input) 
        => root = CreateTreeFromString(input);

    public ParseTree(INode root) 
        => this.root = root;

    public INode CreateTreeFromString(string input)
    {
        string[] tokens = input.Split([" ", "(", ")"], StringSplitOptions.RemoveEmptyEntries);
        if (TooManyNumbersInInputOrStartsWithNumber(tokens))
        {
            throw new IncorrectInputException();
        }
        return CreateTreeRecursive(tokens, 0);
    } 

    private INode CreateTreeRecursive(string[] tokens, int index)
    {
        if (index > tokens.Length - 1) // if there are not enough numbers, recursion don't reach the end of array
        {
            throw new IncorrectInputException();
        }
        
        switch (tokens[index])
        {
            case "+":
                return new AddOperation(
                    CreateTreeRecursive(tokens, index + 1),
                    CreateTreeRecursive(tokens, index + 2));
            case "-":
                return new SubtractionOperation(
                    CreateTreeRecursive(tokens, index + 1),
                    CreateTreeRecursive(tokens, index + 2));
            case "*":
                return new MultiplyOperation(
                    CreateTreeRecursive(tokens, index + 1),
                    CreateTreeRecursive(tokens, index + 2));
            case "/":
                return new DivideOperation(
                    CreateTreeRecursive(tokens, index + 1),
                    CreateTreeRecursive(tokens, index + 2));
            default:
                if (int.TryParse(tokens[index], out var value))
                {
                    return new Operand(value);
                }
                throw new IncorrectInputException();
        }
    }

    private bool TooManyNumbersInInputOrStartsWithNumber(string[] tokens)
    {
        bool result = false;
        if (tokens[0] is not ("+" or "/" or "-" or "*"))
        {
            return true;
        }
        for (int i = 1; i < tokens.Length - 1; i++) //check that there are no two number near (don't check last couple)
        {
            if (tokens[i] is not ("+" or "/" or "-" or "*") && tokens[i - 1] is not ("+" or "/" or "-" or "*"))
            {
                result = true;
            }
        }
        return result;
    }
    
    public double Calculate()
        => root.Calculate();

    public void Print()
        => root.Print();
}