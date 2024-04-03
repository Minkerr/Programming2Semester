using System.Drawing;

namespace LZW;

public class Trie
{
    private TrieNode root;
    private int size;
    
    public Trie()
    {
        root = new TrieNode();
        size = 1;
    }

    public bool Add(string element) // add new word to the tree
    {
        TrieNode currentNode = root; // create "pointer"

        foreach (var c in element) // iterate through each letter in word
        {
            if (!currentNode.Children.TryGetValue(c, out TrieNode? value)) // try to go through existing prefix
            {
                value = new TrieNode();
                size++;
                currentNode.Children[c] = value; // if there is no such prefix, create new node with current letter
            }
            currentNode = value; // move "pointer" to the next node
        }

        bool isNewWord = !currentNode.IsEndOfWord; // return true if it is a new word
        currentNode.IsEndOfWord = true; // mark current node as the end of new word

        return isNewWord;
    }

    public bool Contains(string element) // check for the presence of a word in the tree
    {
        TrieNode currentNode = root; // create "pointer"
        
        foreach (char c in element) // iterate through each letter in word
        {
            if (!currentNode.Children.ContainsKey(c)) // the case when such a prefix does not exist
            {
                return false;
            }
            currentNode = currentNode.Children[c]; // move "pointer" to the next node
        }

        return currentNode.IsEndOfWord;
    }

    public bool Remove(string element)
    {
        TrieNode currentNode = root; // create "pointer"
        List<TrieNode> nodes = new List<TrieNode>(); // remember our path through the tree to the end of word. 
        nodes.Add(currentNode);                      // We will make a reverse move

        foreach (char c in element)
        {
            if (!currentNode.Children.ContainsKey(c)) // the case when the such word is not contained in the tree
            {
                return false;
            }
            currentNode = currentNode.Children[c]; // move "pointer" to the next node
            nodes.Add(currentNode); // write our path
        }

        if (!currentNode.IsEndOfWord) // the case when the such word is not contained in the tree
        {
            return false;
        }

        currentNode.IsEndOfWord = false; // we delete the word, so now this is not the end of the word
        
        for (int i = nodes.Count - 1; i >= 0; i--) // Remove all unused nodes
        {
            currentNode = nodes[i];  // set pointer to the last non-removed element of the word
            if (currentNode.Children.Count == 0 && !currentNode.IsEndOfWord)  
            { // remove node only if it is not the end of another word and there are no another children
                nodes[i - 1].Children.Remove(element[i - 1]);
                size--;
            }
            else
            {
                break;
            }
        }

        return true;
    }

    public int HowManyStartsWithPrefix(string prefix) 
    {
        TrieNode currentNode = root; // create "pointer"

        foreach (char c in prefix) // iterate through every letter in word
        {
            if (!currentNode.Children.ContainsKey(c)) // case when there is no such prefix
            {
                return 0;
            }
            currentNode = currentNode.Children[c]; // move pointer
        }

        return CountWords(currentNode); 
    }

    private int CountWords(TrieNode node)
    {
        int count = node.IsEndOfWord ? 1 : 0; // is given prefix the word?

        foreach (var key in node.Children.Keys) // iterate through all child letters
        {
            count += CountWords(node.Children[key]); // add to result words that starts with bigger prefix 
        }

        return count;
    }

    public int Size()
    {
        return size;
    }
}