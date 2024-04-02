using Calculator.exceptions;

namespace Calculator;

public class StackCalculator // calculator of expressions written in reverse Polish notation
{
    private Stack stack;
    private const double DELTA = 0.001; // error for checking the equality of floating point numbers

    public StackCalculator(Stack stack) // we can use two stack realization for this calculator
    {
        this.stack = stack;
    }

    private bool ApproximatelyEqual(double first, double second) // checking the equality of floating point numbers
    {
        return first >= second - DELTA && first <= second + DELTA;
    }

    public double Calculate(string expression)
    {
        string[] tokens = expression.Split(' '); // make all numbers and operators separate elements
        
        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number)) // if we come across a number, add it to the stack
            {
                stack.Add(number); 
            }
            else // if we come across an operator, get two top numbers, 
            { // apply an operator to them and put the result on the stack
                if (stack.Size() <= 1)
                {
                    throw new StackCalculatorIncorrectInputException();
                }
                double secondOperand = stack.Pop(); // get to top numbers from the stack for calculation
                double firstOperand = stack.Pop();
                double result = 0;
                switch (token) // calculate intermediate result for any operator
                {
                    case "+":
                        result = firstOperand + secondOperand;
                        break;
                    case "-":
                        result = firstOperand - secondOperand;
                        break;
                    case "*":
                        result = firstOperand * secondOperand;
                        break;
                    case "/":
                        if (ApproximatelyEqual(secondOperand, 0)) // process divide by zero case
                        {
                            throw new DivideByZeroException();
                        }
                        result = firstOperand / secondOperand;
                        break;
                    default:
                        throw new StackCalculatorIncorrectInputException();
                }

                stack.Add(result); // add intermediate calculation result to the stack
            }
        }

        if (stack.Size() > 1) // not enough operators in input string
        {
            throw new StackCalculatorIncorrectInputException();
        }
        
        return stack.Peek();
    }
}

