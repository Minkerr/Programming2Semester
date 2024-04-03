namespace LZW.Test;

public class TrieTest
{
    [Test]
    public void AddAndContains_shouldAddElementToTheTrieAndCheckItsPresenceInTheTrieAccordingly()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add");
        // assert
        Assert.That(trie.Contains("add"), Is.True);
        Assert.That(trie.Contains("ad"), Is.False); // trie contains this prefix, but not the word
    }
    
    [Test]
    public void Size_shouldReturnNumberOfWordsForTrieWithMoreThanOneWord()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add");  //  () --a--> () --d--> () --d--> (*) 
        trie.Add("adam"); //   \                   \ --a--> () --m--> (*)
        trie.Add("test"); //    \--t--> () --e--> () --s--> --t--> (*) --s--> (*)
        trie.Add("tests");
        // assert
        Assert.That(trie.Size(), Is.EqualTo(4));
    }
    
    [Test]
    public void Remove_shouldRemoveWordFromTrieAndDecreaseSize()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add");  
        trie.Add("adam"); 
        trie.Add("test"); 
        trie.Add("tests");
        trie.Remove("adam");
        // assert
        Assert.That(trie.Size(), Is.EqualTo(3));
        Assert.That(trie.Contains("adam"), Is.False);
    }
    
    [Test]
    public void HowManyStartsWithPrefix_shouldReturnHowManyStartsWithPrefix()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add");  
        trie.Add("adam"); 
        trie.Add("abbey");
        // assert
        Assert.That(trie.HowManyStartsWithPrefix("a"), Is.EqualTo(3));
        Assert.That(trie.HowManyStartsWithPrefix("ad"), Is.EqualTo(2));
        Assert.That(trie.HowManyStartsWithPrefix("ada"), Is.EqualTo(1));
    }
}
