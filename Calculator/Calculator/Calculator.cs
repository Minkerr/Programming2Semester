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
    public string DisplayedNumber
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
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayedNumber)));
    }

    /// <summary>
    /// Assign a digit to the displayed number in the calculator.
    /// </summary>
    public void AssignDigit(char digit)
    {
        switch (currentState)
        {
            case State.Number:
                if (DisplayedNumber is "0")
                {
                    DisplayedNumber = digit.ToString();
                }
                else
                {
                    DisplayedNumber += digit;
                }
                break;
            case State.Operation:
                intermediateValue = DisplayedNumber;
                DisplayedNumber = digit.ToString();
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
                if (DisplayedNumber is "0")
                {
                    DisplayedNumber = "0,";
                    isDotEntered = true;
                }
                else if (!isDotEntered)
                {
                    DisplayedNumber += ",";
                    isDotEntered = true;
                }
                break;
            case State.Operation:
                intermediateValue = DisplayedNumber;
                DisplayedNumber = "0,";
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
                        DisplayedNumber = MakeCalculation().ToString();
                        isDotEntered = false;
                    }
                    catch (Exception e) when (e is DivideByZeroException)
                    {
                        SetErrorState();
                        return;
                    }

                    intermediateValue = DisplayedNumber;
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

                    DisplayedNumber = result.ToString();
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

                DisplayedNumber = result.ToString();
                break;
        }
    }

    /// <summary>
    /// Change the sign of the displayed number.
    /// </summary>
    public void ChangeSign()
    {
        if (currentState != State.Error && DisplayedNumber != "0")
        {
            if (DisplayedNumber[0] == '-')
            {
                DisplayedNumber = DisplayedNumber.Substring(1);
            }
            else
            {
                DisplayedNumber = "-" + DisplayedNumber;
            }
        }
    }

    /// <summary>
    /// Clear the calculator.
    /// </summary>
    public void ClearCalculator()
    {
        DisplayedNumber = "0";
        intermediateValue = "0";
        currentOperation = ' ';
        isDotEntered = false;
        currentState = State.Number;
    }

    private void SetErrorState()
    {
        ClearCalculator();
        DisplayedNumber = "Error";
        currentState = State.Error;
    }
    
    private double MakeCalculation()
    {
        var rightResult = double.Parse(DisplayedNumber);
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