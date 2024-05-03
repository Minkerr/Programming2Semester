using System.Text;

namespace LZW.Test;

public class TrieTest
{
    [Test]
    public void AddAndContains_shouldAddElementToTheTrieAndCheckItsPresenceInTheTrieAccordingly()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add"u8.ToArray().ToList());
        // assert
        Assert.That(trie.Contains("add"u8.ToArray().ToList()), Is.True);
        // trie contains this prefix, but not the word
        Assert.That(trie.Contains("ad"u8.ToArray().ToList()), Is.False); 
    }
    
    [Test]
    public void Size_shouldReturnNumberOfWordsForTrieWithMoreThanOneWord()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add"u8.ToArray().ToList());  //  () --a--> () --d--> () --d--> (*) 
        trie.Add("adam"u8.ToArray().ToList()); //   \                   \ --a--> () --m--> (*)
        trie.Add("test"u8.ToArray().ToList()); //    \--t--> () --e--> () --s--> --t--> (*) --s--> (*)
        trie.Add("tests"u8.ToArray().ToList());
        // assert
        Assert.That(trie.Size, Is.EqualTo(4));
    }
    
    [Test]
    public void Remove_shouldRemoveWordFromTrieAndDecreaseSize()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add"u8.ToArray().ToList());  
        trie.Add("adam"u8.ToArray().ToList()); 
        trie.Add("test"u8.ToArray().ToList()); 
        trie.Add("tests"u8.ToArray().ToList());
        trie.Remove("adam"u8.ToArray().ToList());
        // assert
        Assert.That(trie.Size, Is.EqualTo(3));
        Assert.That(trie.Contains("adam"u8.ToArray().ToList()), Is.False);
    }
    
    [Test]
    public void HowManyStartsWithPrefix_shouldReturnHowManyStartsWithPrefix()
    {
        // arrange
        Trie trie = new Trie();
        // actual
        trie.Add("add"u8.ToArray().ToList());  
        trie.Add("adam"u8.ToArray().ToList()); 
        trie.Add("abbey"u8.ToArray().ToList());
        // assert
        Assert.That(trie.HowManyStartsWithPrefix("a"u8.ToArray().ToList()), Is.EqualTo(3));
        Assert.That(trie.HowManyStartsWithPrefix("ad"u8.ToArray().ToList()), Is.EqualTo(2));
        Assert.That(trie.HowManyStartsWithPrefix("ada"u8.ToArray().ToList()), Is.EqualTo(1));
    }
}
