namespace Calculator;

internal static class Program
{
    /// <summary>
    /// The method that launch the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new CalculatorForm());
    }
}