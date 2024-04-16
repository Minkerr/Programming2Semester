using Game;

var game = new Game.Game("map.txt");
game.Start();
var eventLoop = new EventLoop();

eventLoop.LeftHandler += game.MoveLeft;
eventLoop.RightHandler += game.MoveRight;
eventLoop.UpHandler += game.MoveUp;
eventLoop.DownHandler += game.MoveDown;
eventLoop.ExitHandler += game.Exit;

eventLoop.Run();