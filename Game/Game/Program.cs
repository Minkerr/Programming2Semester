namespace Game;

class Program
{
    static void Main(string[] args)
    {
        var game = new Game("map.txt");
        var eventLoop = new EventLoop();

        eventLoop.LeftHandler += game.MoveLeft;
        eventLoop.RightHandler += game.MoveRight;
        eventLoop.UpHandler += game.MoveUp;
        eventLoop.DownHandler += game.MoveDown;
        eventLoop.ExitHandler += game.Exit;

        eventLoop.Run();
    }
}