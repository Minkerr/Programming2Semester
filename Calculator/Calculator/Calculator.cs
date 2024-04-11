using System.Globalization;

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
    private bool isDotEntered = false;
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
    /// A data binding event that supports instant display of the current result
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged()
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Display)));
    }

    /// <summary>
    /// Assign a digit to the displayed number in the calculator.
    /// </summary>
    public void AssignDigit(char digit)
    {
        switch (currentState)
        {
            case State.Number:
                if (Display is "0")
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
    /// Assign a dot to the displayed number in the calculator.
    /// </summary>
    public void AssignDot()
    {
        switch (currentState)
        {
            case State.Number:
                if (Display is "0")
                {
                    Display = "0,";
                    isDotEntered = true;
                }
                else if (!isDotEntered)
                {
                    Display += ",";
                    isDotEntered = true;
                }
                break;
            case State.Operation:
                intermediateValue = Display;
                Display = "0,";
                isDotEntered = true;
                currentState = State.Number;
                break;
        }
    }

    /// <summary>
    /// Set the operation to calculate.
    /// </summary>
    public void SetOperation(char operation)
    {
        switch (currentState)
        {
            case State.Number:
                if (currentOperation == ' ')
                {
                    currentOperation = operation;
                    currentState = State.Operation;
                    isDotEntered = false;
                }
                else
                {
                    try
                    {
                        Display = MakeCalculation().ToString();
                        isDotEntered = false;
                    }
                    catch (Exception e) when (e is DivideByZeroException)
                    {
                        SetErrorState();
                        return;
                    }

                    intermediateValue = Display;
                    currentOperation = operation;
                    currentState = State.Operation;
                }
                break;
            case State.Operation:
                currentOperation = operation;
                isDotEntered = false;
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
                        result = MakeCalculation();
                        isDotEntered = result.ToString().Contains(',');
                    }
                    catch (Exception e) when (e is DivideByZeroException)
                    {
                        SetErrorState();
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
                    result = MakeCalculation();
                }
                catch (Exception e) when (e is DivideByZeroException)
                {
                    SetErrorState();
                    return;
                }

                Display = result.ToString();
                break;
        }
    }

    /// <summary>
    /// Change the sign of the displayed number.
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
        isDotEntered = false;
        currentState = State.Number;
    }

    private void SetErrorState()
    {
        ClearCalculator();
        Display = "Error";
        currentState = State.Error;
    }
    
    private double MakeCalculation()
    {
        var rightResult = double.Parse(Display);
        var leftResult = double.Parse(intermediateValue);
        switch (currentOperation)
        {
            
            case '+':
                return leftResult + rightResult;
            case '-':
                return leftResult - rightResult;
            case '×':
                return leftResult * rightResult;
            case '÷':
                if (Math.Abs(rightResult) < Delta)
                {
                    throw new DivideByZeroException();
                }
                return leftResult / rightResult;
            default: 
                throw new ArgumentException();
        }
    }
}