namespace Calculator;

using System.ComponentModel;

/// <summary>
/// A class that implements a simple calculator
/// </summary>
public class Calculator : INotifyPropertyChanged
{
    private const double Delta = 0.001;
    private char currentOperation = ' ';
    private string intermediateValue = "0";
    private string displayedNumber = "0";
    private enum State
    {
        Number,
        Operation,
        Error,
    }
    private State currentState = State.Number;
    
    /// <summary>
    /// Property for instant overwriting of number on calculator display.
    /// </summary>
    public string Display
    {
        get => displayedNumber;

        private set
        {
            displayedNumber = value;
            NotifyPropertyChanged();
        }
    }
    
    /// <summary>
    /// A data binding event that synchronizes the linked data at the time of the change.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Display)));
    }

    /// <summary>
    /// Assign a digit to the displayed number in the calculator.
    /// </summary>
    public void AssignDigitToDisplayedNumber(char digit)
    {
        if (!char.IsDigit(digit))
        {
            throw new ArgumentException();
        }

        switch (currentState)
        {
            case State.Number:
                if (Display is "0" or "Error")
                {
                    Display = digit.ToString();
                }
                else
                {
                    Display += digit;
                }
                break;

            case State.Operation:
                intermediateValue = Display;
                Display = digit.ToString();
                currentState = State.Number;
                break;
        }
    }

    /// <summary>
    /// Set the operation to calculate.
    /// </summary>
    public void SetOperation(char operation)
    {
        if (operation != '+' && operation != '-' && operation != '×' && operation != '÷')
        {
            throw new ArgumentException();
        }

        switch (currentState)
        {
            case State.Number:
                if (currentOperation == ' ')
                {
                    intermediateValue = Display;
                    currentOperation = operation;
                    currentState = State.Operation;
                }
                else
                {
                    try
                    {
                        Display = Calculation().ToString();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        currentState = State.Error;
                        return;
                    }

                    intermediateValue = Display;
                    currentOperation = operation;
                    currentState = State.Operation;
                }
                break;

            case State.Operation:
                currentOperation = operation;
                break;

            case State.Error:
                break;
        }
    }

    /// <summary>
    /// Calculate the current expression in the calculator.
    /// </summary>
    public void Calculate()
    {
        double result = 0;

        switch (currentState)
        {
            case State.Number:
                if (currentOperation != ' ')
                {
                    try
                    {
                        result = Calculation();
                    }
                    catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                    {
                        ClearCalculator();
                        Display = "Error";
                        currentState = State.Error;
                        return;
                    }

                    Display = result.ToString();
                    currentOperation = ' ';
                    currentState = State.Number;
                }
                break;

            case State.Operation:
                try
                {
                    result = Calculation();
                }
                catch (Exception e) when (e is ArgumentException || e is DivideByZeroException)
                {
                    ClearCalculator();
                    Display = "Error";
                    currentState = State.Error;
                    return;
                }

                Display = result.ToString();
                break;
        }
    }

    /// <summary>
    /// Change the sign of the current value.
    /// </summary>
    public void ChangeSign()
    {
        if (currentState != State.Error && Display != "0")
        {
            if (Display[0] == '-')
            {
                Display = Display.Substring(1);
            }
            else
            {
                Display = "-" + Display;
            }
        }
    }

    /// <summary>
    /// Clear the calculator.
    /// </summary>
    public void ClearCalculator()
    {
        Display = "0";
        intermediateValue = "0";
        currentOperation = ' ';
        currentState = State.Number;
    }

    private double Calculation()
    {
        switch (currentOperation)
        {
            case '+':
                return double.Parse(intermediateValue) + double.Parse(Display);

            case '-':
                return double.Parse(intermediateValue) - double.Parse(Display);
            
            case '×':
                return double.Parse(intermediateValue) * double.Parse(Display);
            
            case '÷':
                var rightResult = double.Parse(Display);
                if (Math.Abs(rightResult) < Delta)
                {
                    throw new DivideByZeroException();
                }
                return double.Parse(intermediateValue) / rightResult;

            default: 
                throw new ArgumentException();
        }
    }
}