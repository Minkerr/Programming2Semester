namespace Game.Test;

public class Tests
{
    private Game game;

    [SetUp]
    public void SetUp()
    {
        game = new Game("testMap.txt");
    }
    
    [Test]
    public void MovingCharacter_shouldWorkOnlyIfDirectionalCellIsFree()
    {
        // the cell above is occupied
        Assert.That(game.WillCharacterMove(Direction.Up), Is.False);
        // the cell to the left is occupied
        Assert.That(game.WillCharacterMove(Direction.Left), Is.False);
        // the cell below is occupied
        Assert.That(game.WillCharacterMove(Direction.Down), Is.False);
        // the cell to the right is occupied
        Assert.That(game.WillCharacterMove(Direction.Right), Is.True);
    }
}