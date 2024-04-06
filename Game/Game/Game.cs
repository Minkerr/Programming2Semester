namespace Game;

using System.Text;

/// <summary>
/// class that implements the game mechanics 
/// </summary>
public class Game
{
    private int x; //coordinates of the character
    private int y;
    private List<StringBuilder> map = []; // array of walls and passages
    
    /// <summary>
    /// Read map from a file and print eat to the console.
    /// </summary>
    /// <param name="filePath"> The File path.</param>
    public Game(string filePath)
    {
        x = 1;
        y = 1;
        string[] allLines;
        allLines = File.ReadAllLines(filePath);
        foreach (var value in allLines)
        {
            map.Add(new StringBuilder(value));
        }
        
        PrintTheMap();
    }

    private void PrintTheMap()
    {
        foreach (var value in map)
        {
            Console.WriteLine(value);
        }
        SetCharacter(x, y);
    }

    private void SetCharacter(int newX, int newY)
    {
        Console.Write(' ');
        Console.SetCursorPosition(newX, newY);
        map[y][x] = ' ';
        Console.Write("@");
        Console.SetCursorPosition(newX, newY);
        this.x = newX;
        this.y = newY;
    }
    
    private void TryToMove(Direction direction)
    {
        int newX = x;
        int newY = y;
        switch (direction)
        {
            case Direction.Left:
                newX--;
                break;
            case Direction.Right:
                newX++;
                break;
            case Direction.Up:
                newY--;
                break;
            case Direction.Down:
                newY++;
                break;
        }

        if (map[newY][newX] == ' ') //The character can only pass through an empty cell
        {
            SetCharacter(newX, newY);
        }
    }

    /// <summary>
    /// Left event handler.
    /// </summary>
    public void MoveLeft(object? sender, EventArgs args)
    {
        TryToMove(Direction.Left);
    }

    /// <summary>
    /// Right event handler.
    /// </summary>
    public void MoveRight(object? sender, EventArgs args)
    {
        TryToMove(Direction.Right);
    }

    /// <summary>
    /// Up event handler.
    /// </summary>
    public void MoveUp(object? sender, EventArgs args)
    {
        TryToMove(Direction.Up);
    }

    /// <summary>
    /// Down event handler.
    /// </summary>
    public void MoveDown(object? sender, EventArgs args)
    {
        TryToMove(Direction.Down);
    }

    /// <summary>
    /// Exit from the game event handler.
    /// </summary>
    public void Exit(object? sender, EventArgs args)
    {
        Console.Clear();
        Environment.Exit(0);
    }
}