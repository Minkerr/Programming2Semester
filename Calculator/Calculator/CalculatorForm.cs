namespace Calculator;

/// <summary>
/// The calculator application form
/// </summary>
public partial class CalculatorForm : Form
{
    private Calculator calculator = new();

    public CalculatorForm()
    {
        SetUpButtons();
        display?.DataBindings.Add("Text", calculator, "Display",
            true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void OnNumberButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        calculator.AssignDigitToDisplayedNumber(button.Text.First());
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        var button = (Button)sender;
        calculator.SetOperation(button.Text.First());
    }

    private void OnEqualButtonClick(object sender, EventArgs e)
    {
        calculator.Calculate();
    }

    private void OnClearButtonClick(object sender, EventArgs e)
    {
        calculator.ClearCalculator();
    }

    private void OnChangeSignButtonClick(object sender, EventArgs e)
    {
        calculator.ChangeSign();
    }
}