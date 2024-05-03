namespace Game;

/// <summary>
/// class that is waiting for the event
/// </summary>
public class EventLoop
{
    /// <summary>
    /// Handler of the left arrow click event
    /// </summary>
    public event EventHandler<EventArgs> LeftHandler = (sender, args) => { };

    /// <summary>
    /// Handler of the right arrow click event
    /// </summary>
    public event EventHandler<EventArgs> RightHandler = (sender, args) => { };

    /// <summary>
    /// Handler of the up arrow click event
    /// </summary>
    public event EventHandler<EventArgs> UpHandler = (sender, args) => { };

    /// <summary>
    /// Handler of the left down click event
    /// </summary>
    public event EventHandler<EventArgs> DownHandler = (sender, args) => { };
    
    /// <summary>
    /// Handler of exit event
    /// </summary>
    public event EventHandler<EventArgs> ExitHandler = (sender, args) => { };

    /// <summary>
    /// Method that observing actions of user.
    /// </summary>
    public void Run()
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    RightHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.LeftArrow:
                    LeftHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.UpArrow:
                    UpHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.DownArrow:
                    DownHandler(this, EventArgs.Empty);
                    break;
                case ConsoleKey.Spacebar:
                    ExitHandler(this, EventArgs.Empty);
                    break;
            }
        }
    }
}